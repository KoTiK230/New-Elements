using HarmonyLib;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using STRINGS;
using New_Elements.Chemistry;

namespace New_Elements
{
    public static class WiresPatch
    {
        public static readonly float[] SUPERCONDUCTOR_WIRE_THICC_MASS_KG = new float[2]
        {
      TUNING.BUILDINGS.CONSTRUCTION_MASS_KG.TIER2[0],
      TUNING.BUILDINGS.CONSTRUCTION_MASS_KG.TIER0[0]
        };
        public static readonly float[] SUPERCONDUCTOR_WIRE_TINY_MASS_KG = new float[2]
        {
      TUNING.BUILDINGS.CONSTRUCTION_MASS_KG.TIER0[0],
      TUNING.BUILDINGS.CONSTRUCTION_MASS_KG.TIER_TINY[0]
        };
        public static readonly string[] SUPERCONDUCTOR_WIRE_MATERIALS = new string[2]
        {
      KatheriumAlloyElement.KatheriumAlloySimHash.ToString(),
      RubberElement.RubberSimHash.ToString()
        };

        public enum WattageRating
        {
            Max500,
            Max1000,
            Max2000,
            Max20000,
            Max50000,
            Max10000,
            Max500000,
            NumRatings,
        }
        public static Wire.WattageRating ToWireWattageRating(this WattageRating rating) => (Wire.WattageRating)(int)rating;
        public static WattageRating ToWiresPatchWattageRating(this Wire.WattageRating rating) => (WattageRating)(int)rating;
        public static GameUtil.WattageFormatterUnit GetFormatterUnit(this Wire.WattageRating rating) => rating.ToWiresPatchWattageRating().GetFormatterUnit();
        public static GameUtil.WattageFormatterUnit GetFormatterUnit(this WattageRating rating)
        {
            switch (rating)
            {
                case WattageRating.Max500:
                case WattageRating.Max1000:
                case WattageRating.Max2000:
                case WattageRating.Max10000:
                    return GameUtil.WattageFormatterUnit.Watts;
                case WattageRating.Max20000:
                case WattageRating.Max50000:
                case WattageRating.Max500000:
                    return GameUtil.WattageFormatterUnit.Kilowatts;
                default:
                    return GameUtil.WattageFormatterUnit.Watts;
            }
        }

        [HarmonyPatch(typeof(Wire), "GetMaxWattageAsFloat")]
        public class Wire_GetMaxWattageAsFloat_Patch
        {
            public static bool Prefix(Wire.WattageRating rating, ref float __result)
            {
                if (rating < Wire.WattageRating.NumRatings)
                    return true;
                switch (rating.ToWiresPatchWattageRating())
                {
                    case WattageRating.Max10000:
                        __result = 10000f;
                        break;
                    case WattageRating.Max500000:
                        __result = 500000f;
                        break;
                    default:
                        __result = 0.0f;
                        break;
                }
                return false;
            }
        }
        [HarmonyPatch(typeof(Wire), "OnPrefabInit")]
        public class Wire_OnPrefabInit_Patch
        {
            public static bool Prefix(Wire __instance, ref StatusItem ___WireCircuitStatus, ref StatusItem ___WireMaxWattageStatus)
            {
                if (___WireCircuitStatus == null)
                {
                    ___WireCircuitStatus = new StatusItem("WireCircuitStatus", "BUILDING", string.Empty, StatusItem.IconType.Info, NotificationType.Neutral, false, OverlayModes.None.ID).SetResolveStringCallback(delegate (string str, object data)
                    {
                        Wire wire2 = (Wire)data;
                        int cell2 = Grid.PosToCell(wire2.transform.GetPosition());
                        CircuitManager circuitManager2 = Game.Instance.circuitManager;
                        ushort circuitID2 = circuitManager2.GetCircuitID(cell2);
                        float wattsUsedByCircuit = circuitManager2.GetWattsUsedByCircuit(circuitID2);
                        GameUtil.WattageFormatterUnit unit2 = wire2.MaxWattageRating.GetFormatterUnit();
                        float maxWattageAsFloat2 = Wire.GetMaxWattageAsFloat(wire2.MaxWattageRating);
                        float wattsNeededWhenActive2 = circuitManager2.GetWattsNeededWhenActive(circuitID2);
                        string wireLoadColor = GameUtil.GetWireLoadColor(wattsUsedByCircuit, maxWattageAsFloat2, wattsNeededWhenActive2);
                        str = str.Replace("{CurrentLoadAndColor}", (wireLoadColor == Color.white.ToHexString()) ? GameUtil.GetFormattedWattage(wattsUsedByCircuit, unit2) : ("<color=#" + wireLoadColor + ">" + GameUtil.GetFormattedWattage(wattsUsedByCircuit, unit2) + "</color>"));
                        str = str.Replace("{MaxLoad}", GameUtil.GetFormattedWattage(maxWattageAsFloat2, unit2));
                        str = str.Replace("{WireType}", __instance.GetProperName());
                        return str;
                    });
                }
                if (___WireMaxWattageStatus == null)
                {
                    ___WireMaxWattageStatus = new StatusItem("WireMaxWattageStatus", "BUILDING", string.Empty, StatusItem.IconType.Info, NotificationType.Neutral, false, OverlayModes.None.ID).SetResolveStringCallback(delegate (string str, object data)
                    {
                        Wire wire = (Wire)data;
                        GameUtil.WattageFormatterUnit unit = wire.MaxWattageRating.GetFormatterUnit();
                        int cell = Grid.PosToCell(wire.transform.GetPosition());
                        CircuitManager circuitManager = Game.Instance.circuitManager;
                        ushort circuitID = circuitManager.GetCircuitID(cell);
                        float wattsNeededWhenActive = circuitManager.GetWattsNeededWhenActive(circuitID);
                        float maxWattageAsFloat = Wire.GetMaxWattageAsFloat(wire.MaxWattageRating);
                        str = str.Replace("{TotalPotentialLoadAndColor}", (wattsNeededWhenActive > maxWattageAsFloat) ? ("<color=#" + new Color(251f / 255f, 176f / 255f, 59f / 255f).ToHexString() + ">" + GameUtil.GetFormattedWattage(wattsNeededWhenActive, unit) + "</color>") : GameUtil.GetFormattedWattage(wattsNeededWhenActive, unit));
                        str = str.Replace("{MaxLoad}", GameUtil.GetFormattedWattage(maxWattageAsFloat, unit));
                        return str;
                    });
                }

                return true;
            }
        }
        [HarmonyPatch(typeof(CircuitManager), "Rebuild")]
        public class CircuitManager_Rebuild_Patch
        {
            public static bool Prefix(object ___circuitInfo)
            {
                var circuitInfo = (IList)___circuitInfo;

                for (int i = 0; i < circuitInfo.Count; i++)
                {
                    object info = circuitInfo[i];

                    var bridgeGroups = Traverse.Create(info).Field<List<WireUtilityNetworkLink>[]>("bridgeGroups");

                    if (bridgeGroups.Value.Length >= (int)WattageRating.NumRatings) continue;

                    var list = bridgeGroups.Value.ToList();
                    while (list.Count < (int)WattageRating.NumRatings)
                    {
                        list.Add(new List<WireUtilityNetworkLink>());
                    }
                    bridgeGroups.Value = list.ToArray();

                    circuitInfo[i] = info;
                }

                return true;
            }
        }

        [HarmonyPatch(typeof(ElectricalUtilityNetwork), MethodType.Constructor)]
        public class ElectricalUtilityNetwork_CTor_Patch
        {
            public static void Postfix(ref List<Wire>[] ___wireGroups)
            {
                ___wireGroups = new List<Wire>[(int)WattageRating.NumRatings];
            }
        }

        [HarmonyPatch(typeof(ElectricalUtilityNetwork), "Reset")]
        public class ElectricalUtilityNetwork_Reset_Patch
        {
            public static bool Prefix(ElectricalUtilityNetwork __instance, List<Wire> ___allWires, UtilityNetworkGridNode[] grid, float ___timeOverloaded, List<Wire>[] ___wireGroups)
            {
                for (int i = 0; i < ___wireGroups.Length; i++)
                {
                    List<Wire> wires = ___wireGroups[i];
                    if (wires == null)
                    {
                        continue;
                    }
                    for (int j = 0; j < wires.Count; j++)
                    {
                        Wire wire = wires[j];
                        if (wire != null)
                        {
                            wire.circuitOverloadTime = ___timeOverloaded;
                            int cell = Grid.PosToCell(wire.transform.GetPosition());
                            UtilityNetworkGridNode utilityNetworkGridNode = grid[cell];
                            utilityNetworkGridNode.networkIdx = -1;
                            grid[cell] = utilityNetworkGridNode;
                        }
                    }
                    wires.Clear();
                }

                ___allWires.Clear();
                Traverse.Create(__instance).Method("RemoveOverloadedNotification").GetValue();

                return false;
            }
        }
        [HarmonyPatch(typeof(ElectricalUtilityNetwork), "UpdateOverloadTime")]
        public class ElectricalUtilityNetwork_UpdateOverloadTime_Patch
        {
            public static bool Prefix(ElectricalUtilityNetwork __instance, float dt, float watts_used, List<WireUtilityNetworkLink>[] bridgeGroups, ref float ___timeOverloaded, ref GameObject ___targetOverloadedWire, ref Notification ___overloadedNotification, ref float ___timeOverloadNotificationDisplayed, List<Wire>[] ___wireGroups)
            {
                bool wattage_rating_exceeded = false;
                List<Wire> overloaded_wires = null;
                List<WireUtilityNetworkLink> overloaded_bridges = null;
                for (int rating_idx = 0; rating_idx < ___wireGroups.Length; rating_idx++)
                {
                    List<Wire> wires = ___wireGroups[rating_idx];
                    List<WireUtilityNetworkLink> bridges = bridgeGroups[rating_idx];
                    Wire.WattageRating rating = (Wire.WattageRating)rating_idx;
                    float max_wattage = Wire.GetMaxWattageAsFloat(rating);
                    if (watts_used > max_wattage && ((bridges != null && bridges.Count > 0) || (wires != null && wires.Count > 0)))
                    {
                        wattage_rating_exceeded = true;
                        overloaded_wires = wires;
                        overloaded_bridges = bridges;
                        break;
                    }
                }
                overloaded_wires?.RemoveAll((Wire x) => x == null);
                overloaded_bridges?.RemoveAll((WireUtilityNetworkLink x) => x == null);
                if (wattage_rating_exceeded)
                {
                    ___timeOverloaded += dt;
                    if (!(___timeOverloaded > 6f))
                    {
                        return false;
                    }
                    ___timeOverloaded = 0f;
                    if (___targetOverloadedWire == null)
                    {
                        if (overloaded_bridges != null && overloaded_bridges.Count > 0)
                        {
                            int random_bridge_idx = Random.Range(0, overloaded_bridges.Count);
                            ___targetOverloadedWire = overloaded_bridges[random_bridge_idx].gameObject;
                        }
                        else if (overloaded_wires != null && overloaded_wires.Count > 0)
                        {
                            int random_wire_idx = Random.Range(0, overloaded_wires.Count);
                            ___targetOverloadedWire = overloaded_wires[random_wire_idx].gameObject;
                        }
                    }
                    if (___targetOverloadedWire != null)
                    {
                        ___targetOverloadedWire.Trigger(-794517298, new BuildingHP.DamageSourceInfo
                        {
                            damage = 1,
                            source = STRINGS.BUILDINGS.DAMAGESOURCES.CIRCUIT_OVERLOADED,
                            popString = STRINGS.UI.GAMEOBJECTEFFECTS.DAMAGE_POPS.CIRCUIT_OVERLOADED,
                            takeDamageEffect = SpawnFXHashes.BuildingSpark,
                            fullDamageEffectName = "spark_damage_kanim",
                            statusItemID = Db.Get().BuildingStatusItems.Overloaded.Id
                        });
                    }
                    if (___overloadedNotification == null)
                    {
                        ___timeOverloadNotificationDisplayed = 0f;
                        //___overloadedNotification = new Notification(STRINGS.MISC.NOTIFICATIONS.CIRCUIT_OVERLOADED.NAME, NotificationType.BadMinor, HashedString.Invalid, null, null, true, 0f, null, null, ___targetOverloadedWire.transform);
                        ___overloadedNotification = new Notification((string)MISC.NOTIFICATIONS.CIRCUIT_OVERLOADED.NAME, NotificationType.BadMinor, click_focus: ___targetOverloadedWire.transform);
                        GameScheduler.Instance.Schedule("Power Tutorial", 2f, delegate
                        {
                            Tutorial.Instance.TutorialMessage(Tutorial.TutorialMessages.TM_Power);
                        });
                        Notifier notifier = Game.Instance.FindOrAdd<Notifier>();
                        notifier.Add(___overloadedNotification);
                    }
                }
                else
                {
                    ___timeOverloaded = Mathf.Max(0f, ___timeOverloaded - dt * 0.95f);
                    ___timeOverloadNotificationDisplayed += dt;
                    if (___timeOverloadNotificationDisplayed > 5f)
                    {
                        Traverse.Create(__instance).Method("RemoveOverloadedNotification").GetValue();
                    }
                }

                return false;
            }
        }
    }
}
