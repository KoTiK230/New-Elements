using System.Collections.Generic;
using STRINGS;
using UnityEngine;

namespace New_Elements
{
    class ButterCupConfig : IEntityConfig
    {
        public const string ID = "ButterCup";
        public const string SEED_ID = "ButterCupSeed";

        public static string NAME = UI.FormatAsLink("ButterCup", ID.ToUpper());
        public static string DESC = $"{UI.FormatAsLink("bleh", "PLANTS")}.";
        public static string DOMESTICATED_DESC = $"This {UI.FormatAsLink("fern", "PLANTS")} produces edible spores that may be processed into high-calorie {UI.FormatAsLink("Food", "FOOD")}.";

        public static string SEED_NAME = UI.FormatAsLink("ButterCup Seed", ID.ToUpper());
        public static string SEED_DESC = $"An incredibly energy dense spore of a {NAME}";

        public string[] GetDlcIds() => DlcManager.AVAILABLE_ALL_VERSIONS;

        public const float DefaultTemperature = 267.15f;
        public const float TemperatureLethalLow = 277.15f;
        public const float TemperatureLethalHigh = 287.15f;
        public const float TemperatureWarningLow = TemperatureLethalLow;
        public const float TemperatureWarningHigh = TemperatureLethalHigh;
        public static string crop_id = ButterFoodConfig.ID;
        SingleEntityReceptacle.ReceptacleDirection direction = SingleEntityReceptacle.ReceptacleDirection.Top;
        SimHashes[] safe_elements = { SimHashes.SourGas, SimHashes.Methane };
        public const int width = 1;
        public const int height = 2;
        SimHashes hash = SimHashes.Petroleum;
        public const float FertilizationRate = 30f / 600f;
        public const float max_age = 8f * 600f;
        public const float max_rad = TUNING.PLANTS.RADIATION_THRESHOLDS.TIER_3;
        EffectorValues decor = TUNING.DECOR.BONUS.TIER1;

        public GameObject CreatePrefab()
        {
            var prefab = EntityTemplates.CreatePlacedEntity(
                ID,
                NAME,
                DESC,
                1f,
                Assets.GetAnim("swampcrop_kanim"),
                "idle_empty",
                Grid.SceneLayer.BuildingFront,
                width: width,
                height: height,
                decor: decor,
                defaultTemperature: DefaultTemperature);

            EntityTemplates.ExtendEntityToBasicPlant(
                prefab,
                temperature_lethal_low: TemperatureLethalLow,
                temperature_warning_low: TemperatureWarningLow,
                temperature_warning_high: TemperatureWarningHigh,
                temperature_lethal_high: TemperatureLethalHigh,
                safe_elements: safe_elements,
                crop_id: crop_id,
                max_age: max_age,
                max_radiation: max_rad,
                baseTraitId: ID + "Original",
                baseTraitName: NAME);

            EntityTemplates.ExtendPlantToIrrigated(
                template: prefab,
                info:
                    new PlantElementAbsorber.ConsumeInfo()
                    {
                        tag = ElementLoader.FindElementByHash(hash).tag,
                        massConsumptionRate = FertilizationRate
                    });

            prefab.AddOrGet<StandardCropPlant>();

            var seed = EntityTemplates.CreateAndRegisterSeedForPlant(
                prefab,
                SeedProducer.ProductionType.Harvest,
                SEED_ID,
                SEED_NAME,
                SEED_DESC,
                Assets.GetAnim("seed_swampcrop_kanim"),
                additionalTags: new List<Tag> { GameTags.CropSeed },
                planterDirection: direction,
                sortOrder: 2,
                domesticatedDescription: DOMESTICATED_DESC);

            EntityTemplates.CreateAndRegisterPreviewForPlant(
                seed,
                "SwampHarvestPlant_preview",
                Assets.GetAnim("swampcrop_kanim"),
                "place",
                width: width,
                height: height);

            return prefab;
        }

        public void OnPrefabInit(GameObject inst)
        {
            inst.GetComponent<KBatchedAnimController>().randomiseLoopedOffset = true;
        }

        public void OnSpawn(GameObject inst)
        {

        }
    }
}
