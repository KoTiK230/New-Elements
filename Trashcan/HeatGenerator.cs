using TUNING;
using UnityEngine;
using NightLib;

namespace New_Elements
{
    class HeatGenerator : IBuildingConfig
    {
        public const string ID = "CoalHeatGenerator";

        public const float CONSUMPTION_RATE = 1f;
        public const float OUTPUT_GAS_RATE = 0.1f;
        public const float OUTPUT_TEMPERATURE = 432.15f;

        private static readonly PortDisplayOutput CarbonDioxideOutputPort = new PortDisplayOutput(ConduitType.Gas, new CellOffset(0, 4));

        public override BuildingDef CreateBuildingDef()
        {
            string[] construction_materials = new string[1]
    {
      SimHashes.Steel.ToString()
    };
            float[] tieR5_1 = BUILDINGS.CONSTRUCTION_MASS_KG.TIER5;
            EffectorValues tieR5_2 = NOISE_POLLUTION.NOISY.TIER5;
            EffectorValues tieR2 = BUILDINGS.DECOR.BONUS.TIER2;
            EffectorValues noise = tieR5_2;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef("CoalHeatGenerator", 3, 5, "massiveheatsink_kanim", 100, 120f, tieR5_1, construction_materials, 472.15f, BuildLocationRule.OnFloor, tieR2, noise);
            buildingDef.ExhaustKilowattsWhenActive = 1024f;
            buildingDef.SelfHeatKilowattsWhenActive = 32f;
            buildingDef.Floodable = true;
            buildingDef.Entombable = false;
            buildingDef.AudioCategory = "Metal";
            return buildingDef;
        }

        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            Storage storage = go.AddOrGet<Storage>();
            storage.capacityKg = 500f;

            ManualDeliveryKG manualDeliveryKg = go.AddOrGet<ManualDeliveryKG>();
            manualDeliveryKg.SetStorage(storage);
            manualDeliveryKg.RequestedItemTag = SimHashes.Carbon.CreateTag();
            manualDeliveryKg.capacity = storage.capacityKg;
            manualDeliveryKg.refillMass = 100f;
            manualDeliveryKg.choreTypeIDHash = Db.Get().ChoreTypes.FetchCritical.IdHash;

            ElementConverter elementConverter = go.AddOrGet<ElementConverter>();

            elementConverter.consumedElements = new ElementConverter.ConsumedElement[]
            {
                new ElementConverter.ConsumedElement(SimHashes.Carbon.CreateTag(), 1f)
            };

            elementConverter.outputElements = new ElementConverter.OutputElement[]
            {
                new ElementConverter.OutputElement(0.1f, SimHashes.CarbonDioxide, 432.15f, false, true, 0f, 4f, 0f, byte.MaxValue, 0)
            };

            PipedDispenser dispenser = go.AddComponent<PipedDispenser>();
            dispenser.elementFilter = new SimHashes[] { SimHashes.CarbonDioxide };
            dispenser.AssignPort(CarbonDioxideOutputPort);
            dispenser.alwaysDispense = true;
            dispenser.SkipSetOperational = true;

            PipedOptionalExhaust exhaust = go.AddComponent<PipedOptionalExhaust>();
            exhaust.dispenser = dispenser;
            exhaust.elementHash = SimHashes.CarbonDioxide;
            exhaust.elementTag = SimHashes.CarbonDioxide.CreateTag();
            exhaust.capacity = 0.2f;

            Prioritizable.AddRef(go);

            SpaceHeater spaceHeater = go.AddOrGet<SpaceHeater>();
            spaceHeater.radius = 7;
            spaceHeater.targetTemperature = 312.15f;
            this.AttachPort(go);
        }
        private void AttachPort(GameObject go)
        {
            PortDisplayController controller = go.AddComponent<PortDisplayController>();
            controller.Init(go);

            controller.AssignPort(go, CarbonDioxideOutputPort);
        }
        public override void DoPostConfigureComplete(GameObject go)
        {
            go.AddOrGetDef<PoweredActiveController.Def>().showWorkingStatus = true;
            PrimaryElement component = go.GetComponent<PrimaryElement>();
            component.SetElement(SimHashes.Steel);
            component.Temperature = 240.15f;
            //go.AddOrGet<LogicOperationalController>();
            go.AddOrGet<LoopingSounds>();
        }

        public override void DoPostConfigurePreview(BuildingDef def, GameObject go)
        {
            this.AttachPort(go);
        }

        public override void DoPostConfigureUnderConstruction(GameObject go)
        {
            this.AttachPort(go);
        }
    }
}