using System.Collections.Generic;
using TUNING;
using UnityEngine;
using New_Elements.Chemistry;
using NightLib;


namespace New_Elements.Buildings
{
    public class ParticleAcceleratorConfig : IBuildingConfig
    {

        public const string ID = "ParticleAccelerator";
        private void ConfigureRecipes()
        {
            ComplexRecipe.RecipeElement[] array = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(SimHashes.NuclearWaste.CreateTag(), 20f)
            };
            ComplexRecipe.RecipeElement[] array2 = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(PlutoniumElement.PlutoniumSimHash.CreateTag(), 30f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false)
            };
            string id = ComplexRecipeManager.MakeRecipeID("ParticleAccelerator", array, array2);
            ComplexRecipe complexRecipe = new ComplexRecipe(id, array, array2);
            complexRecipe.time = 10f;
            complexRecipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.Result;
            complexRecipe.description = string.Format(string.Concat(new string[]
            {
                "Refine ",SimHashes.Carbon.CreateTag().ProperName()," with intense heat, producing ",SimHashes.RefinedCarbon.CreateTag().ProperName(),"."}));
            complexRecipe.fabricators = new List<Tag>
            {
                TagManager.Create("ParticleAccelerator")
            };
        }
        private static readonly PortDisplayInput inputPort0 = new PortDisplayInput(ConduitType.Liquid, new CellOffset(-1, 0));
        private static readonly List<Storage.StoredItemModifier> ParticleAcceleratorStorageModifier;

        static ParticleAcceleratorConfig()
        {
            List<Storage.StoredItemModifier> list1 = new List<Storage.StoredItemModifier>();
            list1.Add(Storage.StoredItemModifier.Hide);
            list1.Add(Storage.StoredItemModifier.Preserve);
            list1.Add(Storage.StoredItemModifier.Insulate);
            list1.Add(Storage.StoredItemModifier.Seal);
            ParticleAcceleratorStorageModifier = list1;
        }
        public string GetDlcId() => "EXPANSION1_ID";
        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {

            go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.IndustrialMachinery, false);
            go.AddOrGet<BuildingComplete>().isManuallyOperated = false;
            go.AddOrGet<FabricatorIngredientStatusManager>();
            go.AddOrGet<CopyBuildingSettings>();

            ComplexFabricator fabricator = go.AddOrGet<ComplexFabricator>();
            fabricator.sideScreenStyle = ComplexFabricatorSideScreen.StyleSetting.ListQueueHybrid;
            fabricator.duplicantOperated = false;

            Storage standardStorage = go.AddOrGet<Storage>();
            standardStorage.capacityKg = 100f;

            BuildingTemplates.CreateComplexFabricatorStorage(go, fabricator);
            fabricator.inStorage.SetDefaultStoredItemModifiers(ParticleAcceleratorStorageModifier);
            fabricator.buildStorage.SetDefaultStoredItemModifiers(ParticleAcceleratorStorageModifier);
            fabricator.outStorage.SetDefaultStoredItemModifiers(ParticleAcceleratorStorageModifier);
            fabricator.inStorage = standardStorage;
            fabricator.outStorage.capacityKg = 100f;

            RadiationEmitter radiationEmitter = go.AddComponent<RadiationEmitter>();
            radiationEmitter.emitType = RadiationEmitter.RadiationEmitterType.Constant;
            radiationEmitter.emitRadiusX = (short)10;
            radiationEmitter.emitRadiusY = (short)10;
            radiationEmitter.emitRate= 150f;
            radiationEmitter.radiusProportionalToRads = false;
            radiationEmitter.emissionOffset = new Vector3(0.0f, 1f, 0.0f);

            PortConduitConsumer portConduitConsumer0 = go.AddComponent<PortConduitConsumer>();
            portConduitConsumer0.conduitType = ConduitType.Liquid;
            portConduitConsumer0.ignoreMinMassCheck = true;
            portConduitConsumer0.storage = fabricator.inStorage;
            portConduitConsumer0.capacityKG = standardStorage.capacityKg;
            portConduitConsumer0.AssignPort(ParticleAcceleratorConfig.inputPort0);
            this.AttachPort(go);
            this.ConfigureRecipes();
        }
        private void AttachPort(GameObject go)
        {
            PortDisplayController displayController = go.AddComponent<PortDisplayController>();
            displayController.Init(go);
            displayController.AssignPort(go, (DisplayConduitPortInfo)ParticleAcceleratorConfig.inputPort0);
        }

        public override BuildingDef CreateBuildingDef()
        {
            EffectorValues tier = NOISE_POLLUTION.NOISY.TIER5;
            BuildingDef def1 = BuildingTemplates.CreateBuildingDef("ParticleAccelerator", 3, 3, "fabricator_generic_kanim", 100, 30f, BUILDINGS.CONSTRUCTION_MASS_KG.TIER3, MATERIALS.REFINED_METALS, 800f, BuildLocationRule.OnFloor, BUILDINGS.DECOR.PENALTY.TIER1, tier, 0.2f);
            def1.Overheatable = false;
            def1.RequiresPowerInput = true;
            def1.EnergyConsumptionWhenActive = 800f;
            def1.ExhaustKilowattsWhenActive = 16f;
            def1.SelfHeatKilowattsWhenActive = 4f;
            def1.InputConduitType = ConduitType.Liquid;
            def1.UtilityInputOffset = new CellOffset(-1, 0);
            def1.AudioCategory = "HollowMetal";
            def1.PowerInputOffset = new CellOffset(1, 0);
            def1.Deprecated = !Sim.IsRadiationEnabled();
            return def1;
        }

        public override void DoPostConfigureComplete(GameObject go)
        {
            go.AddTag(GameTags.CorrosionProof);
            go.AddOrGetDef<PoweredActiveController.Def>().showWorkingStatus = true;
        }

        public override void DoPostConfigurePreview(BuildingDef def, GameObject go)
        {
            base.DoPostConfigurePreview(def, go);
        }

        public override void DoPostConfigureUnderConstruction(GameObject go)
        {
            base.DoPostConfigureUnderConstruction(go);
        }
    }

}
