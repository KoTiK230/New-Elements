using TUNING;
using UnityEngine;
using NightLib;

namespace New_Elements
{
    class SolidMinerMK1 : IBuildingConfig
    {
        [MyCmpGet] public AttachableBuilding attatchableBuilding;
        private const float WATER_INTAKE_RATE = 2f;
        private const float WATER_TO_OIL_RATIO = 2.5f;
        private const float LIQUID_STORAGE = 10f;
        private static readonly PortDisplayOutput OilGasOutputPort = new PortDisplayOutput(ConduitType.Gas, new CellOffset(0, 4));
        private static readonly PortDisplayOutput CrudeOilOutputPort = new PortDisplayOutput(ConduitType.Liquid, new CellOffset(1, 2));
        private static readonly PortDisplayOutput[] outputPorts = { OilGasOutputPort, CrudeOilOutputPort };
        public const string ID = "AdvancedOilWellCap";

        public override BuildingDef CreateBuildingDef()
        {
            float[] tieR3 = BUILDINGS.CONSTRUCTION_MASS_KG.TIER3;
            string[] refinedMetals = MATERIALS.REFINED_METALS;
            EffectorValues tieR2 = NOISE_POLLUTION.NOISY.TIER2;
            EffectorValues none = BUILDINGS.DECOR.NONE;
            EffectorValues noise = tieR2;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef("AdvancedOilWellCap", 4, 4, "geyser_oil_cap_kanim", 100, 120f, tieR3, refinedMetals, 1600f, BuildLocationRule.OnFloor, none, noise);
            BuildingTemplates.CreateElectricalBuildingDef(buildingDef);
            buildingDef.SceneLayer = Grid.SceneLayer.BuildingFront;
            buildingDef.ViewMode = OverlayModes.LiquidConduits.ID;
            buildingDef.EnergyConsumptionWhenActive = 480f;
            buildingDef.SelfHeatKilowattsWhenActive = 2f;
            buildingDef.InputConduitType = ConduitType.Liquid;
            buildingDef.UtilityInputOffset = new CellOffset(0, 1);
            buildingDef.PowerInputOffset = new CellOffset(1, 1);
            buildingDef.OverheatTemperature = 2273.15f;
            buildingDef.Floodable = false;
            buildingDef.LogicInputPorts = LogicOperationalController.CreateSingleInputPortList(new CellOffset(0, 0));
            buildingDef.AttachmentSlotTag = GameTags.OilWell;
            buildingDef.BuildLocationRule = BuildLocationRule.BuildingAttachPoint;
            buildingDef.ObjectLayer = ObjectLayer.AttachableBuilding;
            return buildingDef;
        }
        private void AttachPort(GameObject go)
        {
            PortDisplayController displayController = go.AddComponent<PortDisplayController>();
            displayController.Init(go);
            displayController.AssignPort(go, (DisplayConduitPortInfo)AdvancedOilWellCapConfig.CrudeOilOutputPort);
            displayController.AssignPort(go, (DisplayConduitPortInfo)AdvancedOilWellCapConfig.OilGasOutputPort);
        }


        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.AddOrGet<LoopingSounds>();
            BuildingTemplates.CreateDefaultStorage(go).showInUI = true;
            Storage standardStorage = go.AddOrGet<Storage>();
            standardStorage.capacityKg = 100f;
            ConduitConsumer conduitConsumer = go.AddOrGet<ConduitConsumer>();
            conduitConsumer.conduitType = ConduitType.Liquid;
            conduitConsumer.consumptionRate = 2f;
            conduitConsumer.capacityKG = 10f;
            conduitConsumer.forceAlwaysSatisfied = true;
            conduitConsumer.capacityTag = SimHashes.Water.CreateTag();
            conduitConsumer.wrongElementResult = ConduitConsumer.WrongElementResult.Dump;
            ElementConverter elementConverter = go.AddOrGet<ElementConverter>();
            elementConverter.consumedElements = new ElementConverter.ConsumedElement[1]
            {
      new ElementConverter.ConsumedElement(SimHashes.Water.CreateTag(), 2f, isActive: true)
            };
            elementConverter.outputElements = new ElementConverter.OutputElement[2]
            {
      new ElementConverter.OutputElement(5f, SimHashes.CrudeOil, 363.15f, storeOutput: true, diseaseWeight: 0.0f),
      new ElementConverter.OutputElement(0.3f, SimHashes.SourGas, 363.15f, storeOutput: true, diseaseWeight: 0.0f)
            };
            foreach (PortDisplayOutput port1 in outputPorts)
            {
                PortConduitDispenser dispenser = go.AddComponent<PortConduitDispenser>();
                dispenser.alwaysDispense = true;
                dispenser.invertElementFilter = true;
                dispenser.storage = standardStorage;
                dispenser.elementFilter = new SimHashes[1]
                    { SimHashes.Water };
                dispenser.AssignPort(port1);
            }
            this.AttachPort(go);
        }

        public override void DoPostConfigureComplete(GameObject go) => go.AddOrGet<LogicOperationalController>();
    }
}
