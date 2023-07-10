using System.Collections.Generic;
using TUNING;
using UnityEngine;

namespace New_Elements
{
    class HighTempSteamTurbineConfig : IBuildingConfig
    {
        public const string ID = "HighTempSteamTurbine";
        public static float MAX_WATTAGE = 2000f;
        private const int HEIGHT = 3;
        private const int WIDTH = 5;
        private static readonly List<Storage.StoredItemModifier> StoredItemModifiers = new List<Storage.StoredItemModifier>()
  {
    Storage.StoredItemModifier.Hide,
    Storage.StoredItemModifier.Insulate,
    Storage.StoredItemModifier.Seal
  };

        public override BuildingDef CreateBuildingDef()
        {
            string boba = KatheriumChipConfig.tag.ToString();
            string[] strArray = new string[3]
            {
      "RefinedMetal",
      "Plastic",
      boba
            };
            float[] construction_mass = new float[3]
            {
      BUILDINGS.CONSTRUCTION_MASS_KG.TIER5[0],
      BUILDINGS.CONSTRUCTION_MASS_KG.TIER3[0],
      10f
            };
            string[] construction_materials = strArray;
            EffectorValues none1 = NOISE_POLLUTION.NONE;
            EffectorValues none2 = BUILDINGS.DECOR.NONE;
            EffectorValues noise = none1;
            BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef("HighTempSteamTurbine", 5, 3, "steamturbine2_kanim", 30, 60f, construction_mass, construction_materials, 1600f, BuildLocationRule.OnFloor, none2, noise, 1f);
            buildingDef.OutputConduitType = ConduitType.Gas;
            buildingDef.UtilityOutputOffset = new CellOffset(2, 2);
            buildingDef.GeneratorWattageRating = HighTempSteamTurbineConfig.MAX_WATTAGE;
            buildingDef.GeneratorBaseCapacity = HighTempSteamTurbineConfig.MAX_WATTAGE;
            buildingDef.Entombable = true;
            buildingDef.IsFoundation = false;
            buildingDef.PermittedRotations = PermittedRotations.FlipH;
            buildingDef.ViewMode = OverlayModes.Power.ID;
            buildingDef.AudioCategory = "Metal";
            buildingDef.RequiresPowerOutput = true;
            buildingDef.PowerOutputOffset = new CellOffset(1, 0);
            buildingDef.OverheatTemperature = 1273.15f;
            buildingDef.SelfHeatKilowattsWhenActive = 4f;
            buildingDef.LogicInputPorts = LogicOperationalController.CreateSingleInputPortList(new CellOffset(0, 0));
            return buildingDef;
        }

        public override void DoPostConfigureUnderConstruction(GameObject go)
        {
            base.DoPostConfigureUnderConstruction(go);
            go.GetComponent<Constructable>().requiredSkillPerk = Db.Get().SkillPerks.CanPowerTinker.Id;
        }

        public override void DoPostConfigureComplete(GameObject go)
        {
            Storage storage1 = go.AddComponent<Storage>();
            storage1.showDescriptor = false;
            storage1.showInUI = false;
            storage1.storageFilters = STORAGEFILTERS.LIQUIDS;
            storage1.SetDefaultStoredItemModifiers(HighTempSteamTurbineConfig.StoredItemModifiers);
            storage1.capacityKg = 10f;
            Storage storage2 = go.AddComponent<Storage>();
            storage2.showDescriptor = false;
            storage2.showInUI = false;
            storage2.storageFilters = STORAGEFILTERS.GASES;
            storage2.SetDefaultStoredItemModifiers(HighTempSteamTurbineConfig.StoredItemModifiers);
            SteamTurbine steamTurbine = go.AddOrGet<SteamTurbine>();
            steamTurbine.minActiveTemperature = 523.15f;
            steamTurbine.idealSourceElementTemperature = 773.15f;
            steamTurbine.outputElementTemperature = 493.15f;
            steamTurbine.srcElem = SimHashes.Steam;
            steamTurbine.destElem = SimHashes.Steam;
            steamTurbine.pumpKGRate = 1f;
            steamTurbine.maxSelfHeat = 64f;
            steamTurbine.wasteHeatToTurbinePercent = 0.2f;
            ConduitDispenser conduitDispenser = go.AddOrGet<ConduitDispenser>();
            conduitDispenser.elementFilter = new SimHashes[1]
            {
      SimHashes.Steam
            };
            conduitDispenser.conduitType = ConduitType.Gas;
            conduitDispenser.storage = storage1;
            conduitDispenser.alwaysDispense = true;
            go.AddOrGet<LogicOperationalController>();
            Prioritizable.AddRef(go);
            go.GetComponent<KPrefabID>().prefabSpawnFn += (KPrefabID.PrefabFn)(game_object =>
            {
                HandleVector<int>.Handle handle = GameComps.StructureTemperatures.GetHandle(game_object);
                StructureTemperaturePayload payload = GameComps.StructureTemperatures.GetPayload(handle);
                Extents extents = game_object.GetComponent<Building>().GetExtents();
                Extents newExtents = new Extents(extents.x, extents.y - 1, extents.width, extents.height + 1);
                payload.OverrideExtents(newExtents);
                GameComps.StructureTemperatures.SetPayload(handle, ref payload);
                Storage[] components = game_object.GetComponents<Storage>();
                game_object.GetComponent<SteamTurbine>().SetStorage(components[1], components[0]);
            });
            Tinkerable.MakePowerTinkerable(go);
        }
    }
}
