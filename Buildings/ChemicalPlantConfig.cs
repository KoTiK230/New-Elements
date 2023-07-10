using System.Collections.Generic;
using TUNING;
using UnityEngine;
using New_Elements.Chemistry;
using KSerialization;
using NightLib;


namespace New_Elements.Buildings
{
    public class ChemicalPlantConfig : IBuildingConfig
    {
        public const string ID = "ChemicalPlant";
        private static void ConfigureRecipes() { }
        private static readonly PortDisplayInput inputPort0 = new PortDisplayInput(ConduitType.Liquid, new CellOffset(-1, 0));
        private static readonly PortDisplayOutput outputPort0 = new PortDisplayOutput(ConduitType.Gas, new CellOffset(1, 0));
        private static readonly PortDisplayOutput outputPort1 = new PortDisplayOutput(ConduitType.Liquid, new CellOffset(1, 0));
        private static readonly PortDisplayOutput[] outputPorts = { outputPort0, outputPort1 };
        private static readonly List<Storage.StoredItemModifier> ChemicalPlantStorageModifier;

        static ChemicalPlantConfig()
        {
            List<Storage.StoredItemModifier> list1 = new List<Storage.StoredItemModifier>();
            list1.Add(Storage.StoredItemModifier.Hide);
            list1.Add(Storage.StoredItemModifier.Preserve);
            list1.Add(Storage.StoredItemModifier.Insulate);
            list1.Add(Storage.StoredItemModifier.Seal);
            ChemicalPlantStorageModifier = list1;
        }

        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {

            go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.IndustrialMachinery);
            go.AddOrGet<BuildingComplete>().isManuallyOperated = false;
            go.AddOrGet<FabricatorIngredientStatusManager>();
            go.AddOrGet<CopyBuildingSettings>();

            ComplexFabricator fabricator = go.AddOrGet<ComplexFabricator>();
            fabricator.sideScreenStyle = ComplexFabricatorSideScreen.StyleSetting.ListQueueHybrid;
            fabricator.duplicantOperated = false;

            Storage standardStorage = go.AddOrGet<Storage>();
            standardStorage.capacityKg = 100f;

            BuildingTemplates.CreateComplexFabricatorStorage(go, fabricator);
            fabricator.inStorage.SetDefaultStoredItemModifiers(ChemicalPlantStorageModifier);
            fabricator.buildStorage.SetDefaultStoredItemModifiers(ChemicalPlantStorageModifier);
            fabricator.outStorage.SetDefaultStoredItemModifiers(ChemicalPlantStorageModifier);
            fabricator.storeProduced = true;
            fabricator.inStorage = standardStorage;

            PortConduitConsumer portConduitConsumer1 = go.AddComponent<PortConduitConsumer>();
            portConduitConsumer1.conduitType = ConduitType.Liquid;
            portConduitConsumer1.ignoreMinMassCheck = true;
            portConduitConsumer1.forceAlwaysSatisfied = true;
            portConduitConsumer1.storage = fabricator.inStorage;
            portConduitConsumer1.capacityKG = standardStorage.capacityKg;
            portConduitConsumer1.AssignPort(ChemicalPlantConfig.inputPort0);

            foreach (PortDisplayOutput port1 in outputPorts)
            {
                PortConduitDispenser dispenser = go.AddComponent<PortConduitDispenser>();
                dispenser.storage = fabricator.outStorage;
                dispenser.alwaysDispense = true;
                dispenser.alwaysDispense = true;
                dispenser.AssignPort(port1);
            }

            Prioritizable.AddRef(go);
            this.AttachPort(go);
        }
        private void AttachPort(GameObject go)
        {
            PortDisplayController displayController = go.AddComponent<PortDisplayController>();
            displayController.Init(go);
            displayController.AssignPort(go, (DisplayConduitPortInfo)ChemicalPlantConfig.outputPort0);
            displayController.AssignPort(go, (DisplayConduitPortInfo)ChemicalPlantConfig.outputPort1);
            displayController.AssignPort(go, (DisplayConduitPortInfo)ChemicalPlantConfig.inputPort0);
        }

        public override BuildingDef CreateBuildingDef()
        {
            EffectorValues tier = NOISE_POLLUTION.NOISY.TIER5;
            BuildingDef def1 = BuildingTemplates.CreateBuildingDef("ChemicalPlant", 3, 3, "fabricator_generic_kanim", 100, 30f, BUILDINGS.CONSTRUCTION_MASS_KG.TIER3, MATERIALS.REFINED_METALS, 800f, BuildLocationRule.OnFloor, BUILDINGS.DECOR.PENALTY.TIER1, tier, 0.2f);
            def1.Overheatable = false;
            def1.RequiresPowerInput = true;
            def1.EnergyConsumptionWhenActive = 800f;
            def1.ExhaustKilowattsWhenActive = 16f;
            def1.SelfHeatKilowattsWhenActive = 4f;
            def1.InputConduitType = ConduitType.Liquid;
            def1.OutputConduitType = ConduitType.Liquid;
            def1.OutputConduitType = ConduitType.Gas;
            def1.UtilityInputOffset = new CellOffset(-1, 0);
            def1.UtilityOutputOffset = new CellOffset(1, 0);
            def1.AudioCategory = "HollowMetal";
            def1.PowerInputOffset = new CellOffset(1, 0);
            return def1;
        }
        public override void DoPostConfigureComplete(GameObject go)
        {
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
