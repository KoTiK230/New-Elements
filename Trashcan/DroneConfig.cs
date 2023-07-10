using Klei.AI;
using System.Collections.Generic;
using UnityEngine;

namespace New_Elements
{
    class DroneConfig
    {
        public const string ID = "DroneBot";
        public static string DRONE_BASE_TRAIT_ID = "DroneBotBaseTrait";
        public const int MAXIMUM_TECH_CONSTRUCTION_TIER = 1;
        public const float MASS = 100f;
        private const float WIDTH = 1f;
        private const float HEIGHT = 1f;

        public static GameObject CreateDrone(
          string id,
          string name,
          string desc,
          string anim_file)
        {
            GameObject basicEntity = EntityTemplates.CreateBasicEntity(id, name, desc, 100f, true, Assets.GetAnim((HashedString)anim_file), "idle_loop", Grid.SceneLayer.Creatures);
            KBatchedAnimController component1 = basicEntity.GetComponent<KBatchedAnimController>();
            component1.isMovable = true;
            basicEntity.AddOrGet<Modifiers>();
            basicEntity.AddOrGet<LoopingSounds>();
            KBoxCollider2D kboxCollider2D = basicEntity.AddOrGet<KBoxCollider2D>();
            kboxCollider2D.size = new Vector2(1f, 1f);
            kboxCollider2D.offset = (Vector2)new Vector2f(0.0f, 1f);
            Modifiers component2 = basicEntity.GetComponent<Modifiers>();
            component2.initialAmounts.Add(Db.Get().Amounts.HitPoints.Id);
            component2.initialAmounts.Add(Db.Get().Amounts.InternalChemicalBattery.Id);
            component2.initialAttributes.Add(Db.Get().Attributes.Construction.Id);
            component2.initialAttributes.Add(Db.Get().Attributes.Digging.Id);
            component2.initialAttributes.Add(Db.Get().Attributes.CarryAmount.Id);
            component2.initialAttributes.Add(Db.Get().Attributes.Machinery.Id);
            component2.initialAttributes.Add(Db.Get().Attributes.Athletics.Id);
            ChoreGroup[] disabled_chore_groups = new ChoreGroup[12]
            {
      Db.Get().ChoreGroups.Basekeeping,
      Db.Get().ChoreGroups.Cook,
      Db.Get().ChoreGroups.Art,
      Db.Get().ChoreGroups.Research,
      Db.Get().ChoreGroups.Farming,
      Db.Get().ChoreGroups.Ranching,
      Db.Get().ChoreGroups.MachineOperating,
      Db.Get().ChoreGroups.MedicalAid,
      Db.Get().ChoreGroups.Combat,
      Db.Get().ChoreGroups.LifeSupport,
      Db.Get().ChoreGroups.Recreation,
      Db.Get().ChoreGroups.Toggle
            };
            basicEntity.AddOrGet<Traits>();
            Trait trait = Db.Get().CreateTrait(DroneConfig.DRONE_BASE_TRAIT_ID, (string)STRINGS.ROBOTS.MODELS.SCOUT.NAME, (string)STRINGS.ROBOTS.MODELS.SCOUT.NAME, (string)null, false, disabled_chore_groups, true, true);
            trait.Add(new AttributeModifier(Db.Get().Attributes.CarryAmount.Id, 200f, (string)STRINGS.ROBOTS.MODELS.SCOUT.NAME));
            trait.Add(new AttributeModifier(Db.Get().Attributes.Digging.Id, TUNING.ROBOTS.SCOUTBOT.DIGGING, (string)STRINGS.ROBOTS.MODELS.SCOUT.NAME));
            trait.Add(new AttributeModifier(Db.Get().Attributes.Construction.Id, TUNING.ROBOTS.SCOUTBOT.CONSTRUCTION, (string)STRINGS.ROBOTS.MODELS.SCOUT.NAME));
            trait.Add(new AttributeModifier(Db.Get().Attributes.Athletics.Id, TUNING.ROBOTS.SCOUTBOT.ATHLETICS, (string)STRINGS.ROBOTS.MODELS.SCOUT.NAME));
            trait.Add(new AttributeModifier(Db.Get().Amounts.HitPoints.maxAttribute.Id, TUNING.ROBOTS.SCOUTBOT.HIT_POINTS, (string)STRINGS.ROBOTS.MODELS.SCOUT.NAME));
            trait.Add(new AttributeModifier(Db.Get().Amounts.InternalChemicalBattery.maxAttribute.Id, TUNING.ROBOTS.SCOUTBOT.BATTERY_CAPACITY, name));
            trait.Add(new AttributeModifier(Db.Get().Amounts.InternalChemicalBattery.deltaAttribute.Id, -TUNING.ROBOTS.SCOUTBOT.BATTERY_DEPLETION_RATE, name));
            component2.initialTraits.Add(DroneConfig.DRONE_BASE_TRAIT_ID);
            basicEntity.AddOrGet<AttributeConverters>();
            basicEntity.AddOrGet<AttributeLevels>();
            GridVisibility gridVisibility = basicEntity.AddOrGet<GridVisibility>();
            gridVisibility.radius = 30;
            gridVisibility.innerRadius = 20f;
            basicEntity.AddOrGet<Worker>();
            basicEntity.AddOrGet<Effects>();
            basicEntity.AddOrGet<Traits>();
            basicEntity.AddOrGet<AnimEventHandler>();
            basicEntity.AddOrGet<Health>();
            MoverLayerOccupier moverLayerOccupier = basicEntity.AddOrGet<MoverLayerOccupier>();
            moverLayerOccupier.objectLayers = new ObjectLayer[2]
            {
      ObjectLayer.Rover,
      ObjectLayer.Mover
            };
            moverLayerOccupier.cellOffsets = new CellOffset[2]
            {
      CellOffset.none,
      new CellOffset(0, 1)
            };
            RobotBatteryMonitor.Def def = basicEntity.AddOrGetDef<RobotBatteryMonitor.Def>();
            def.batteryAmountId = Db.Get().Amounts.InternalChemicalBattery.Id;
            def.canCharge = true;
            def.lowBatteryWarningPercent = 0.2f;
            Storage storage = basicEntity.AddOrGet<Storage>();
            storage.fxPrefix = Storage.FXPrefix.PickedUp;
            storage.dropOnLoad = true;
            storage.SetDefaultStoredItemModifiers(new List<Storage.StoredItemModifier>()
    {
      Storage.StoredItemModifier.Preserve,
      Storage.StoredItemModifier.Seal
    });
            basicEntity.AddOrGetDef<CreatureDebugGoToMonitor.Def>();
            basicEntity.AddOrGetDef<RobotAi.Def>();
            ChoreTable.Builder chore_table = new ChoreTable.Builder().Add((StateMachine.BaseDef)new RobotDeathStates.Def()).Add((StateMachine.BaseDef)new FallStates.Def()).Add((StateMachine.BaseDef)new DebugGoToStates.Def()).Add((StateMachine.BaseDef)new IdleStates.Def(), forcePriority: Db.Get().ChoreTypes.Idle.priority);
            EntityTemplates.AddCreatureBrain(basicEntity, chore_table, GameTags.Robots.Models.ScoutRover, (string)null);
            Navigator navigator = basicEntity.AddOrGet<Navigator>();
            string str = "RobotNavGrid";
            navigator.NavGridName = str;
            navigator.CurrentNavType = NavType.Hover;
            navigator.defaultSpeed = 2f;
            navigator.updateProber = true;
            navigator.sceneLayer = Grid.SceneLayer.Creatures;
            basicEntity.AddOrGet<Sensors>();
            basicEntity.AddOrGet<Pickupable>().SetWorkTime(5f);
            basicEntity.AddOrGet<SnapOn>().snapPoints = new List<SnapOn.SnapPoint>((IEnumerable<SnapOn.SnapPoint>)new SnapOn.SnapPoint[0]);
            component1.SetSymbolVisiblity((KAnimHashedString)"snapto_pivot", false);
            return basicEntity;
        }

        public string GetDlcId() => "EXPANSION1_ID";

        public GameObject CreatePrefab() => DroneConfig.CreateDrone(ID, (string)STRINGS.ROBOTS.MODELS.SCOUT.NAME, (string)STRINGS.ROBOTS.MODELS.SCOUT.DESC, "scout_bot_kanim");

        public void OnPrefabInit(GameObject inst)
        {
            ChoreConsumer component = inst.GetComponent<ChoreConsumer>();
            if ((UnityEngine.Object)component != (UnityEngine.Object)null)
                component.AddProvider((ChoreProvider)GlobalChoreProvider.Instance);
            AmountInstance amountInstance = Db.Get().Amounts.InternalChemicalBattery.Lookup(inst);
            amountInstance.value = amountInstance.GetMax();
        }

        public void OnSpawn(GameObject inst)
        {
            Sensors component1 = inst.GetComponent<Sensors>();
            component1.Add((Sensor)new PathProberSensor(component1));
            component1.Add((Sensor)new PickupableSensor(component1));
            Navigator component2 = inst.GetComponent<Navigator>();
            component2.transitionDriver.overrideLayers.Add((TransitionDriver.OverrideLayer)new BipedTransitionLayer(component2, 3.325f, 2.5f));
            component2.transitionDriver.overrideLayers.Add((TransitionDriver.OverrideLayer)new DoorTransitionLayer(component2));
            component2.transitionDriver.overrideLayers.Add((TransitionDriver.OverrideLayer)new LadderDiseaseTransitionLayer(component2));
            component2.transitionDriver.overrideLayers.Add((TransitionDriver.OverrideLayer)new SplashTransitionLayer(component2));
            component2.SetFlags(PathFinder.PotentialPath.Flags.None);
            component2.CurrentNavType = NavType.Hover;
            PathProber component3 = inst.GetComponent<PathProber>();
            if ((UnityEngine.Object)component3 != (UnityEngine.Object)null)
                component3.SetGroupProber((IGroupProber)MinionGroupProber.Get());
            Effects effects = inst.GetComponent<Effects>();
            if ((UnityEngine.Object)inst.transform.parent == (UnityEngine.Object)null)
            {
                if (effects.HasEffect("ScoutBotCharging"))
                    effects.Remove("ScoutBotCharging");
            }
            else if (!effects.HasEffect("ScoutBotCharging"))
                effects.Add("ScoutBotCharging", false);
            inst.Subscribe(856640610, (System.Action<object>)(data =>
            {
                if ((UnityEngine.Object)inst.transform.parent == (UnityEngine.Object)null)
                {
                    if (!effects.HasEffect("ScoutBotCharging"))
                        return;
                    effects.Remove("ScoutBotCharging");
                }
                else if (!effects.HasEffect("ScoutBotCharging"))
                    effects.Add("ScoutBotCharging", false);
            }));
        }
    }
}/*
*/