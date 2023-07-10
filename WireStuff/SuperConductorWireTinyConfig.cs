using TUNING;
using UnityEngine;

namespace New_Elements
{
    class SuperConductorWireTinyConfig : BaseWireConfig
    {
        public const string ID = "SuperConductorWireTiny";

        public override BuildingDef CreateBuildingDef()
        {
            float[] jacketedWireMassKg = WiresPatch.SUPERCONDUCTOR_WIRE_TINY_MASS_KG;
            EffectorValues none1 = NOISE_POLLUTION.NONE;
            EffectorValues none2 = BUILDINGS.DECOR.NONE;
            EffectorValues noise = none1;
            BuildingDef buildingDef = this.CreateBuildingDef("SuperConductorWireTiny", "utilities_electric_conduct_kanim", 3f, jacketedWireMassKg, 0.05f, none2, noise);
            buildingDef.MaterialCategory = WiresPatch.SUPERCONDUCTOR_WIRE_MATERIALS;
            return buildingDef;
        }

        public override void DoPostConfigureComplete(GameObject go) => this.DoPostConfigureComplete(WiresPatch.WattageRating.Max10000.ToWireWattageRating(), go);

        public override void DoPostConfigureUnderConstruction(GameObject go)
        {
            base.DoPostConfigureUnderConstruction(go);
            go.GetComponent<Constructable>().requiredSkillPerk = Db.Get().SkillPerks.CanPowerTinker.Id;
        }
    }
}
