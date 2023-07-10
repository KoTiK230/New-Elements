using System.Collections.Generic;
using TUNING;
using UnityEngine;
using New_Elements.Chemistry;
using KSerialization;
using NightLib;


namespace New_Elements.Buildings
{
    public class MixerConfig : IBuildingConfig
    {
        public const string ID = "Mixer";
        private void ConfigureRecipes() { }
        private static readonly PortDisplayInput inputPort0 = new PortDisplayInput(ConduitType.Liquid, new CellOffset(-1, 0));
        private static readonly PortDisplayInput inputPort1 = new PortDisplayInput(ConduitType.Liquid, new CellOffset(-1, 2));
        private static readonly PortDisplayInput inputPort2 = new PortDisplayInput(ConduitType.Gas, new CellOffset(-1, 0));
        private static readonly PortDisplayInput inputPort3 = new PortDisplayInput(ConduitType.Gas, new CellOffset(-1, 2));
        private static readonly PortDisplayOutput outputPort0 = new PortDisplayOutput(ConduitType.Gas, new CellOffset(1, 0));
        private static readonly PortDisplayOutput outputPort1 = new PortDisplayOutput(ConduitType.Liquid, new CellOffset(1, 0));

        private static readonly PortDisplayInput[] inputPorts = { inputPort0, inputPort1, inputPort2, inputPort3 };
        private static readonly PortDisplayOutput[] outputPorts = { outputPort0, outputPort1 };

        private static readonly List<Storage.StoredItemModifier> MixerStorageModifier;

        static MixerConfig()
        {
            List<Storage.StoredItemModifier> list1 = new List<Storage.StoredItemModifier>();
            list1.Add(Storage.StoredItemModifier.Hide);
            list1.Add(Storage.StoredItemModifier.Preserve);
            list1.Add(Storage.StoredItemModifier.Insulate);
            list1.Add(Storage.StoredItemModifier.Seal);
            MixerStorageModifier = list1;
        }
        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {

            go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.IndustrialMachinery, false);
            go.AddOrGet<BuildingComplete>().isManuallyOperated = false;
            go.AddOrGet<FabricatorIngredientStatusManager>();
            go.AddOrGet<CopyBuildingSettings>();

            ComplexFabricator fabricator = go.AddOrGet<ComplexFabricator>();
            fabricator.sideScreenStyle = ComplexFabricatorSideScreen.StyleSetting.ListQueueHybrid;
            fabricator.duplicantOperated = false;

            Storage Storage0 = go.AddOrGet<Storage>();
            Storage0.capacityKg = 500f;

            BuildingTemplates.CreateComplexFabricatorStorage(go, fabricator);
            fabricator.inStorage.SetDefaultStoredItemModifiers(MixerStorageModifier);
            fabricator.buildStorage.SetDefaultStoredItemModifiers(MixerStorageModifier);
            fabricator.outStorage.SetDefaultStoredItemModifiers(MixerStorageModifier);
            fabricator.storeProduced = true;
            fabricator.inStorage = Storage0;
            fabricator.outStorage.capacityKg = 500f;

            foreach (PortDisplayInput port in inputPorts)
            {
                PortConduitConsumer consumer = go.AddComponent<PortConduitConsumer>();
                consumer.ignoreMinMassCheck = true;
                consumer.alwaysConsume = true;
                consumer.storage = fabricator.inStorage;
                consumer.AssignPort(port);
            }

            foreach (PortDisplayOutput port1 in outputPorts)
            {
                PortConduitDispenser dispenser = go.AddComponent<Fabricator_PortConduitDispenser>();
                dispenser.storage = fabricator.outStorage;
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
            displayController.AssignPort(go, (DisplayConduitPortInfo)MixerConfig.outputPort0);
            displayController.AssignPort(go, (DisplayConduitPortInfo)MixerConfig.outputPort1);
            displayController.AssignPort(go, (DisplayConduitPortInfo)MixerConfig.inputPort0);
            displayController.AssignPort(go, (DisplayConduitPortInfo)MixerConfig.inputPort1);
            displayController.AssignPort(go, (DisplayConduitPortInfo)MixerConfig.inputPort2);
            displayController.AssignPort(go, (DisplayConduitPortInfo)MixerConfig.inputPort3);
        }


        public override BuildingDef CreateBuildingDef()
        {
            EffectorValues tier = NOISE_POLLUTION.NOISY.TIER5;
            BuildingDef def1 = BuildingTemplates.CreateBuildingDef("Mixer", 3, 3, "fabricator_generic_kanim", 100, 30f, BUILDINGS.CONSTRUCTION_MASS_KG.TIER3, MATERIALS.REFINED_METALS, 800f, BuildLocationRule.OnFloor, BUILDINGS.DECOR.PENALTY.TIER1, tier, 0.2f);
            def1.Overheatable = false;
            def1.RequiresPowerInput = true;
            def1.EnergyConsumptionWhenActive = 800f;
            def1.ExhaustKilowattsWhenActive = 16f;
            def1.SelfHeatKilowattsWhenActive = 4f;
            def1.InputConduitType = ConduitType.Liquid;
            def1.InputConduitType = ConduitType.Gas;
            def1.OutputConduitType = ConduitType.Liquid; 
            def1.OutputConduitType = ConduitType.Gas;
            def1.UtilityInputOffset = new CellOffset(-1, 0);
            def1.UtilityInputOffset = new CellOffset(-1, 2);
            def1.UtilityOutputOffset = new CellOffset(1, 0);
            def1.AudioCategory = "HollowMetal";
            def1.PowerInputOffset = new CellOffset(1, 0);
            return def1;
        }


        public override void DoPostConfigureComplete(GameObject go)
        {
            Prioritizable.AddRef(go);
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

