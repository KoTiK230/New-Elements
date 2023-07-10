using TUNING;
using UnityEngine;

namespace New_Elements
{
    class AccumulatorModuleConfig : IBuildingConfig
    {
        public const string ID = "AccumulatorModule";
        public const float NUM_CAPSULES = 3f;
        private static readonly CellOffset PLUG_OFFSET = new CellOffset(-1, 0);

        public override string[] GetDlcIds() => DlcManager.AVAILABLE_EXPANSION1_ONLY;

        public override BuildingDef CreateBuildingDef()
        {
            var biba = AccumulatorEntityConfig.tag.ToString();
            float[] construction_mass = new float[2]
            {
      BUILDINGS.CONSTRUCTION_MASS_KG.TIER5[0],
      10f
            };
            string[] strArray = new string[2]
            {
      "RefinedMetal",
      biba
            };
            EffectorValues tieR2 = NOISE_POLLUTION.NOISY.TIER2;
            EffectorValues none = BUILDINGS.DECOR.NONE;
            EffectorValues noise = tieR2;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef("AccumulatorModule", 3, 2, "rocket_battery_pack_kanim", 1000, 30f, construction_mass, strArray, 9999f, BuildLocationRule.Anywhere, none, noise);
            BuildingTemplates.CreateRocketBuildingDef(buildingDef);
            buildingDef.DefaultAnimState = "grounded";
            buildingDef.AttachmentSlotTag = GameTags.Rocket;
            buildingDef.SceneLayer = Grid.SceneLayer.Building;
            buildingDef.ForegroundLayer = Grid.SceneLayer.Front;
            buildingDef.OverheatTemperature = 2273.15f;
            buildingDef.Floodable = false;
            buildingDef.PowerInputOffset = AccumulatorModuleConfig.PLUG_OFFSET;
            buildingDef.PowerOutputOffset = AccumulatorModuleConfig.PLUG_OFFSET;
            buildingDef.ObjectLayer = ObjectLayer.Building;
            buildingDef.RequiresPowerOutput = true;
            buildingDef.UseWhitePowerOutputConnectorColour = true;
            buildingDef.CanMove = true;
            buildingDef.Cancellable = false;
            return buildingDef;
        }

        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            BuildingConfigManager.Instance.IgnoreDefaultKComponent(typeof(RequiresFoundation), prefab_tag);
            go.AddOrGet<LoopingSounds>();
            go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.IndustrialMachinery);
            go.AddComponent<RequireInputs>();
            go.AddOrGet<BuildingAttachPoint>().points = new BuildingAttachPoint.HardPoint[1]
            {
      new BuildingAttachPoint.HardPoint(new CellOffset(0, 2), GameTags.Rocket, (AttachableBuilding) null)
            };
        }

        public override void DoPostConfigureComplete(GameObject go)
        {
            Prioritizable.AddRef(go);
            ModuleBattery moduleBattery = go.AddOrGet<ModuleBattery>();
            moduleBattery.capacity = 500000f;
            moduleBattery.joulesLostPerSecond = 0.6666667f;
            WireUtilitySemiVirtualNetworkLink virtualNetworkLink = go.AddOrGet<WireUtilitySemiVirtualNetworkLink>();
            virtualNetworkLink.link1 = AccumulatorModuleConfig.PLUG_OFFSET;
            virtualNetworkLink.visualizeOnly = true;
            BuildingTemplates.ExtendBuildingToRocketModuleCluster(go, (string)null, ROCKETRY.BURDEN.MINOR);
        }
    }
}
