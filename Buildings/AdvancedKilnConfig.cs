using System.Collections.Generic;
using TUNING;
using UnityEngine;
using New_Elements.Chemistry;


namespace New_Elements
{
public class AdvancedKilnConfig : IBuildingConfig
{

    public const string ID = "AdvancedKiln";
    private void ConfigureRecipes() { }
    private static readonly List<Storage.StoredItemModifier> KilnStorageModifier;

        static AdvancedKilnConfig()
    {
        List<Storage.StoredItemModifier> list1 = new List<Storage.StoredItemModifier>();
        list1.Add(Storage.StoredItemModifier.Hide);
        list1.Add(Storage.StoredItemModifier.Preserve);
        list1.Add(Storage.StoredItemModifier.Insulate);
        list1.Add(Storage.StoredItemModifier.Seal);
        KilnStorageModifier = list1;
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

            Storage standardStorage = go.AddOrGet<Storage>();
            standardStorage.capacityKg = 100f;

            BuildingTemplates.CreateComplexFabricatorStorage(go, fabricator);
            fabricator.inStorage.SetDefaultStoredItemModifiers(KilnStorageModifier);
            fabricator.buildStorage.SetDefaultStoredItemModifiers(KilnStorageModifier);
            fabricator.outStorage.SetDefaultStoredItemModifiers(KilnStorageModifier);
            fabricator.storeProduced = true;
            fabricator.inStorage = standardStorage;

            ConduitDispenser conduitDispenser = go.AddOrGet<ConduitDispenser>();
            conduitDispenser.conduitType = ConduitType.Gas;
            conduitDispenser.alwaysDispense = true;
            conduitDispenser.storage = go.GetComponent<ComplexFabricator>().outStorage;
            conduitDispenser.invertElementFilter = false;
            conduitDispenser.elementFilter = new SimHashes[] { SulfurTrioxideElement.SulfurTrioxideSimHash };
            Prioritizable.AddRef(go);
        }


        public override BuildingDef CreateBuildingDef()
    {
        EffectorValues tier = NOISE_POLLUTION.NOISY.TIER5;
        BuildingDef def1 = BuildingTemplates.CreateBuildingDef("AdvancedKiln", 3, 3, "fabricator_generic_kanim", 100, 30f, BUILDINGS.CONSTRUCTION_MASS_KG.TIER3, MATERIALS.REFINED_METALS, 800f, BuildLocationRule.OnFloor, BUILDINGS.DECOR.PENALTY.TIER1, tier, 0.2f);
        def1.Overheatable = false;
        def1.RequiresPowerInput = true;
        def1.EnergyConsumptionWhenActive = 800f;
        def1.ExhaustKilowattsWhenActive = 16f;
        def1.SelfHeatKilowattsWhenActive = 4f;
        def1.InputConduitType = ConduitType.Gas;
        def1.OutputConduitType = ConduitType.Gas;
        def1.UtilityInputOffset = new CellOffset(-1, 0);
        def1.UtilityOutputOffset = new CellOffset(1, 0);
            def1.AudioCategory = "HollowMetal";
        def1.PowerInputOffset = new CellOffset(1, 0);
        return def1;
    }

    public override void DoPostConfigureComplete(GameObject go)
    {
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
