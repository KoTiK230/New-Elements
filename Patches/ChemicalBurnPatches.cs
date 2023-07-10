using System;
using System.Collections.Generic;
using UnityEngine;
using HarmonyLib;

namespace ChemicalBurn
{
    public class ChemicalBurnPatches : KMonoBehaviour
    {
        public float lastBurnTime;
        public float ChemicalDamage;
        public float damage;
        public static StatusItem status_item = ChemicalBurnPatches.MakeStatusItem();

        public static StatusItem MakeStatusItem()
        {
            StatusItem statusItem = new StatusItem("ChemicalBurns", "DUPLICANTS", string.Empty, StatusItem.IconType.Exclamation, NotificationType.DuplicantThreatening, false, OverlayModes.None.ID, status_overlays: 63486);
            statusItem.AddNotification();
            return statusItem;
        }

        public void CheckForToxicChemicals(float dt)
        {
            Health component = this.gameObject.GetComponent<Health>();
            ChemicalDamage = ToxicChemicalSearch();
            if (ChemicalDamage != 0 && (bool)(UnityEngine.Object)component && (double)Time.time - (double)this.lastBurnTime > 5.0)
            {
                component.Damage(ChemicalDamage);
                this.lastBurnTime = Time.time;
                this.gameObject.GetComponent<KSelectable>().AddStatusItem(ChemicalBurnPatches.status_item, (object)this);
            }
            else
            {
                if ((double)Time.time - (double)this.lastBurnTime <= 5.0)
                    return;
                this.gameObject.GetComponent<KSelectable>().RemoveStatusItem(ChemicalBurnPatches.status_item, (bool)(UnityEngine.Object)this);
            }
        }

        public float ToxicChemicalSearch()
        {
            if (!this.gameObject.HasTag(GameTags.Dead) && !(bool)(UnityEngine.Object)this.gameObject.GetComponent<SuitEquipper>().IsWearingAirtightSuit())
            {
                int cell = Grid.PosToCell(this.gameObject);
                Element element1 = Grid.Element[cell];
                float mass1 = Grid.Mass[cell];
                int i = Grid.CellAbove(Grid.PosToCell(this.gameObject));
                Element element2 = Grid.Element[i];
                float mass2 = Grid.Mass[i];
                float multiplier1;
                float multiplier2;
                if ((element1.toxicity > 0f && mass1 > 0.2f) || (mass2 > 0.2f && element2.toxicity > 0f))
                {
                    if (element1.IsGas) { multiplier1 = 10f; } else { multiplier1 = 0.01f; }
                    if (element2.IsGas) { multiplier2 = 10f; } else { multiplier2 = 0.01f; }
                    damage = Convert.ToInt32(Math.Sqrt(element1.toxicity * mass1 * multiplier1 + element2.toxicity * mass2 * multiplier2));
                    return damage;
                }
            }
            return damage=0;
        }

    }

    [HarmonyPatch(typeof(OxygenBreather), "Sim200ms")]
    internal class ChemicalBurns_OxygenBreather_Sim200ms
    {
        private static void Postfix(OxygenBreather __instance, float dt) => __instance.gameObject.AddOrGet<ChemicalBurnPatches>().CheckForToxicChemicals(dt);
    }
}
