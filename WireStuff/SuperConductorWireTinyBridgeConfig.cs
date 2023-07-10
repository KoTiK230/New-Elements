using TUNING;
using UnityEngine;

namespace New_Elements
{
    class SuperConductorWireTinyBridgeConfig : WireBridgeConfig
    {
        public new const string ID = "SuperConductorWireTinyBridge";

        protected override string GetID() => "SuperConductorWireTinyBridge";

        public override BuildingDef CreateBuildingDef()
        {
            BuildingDef buildingDef = base.CreateBuildingDef();
            buildingDef.AnimFiles = new KAnimFile[1]
            {
        Assets.GetAnim((HashedString) "utilityelectricbridgeconductive_kanim")
            };
            buildingDef.Mass = WiresPatch.SUPERCONDUCTOR_WIRE_TINY_MASS_KG;
            buildingDef.MaterialCategory = WiresPatch.SUPERCONDUCTOR_WIRE_MATERIALS;
            GeneratedBuildings.RegisterWithOverlay(OverlayScreen.WireIDs, "SuperConductorWireTinyBridge");
            return buildingDef;
        }

        protected override WireUtilityNetworkLink AddNetworkLink(GameObject go)
        {
            WireUtilityNetworkLink utilityNetworkLink = base.AddNetworkLink(go);
            utilityNetworkLink.maxWattageRating = WiresPatch.WattageRating.Max10000.ToWireWattageRating();
            return utilityNetworkLink;
        }

        public override void DoPostConfigureUnderConstruction(GameObject go)
        {
            base.DoPostConfigureUnderConstruction(go);
            go.GetComponent<Constructable>().requiredSkillPerk = Db.Get().SkillPerks.CanPowerTinker.Id;
        }
    }
}
