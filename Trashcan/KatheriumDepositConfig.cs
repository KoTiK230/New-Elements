using STRINGS;
using System.Collections.Generic;
using TUNING;
using UnityEngine;
using New_Elements.Chemistry;

namespace New_Elements
{
    public class Deposits
    {
        class KatheriumDepositConfig : IEntityConfig
        {
            public const string ID = "KatheriumDeposit";
            public static string Name = UI.FormatAsLink("Katherium Deposit", $"GeyserGeneric_{ID.ToUpper()}");
            public static string Description = $"A vast mineral deposit that spreads through other regions of the asteroid.";

            public GameObject CreatePrefab()
            {
                EffectorValues decor = TUNING.BUILDINGS.DECOR.BONUS.TIER1;
                GameObject go = EntityTemplates.CreatePlacedEntity(ID, Name, Description, 2000f, Assets.GetAnim("geyser_side_oil_kanim"), "off", Grid.SceneLayer.BuildingBack, 4, 2, decor, TUNING.NOISE_POLLUTION.NOISY.TIER5, SimHashes.Creature, null, 293f);
                go.GetComponent<OccupyArea>().objectLayers = new ObjectLayer[] { ObjectLayer.Building };
                PrimaryElement component = go.GetComponent<PrimaryElement>();
                component.SetElement(KatheriumElement.KatheriumOreSimHash, true);
                component.Temperature = 372.15f;
                go.AddOrGet<BuildingAttachPoint>().points = new BuildingAttachPoint.HardPoint[] { new BuildingAttachPoint.HardPoint(new CellOffset(0, 0), (Tag)"depositMinerSolid", null) };
                SoundEventVolumeCache.instance.AddVolume("geyser_side_methane_kanim", "GeyserMethane_shake_LP", TUNING.NOISE_POLLUTION.NOISY.TIER5);
                SoundEventVolumeCache.instance.AddVolume("geyser_side_methane_kanim", "GeyserMethane_erupt_LP", TUNING.NOISE_POLLUTION.NOISY.TIER6);
                return go;
            }

            public string[] GetDlcIds() =>
                DlcManager.AVAILABLE_ALL_VERSIONS;

            public void OnPrefabInit(GameObject inst)
            {
            }

            public void OnSpawn(GameObject inst)
            {
            }
        }
        class NitrogenDepositConfig : IEntityConfig
        {
            public const string ID = "NitrogenDeposit";
            public static string Name = UI.FormatAsLink("Nitrogen Deposit", $"GeyserGeneric_{ID.ToUpper()}");
            public static string Description = $"A vast mineral deposit that spreads through other regions of the asteroid.";

            public GameObject CreatePrefab()
            {
                EffectorValues decor = TUNING.BUILDINGS.DECOR.BONUS.TIER1;
                GameObject go = EntityTemplates.CreatePlacedEntity(ID, Name, Description, 2000f, Assets.GetAnim("geyser_side_oil_kanim"), "off", Grid.SceneLayer.BuildingBack, 4, 2, decor, TUNING.NOISE_POLLUTION.NOISY.TIER5, SimHashes.Creature, null, 293f);
                go.GetComponent<OccupyArea>().objectLayers = new ObjectLayer[] { ObjectLayer.Building };
                PrimaryElement component = go.GetComponent<PrimaryElement>();
                component.SetElement(SimHashes.IgneousRock, true);
                component.Temperature = 372.15f;
                go.AddOrGet<BuildingAttachPoint>().points = new BuildingAttachPoint.HardPoint[] { new BuildingAttachPoint.HardPoint(new CellOffset(0, 0), (Tag)"depositMinerGas", null) };
                SoundEventVolumeCache.instance.AddVolume("geyser_side_methane_kanim", "GeyserMethane_shake_LP", TUNING.NOISE_POLLUTION.NOISY.TIER5);
                SoundEventVolumeCache.instance.AddVolume("geyser_side_methane_kanim", "GeyserMethane_erupt_LP", TUNING.NOISE_POLLUTION.NOISY.TIER6);
                return go;
            }

            public string[] GetDlcIds() =>
                DlcManager.AVAILABLE_ALL_VERSIONS;

            public void OnPrefabInit(GameObject inst)
            {
            }

            public void OnSpawn(GameObject inst)
            {
            }
        }
    }
}
