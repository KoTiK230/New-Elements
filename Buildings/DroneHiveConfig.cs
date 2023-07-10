/*using TUNING;
using UnityEngine;

public class DroneHiveConfig : IBuildingConfig
{
    public const string ID = "DroneBotHive";

    public override BuildingDef CreateBuildingDef()
    {
        string[] refinedMetals = MATERIALS.REFINED_METALS;
        EffectorValues none = NOISE_POLLUTION.NONE;
        EffectorValues tieR1 = BUILDINGS.DECOR.PENALTY.TIER1;
        EffectorValues noise = none;
        BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef("DroneBotHive", 2, 2, "sweep_bot_base_station_kanim", 30, 30f, BUILDINGS.CONSTRUCTION_MASS_KG.TIER3, refinedMetals, 1600f, BuildLocationRule.OnFloor, tieR1, noise, 0.2f);
        buildingDef.Floodable = false;
        buildingDef.AudioCategory = "Metal";
        buildingDef.Overheatable = false;
        buildingDef.RequiresPowerInput = true;
        buildingDef.EnergyConsumptionWhenActive = 240f;
        buildingDef.ExhaustKilowattsWhenActive = 0.0f;
        buildingDef.SelfHeatKilowattsWhenActive = 1f;
        return buildingDef;
    }

    public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
    {
        Prioritizable.AddRef(go);
        Storage storage1 = go.AddComponent<Storage>();
        storage1.showInUI = true;
        storage1.allowItemRemoval = false;
        storage1.ignoreSourcePriority = true;
        storage1.showDescriptor = true;
        storage1.storageFilters = STORAGEFILTERS.NOT_EDIBLE_SOLIDS;
        storage1.storageFullMargin = STORAGE.STORAGE_LOCKER_FILLED_MARGIN;
        storage1.fetchCategory = Storage.FetchCategory.Building;
        storage1.capacityKg = 500f;
        storage1.allowClearable = false;
        go.AddOrGet<CharacterOverlay>();
        go.AddOrGet<DroneHive>();
    }

    public override void DoPostConfigureComplete(GameObject go)
    {
        go.AddOrGetDef<StorageController.Def>();
    }
}
*/