using TUNING;
using UnityEngine;

namespace New_Elements
{
    class SuperConductorTransformerConfig : IBuildingConfig
    {
        public const string ID = "SuperConductorTransformer";

        public override BuildingDef CreateBuildingDef()
        {
            int hitpoints = 30;
            float construction_time = 30f;
            float[] construction_mass = new float[2]
            {
        BUILDINGS.CONSTRUCTION_MASS_KG.TIER4[0],
        BUILDINGS.CONSTRUCTION_MASS_KG.TIER2[0]
            };
            float melting_point = 800f;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef("SuperConductorTransformer", 3, 4, "transformer_kanim", hitpoints, construction_time, construction_mass, WiresPatch.SUPERCONDUCTOR_WIRE_MATERIALS, melting_point, BuildLocationRule.OnFloor, BUILDINGS.DECOR.PENALTY.TIER1, NOISE_POLLUTION.NOISY.TIER5);
            buildingDef.RequiresPowerInput = true;
            buildingDef.RequiresPowerOutput = true;
            buildingDef.UseWhitePowerOutputConnectorColour = true;
            buildingDef.PowerInputOffset = new CellOffset(0, 2);
            buildingDef.PowerOutputOffset = new CellOffset(0, 0);
            buildingDef.ElectricalArrowOffset = new CellOffset(1, 1);
            buildingDef.ViewMode = OverlayModes.Power.ID;
            buildingDef.AudioCategory = "Metal";
            buildingDef.ExhaustKilowattsWhenActive = 0.0f;
            buildingDef.SelfHeatKilowattsWhenActive = 1f;
            buildingDef.Entombable = true;
            buildingDef.GeneratorWattageRating = 100000f;
            buildingDef.GeneratorBaseCapacity = 100000f;
            buildingDef.PermittedRotations = PermittedRotations.FlipH;
            return buildingDef;
        }

        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.IndustrialMachinery);
            go.AddComponent<RequireInputs>();
            BuildingDef def = go.GetComponent<Building>().Def;
            Battery battery = go.AddOrGet<Battery>();
            battery.powerSortOrder = 1000;
            battery.capacity = def.GeneratorWattageRating;
            battery.chargeWattage = def.GeneratorWattageRating;
            go.AddComponent<PowerTransformer>().powerDistributionOrder = 9;
        }

        public override void DoPostConfigureComplete(GameObject go)
        {
            Object.DestroyImmediate((Object)go.GetComponent<EnergyConsumer>());
            go.AddOrGetDef<PoweredActiveController.Def>();
        }
    }
}
