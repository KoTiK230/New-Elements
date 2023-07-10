using TUNING;
using UnityEngine;

namespace New_Elements
{
    class SuperConductorWireThiccBridgeConfig : WireBridgeHighWattageConfig
    {
        public new const string ID = "SuperConductorWireThiccBridge";

        protected override string GetID() => "SuperConductorWireThiccBridge";

        public override BuildingDef CreateBuildingDef()
        {
            BuildingDef buildingDef = base.CreateBuildingDef();
            buildingDef.AnimFiles = new KAnimFile[1]
            {
        Assets.GetAnim((HashedString) "heavywatttile_conductive_kanim")
            };
            buildingDef.Mass = WiresPatch.SUPERCONDUCTOR_WIRE_THICC_MASS_KG;
            buildingDef.MaterialCategory = WiresPatch.SUPERCONDUCTOR_WIRE_MATERIALS;
            buildingDef.SceneLayer = Grid.SceneLayer.WireBridges;
            buildingDef.ForegroundLayer = Grid.SceneLayer.TileMain;
            GeneratedBuildings.RegisterWithOverlay(OverlayScreen.WireIDs, "SuperConductorWireThiccBridge");
            return buildingDef;
        }

        protected override WireUtilityNetworkLink AddNetworkLink(GameObject go)
        {
            WireUtilityNetworkLink utilityNetworkLink = base.AddNetworkLink(go);
            utilityNetworkLink.maxWattageRating = WiresPatch.WattageRating.Max500000.ToWireWattageRating();
            return utilityNetworkLink;
        }

        public override void DoPostConfigureUnderConstruction(GameObject go)
        {
            base.DoPostConfigureUnderConstruction(go);
            go.GetComponent<Constructable>().requiredSkillPerk = Db.Get().SkillPerks.CanPowerTinker.Id;
        }
    }
}
