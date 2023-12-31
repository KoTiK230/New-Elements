﻿using TUNING;
using UnityEngine;

namespace New_Elements
{
    class MolecularResearchCenterConfig : IBuildingConfig
    {
        public const string ID = "MolecularResearchCenter";
        public const float BASE_SECONDS_PER_POINT = 60f;
        public const float MASS_PER_POINT = 50f;
        public const float BASE_MASS_PER_SECOND = 0.8333333f;
        public const float CAPACITY = 750f;
        public static readonly Tag INPUT_MATERIAL = SimHashes.Phosphorus.CreateTag();

        public override BuildingDef CreateBuildingDef()
        {
            float[] tieR4 = BUILDINGS.CONSTRUCTION_MASS_KG.TIER4;
            string[] allMetals = MATERIALS.ALL_METALS;
            EffectorValues tieR1 = NOISE_POLLUTION.NOISY.TIER1;
            EffectorValues none = BUILDINGS.DECOR.NONE;
            EffectorValues noise = tieR1;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef("MolecularResearchCenter", 3, 3, "research_center2_kanim", 30, 30f, tieR4, allMetals, 1600f, BuildLocationRule.OnFloor, none, noise);
            buildingDef.RequiresPowerInput = true;
            buildingDef.EnergyConsumptionWhenActive = 120f;
            buildingDef.ExhaustKilowattsWhenActive = 0.5f;
            buildingDef.SelfHeatKilowattsWhenActive = 4f;
            buildingDef.ViewMode = OverlayModes.Power.ID;
            buildingDef.AudioCategory = "Metal";
            buildingDef.AudioSize = "large";
            return buildingDef;
        }

        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            go.GetComponent<KPrefabID>().AddTag(RoomConstraints.ConstraintTags.ScienceBuilding);
            go.AddOrGet<BuildingComplete>().isManuallyOperated = true;
            Prioritizable.AddRef(go);
            Storage storage = go.AddOrGet<Storage>();
            storage.capacityKg = 1000f;
            storage.showInUI = true;
            ManualDeliveryKG manualDeliveryKg = go.AddOrGet<ManualDeliveryKG>();
            manualDeliveryKg.SetStorage(storage);
            manualDeliveryKg.RequestedItemTag = MolecularResearchCenterConfig.INPUT_MATERIAL;
            manualDeliveryKg.refillMass = 150f;
            manualDeliveryKg.capacity = 750f;
            manualDeliveryKg.choreTypeIDHash = Db.Get().ChoreTypes.ResearchFetch.IdHash;
            ResearchCenter researchCenter = go.AddOrGet<ResearchCenter>();
            researchCenter.overrideAnims = new KAnimFile[1]
            {
      Assets.GetAnim((HashedString) "anim_interacts_research2_kanim")
            };
            researchCenter.research_point_type_id = "molecular";
            researchCenter.inputMaterial = MolecularResearchCenterConfig.INPUT_MATERIAL;
            researchCenter.mass_per_point = 50f;
            researchCenter.requiredSkillPerk = Db.Get().SkillPerks.AllowAdvancedResearch.Id;
            ElementConverter elementConverter = go.AddOrGet<ElementConverter>();
            elementConverter.consumedElements = new ElementConverter.ConsumedElement[1]
            {
      new ElementConverter.ConsumedElement(MolecularResearchCenterConfig.INPUT_MATERIAL, 0.8333333f)
            };
            elementConverter.showDescriptors = false;
            go.AddOrGetDef<PoweredController.Def>();
        }

        public override void DoPostConfigureComplete(GameObject go)
        {
        }
    }
}
