using System.Collections.Generic;
using STRINGS;
using UnityEngine;

namespace New_Elements
{
    class BabanaPalmConfig : IEntityConfig
    {
        public const string ID = "BabanaPalm";
        public const string SEED_ID = "BabanaPalmSeed";

        public static string NAME = UI.FormatAsLink("Babana Palm", ID.ToUpper());
        public static string DESC = $"A hardy {UI.FormatAsLink("fern", "PLANTS")} that thrives on the geothermal heat produced by magma.";
        public static string DOMESTICATED_DESC = $"This {UI.FormatAsLink("fern", "PLANTS")} produces edible spores that may be processed into high-calorie {UI.FormatAsLink("Food", "FOOD")}.";

        public static string SEED_NAME = UI.FormatAsLink("Babana Palm Seed", ID.ToUpper());
        public static string SEED_DESC = $"An incredibly energy dense spore of a {NAME}";

        public string[] GetDlcIds() => DlcManager.AVAILABLE_EXPANSION1_ONLY;

        public const float DefaultTemperature = 423.15f;
        public const float TemperatureLethalLow = 373.15f;
        public const float TemperatureWarningLow = 373.15f;
        public const float TemperatureWarningHigh = 573.15f;
        public const float TemperatureLethalHigh = 573.15f;
        public static string crop_id = BabanaFruitConfig.ID;
        SimHashes[] safe_elements = { SimHashes.Steam, SimHashes.Fallout, SimHashes.CarbonDioxide, SimHashes.NuclearWaste };
        public const float FertilizationRate = 1f;

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
                1,
                3,
                TUNING.DECOR.BONUS.TIER1,
                defaultTemperature: DefaultTemperature);

            EntityTemplates.ExtendEntityToBasicPlant(
                prefab,
                temperature_lethal_low: TemperatureLethalLow,
                temperature_warning_low: TemperatureWarningLow,
                temperature_warning_high: TemperatureWarningHigh,
                temperature_lethal_high: TemperatureLethalHigh,
                safe_elements: safe_elements,
                crop_id: crop_id,
                max_radiation: TUNING.PLANTS.RADIATION_THRESHOLDS.TIER_3,
                baseTraitId: ID + "Original",
                baseTraitName: NAME);

            EntityTemplates.ExtendPlantToFertilizable(
                template: prefab,
                fertilizers: new[]
                {
                    new PlantElementAbsorber.ConsumeInfo()
                    {
                        tag = ElementLoader.FindElementByHash(SimHashes.Radium).tag,
                        massConsumptionRate = FertilizationRate
                    }
                });

            RadiationEmitter radiationEmitter = prefab.AddComponent<RadiationEmitter>();
            radiationEmitter.emitType = RadiationEmitter.RadiationEmitterType.Constant;
            radiationEmitter.radiusProportionalToRads = false;
            radiationEmitter.emitRadiusX = (short)3;
            radiationEmitter.emitRadiusY = radiationEmitter.emitRadiusX;
            radiationEmitter.emitRads = 50f;
            radiationEmitter.emissionOffset = new Vector3(0.0f, 2.0f, 0.0f);

            prefab.AddOrGet<StandardCropPlant>();

            var seed = EntityTemplates.CreateAndRegisterSeedForPlant(
                prefab,
                SeedProducer.ProductionType.Harvest,
                SEED_ID,
                SEED_NAME,
                SEED_DESC,
                Assets.GetAnim("seed_swampcrop_kanim"),
                additionalTags: new List<Tag> { GameTags.CropSeed },
                sortOrder: 2,
                domesticatedDescription: DOMESTICATED_DESC);

            EntityTemplates.CreateAndRegisterPreviewForPlant(
                seed,
                "SwampHarvestPlant_preview",
                Assets.GetAnim("swampcrop_kanim"),
                "place",
                1,
                3);

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
