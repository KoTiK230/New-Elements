using TUNING;
using UnityEngine;

namespace New_Elements
{
    class SuperConductorWireThiccConfig : BaseWireConfig
    {
        public const string ID = "SuperConductorWireThicc";

        public override BuildingDef CreateBuildingDef()
        {
            float[] megawattWireMassKg = WiresPatch.SUPERCONDUCTOR_WIRE_THICC_MASS_KG;
            EffectorValues none = NOISE_POLLUTION.NONE;
            EffectorValues tieR3 = BUILDINGS.DECOR.PENALTY.TIER3;
            EffectorValues noise = none;
            BuildingDef buildingDef = this.CreateBuildingDef("SuperConductorWireThicc", "utilities_electric_conduct_hiwatt_kanim", 3f, megawattWireMassKg, 0.05f, tieR3, noise);
            buildingDef.MaterialCategory = WiresPatch.SUPERCONDUCTOR_WIRE_MATERIALS;
            buildingDef.BuildLocationRule = BuildLocationRule.NotInTiles;
            return buildingDef;
        }

        public override void DoPostConfigureComplete(GameObject go) => this.DoPostConfigureComplete(WiresPatch.WattageRating.Max500000.ToWireWattageRating(), go);

        public override void DoPostConfigureUnderConstruction(GameObject go)
        {
            base.DoPostConfigureUnderConstruction(go);
            go.GetComponent<Constructable>().requiredSkillPerk = Db.Get().SkillPerks.CanPowerTinker.Id;
        }
    }
}
