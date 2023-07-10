/*using KSerialization;
using STRINGS;
using UnityEngine;
using New_Elements;

[AddComponentMenu("KMonoBehaviour/scripts/SweepBotStation")]
public class DroneHive : KMonoBehaviour
{
    private static readonly EventSystem.IntraObjectHandler<DroneHive> OnOperationalChangedDelegate = new EventSystem.IntraObjectHandler<DroneHive>((System.Action<DroneHive, object>)((component, data) => component.OnOperationalChanged(data)));
    private Operational.Flag hasRobot = new Operational.Flag(nameof(hasRobot), Operational.Flag.Type.Functional);
    private int refreshDronebotHandle = -1;
    [Serialize]
    public Ref<KSelectable> sweepDrone;
    [Serialize]
    public string storedName;
    private Storage botMaterialStorage;
    private SchedulerHandle newDroneHandle;

    protected override void OnPrefabInit()
    {
        this.Initialize();
        this.Subscribe<DroneHive>(-592767678, DroneHive.OnOperationalChangedDelegate);
    }

    protected void Initialize()
    {
        base.OnPrefabInit();
        this.GetComponent<Operational>().SetFlag(this.hasRobot, false);
    }

    protected override void OnSpawn()
    {
        this.botMaterialStorage = this.GetComponents<Storage>()[0];
        if (this.sweepDrone == null || (UnityEngine.Object)this.sweepDrone.Get() == (UnityEngine.Object)null)
        {
            this.RequestNewDroneBot((object)null);
        }
        else
        {
            this.RefreshDroneSubscription();
        }
    }

    private void RequestNewDroneBot(object data = null)
    {
        if ((UnityEngine.Object)this.botMaterialStorage.FindFirstWithMass(GameTags.RefinedMetal, DroneConfig.MASS) == (UnityEngine.Object)null)
        {
            FetchList2 fetchList2 = new FetchList2(this.botMaterialStorage, Db.Get().ChoreTypes.Fetch);
            fetchList2.Add(GameTags.RefinedMetal, (Tag[])null, (Tag[])null, DroneConfig.MASS, FetchOrder2.OperationalRequirement.None);
            fetchList2.Submit((System.Action)null, true);
        }
        else
            this.MakeNewDroneBot((object)null);
    }

    private void MakeNewDroneBot(object data = null)
    {
        if (this.newDroneHandle.IsValid || (double)this.botMaterialStorage.GetAmountAvailable(GameTags.RefinedMetal) < (double)DroneConfig.MASS)
            return;
        PrimaryElement firstWithMass = this.botMaterialStorage.FindFirstWithMass(GameTags.RefinedMetal, DroneConfig.MASS);
        if ((UnityEngine.Object)firstWithMass == (UnityEngine.Object)null)
            return;
        SimHashes sweepDroneMaterial = firstWithMass.ElementID;
        firstWithMass.Mass -= DroneConfig.MASS;
        this.newDroneHandle = GameScheduler.Instance.Schedule("MakeDrone", 2f, (System.Action<object>)(obj =>
        {
            GameObject go = GameUtil.KInstantiate(Assets.GetPrefab((Tag)"DroneBot"), Grid.CellToPos(Grid.CellRight(Grid.PosToCell(this.gameObject))), Grid.SceneLayer.Creatures, (string)null, 0);
            go.SetActive(true);
            this.sweepDrone = new Ref<KSelectable>(go.GetComponent<KSelectable>());
            this.sweepDrone.Get().GetComponent<PrimaryElement>().ElementID = sweepDroneMaterial;
            this.RefreshDroneSubscription();
            this.newDroneHandle.ClearScheduler();
        }), (object)null, (SchedulerGroup)null);
    }

    private void RefreshDroneSubscription()
    {
        if (this.refreshDronebotHandle != -1)
        {
            this.sweepDrone.Get().Unsubscribe(this.refreshDronebotHandle);
        }
        this.refreshDronebotHandle = this.sweepDrone.Get().Subscribe(1969584890, new System.Action<object>(this.RequestNewDroneBot));
    }


    public void StartCharging()
    {
        this.GetComponent<Operational>().SetFlag(this.hasRobot, true);
    }

    public void StopCharging()
    {
        this.GetComponent<Operational>().SetFlag(this.hasRobot, false);
    }

    protected override void OnCleanUp()
    {
        if (this.newDroneHandle.IsValid)
            this.newDroneHandle.ClearScheduler();
        if (this.refreshDronebotHandle == -1 || !((UnityEngine.Object)this.sweepDrone.Get() != (UnityEngine.Object)null))
            return;
        this.sweepDrone.Get().Unsubscribe(this.refreshDronebotHandle);
    }

    private void OnOperationalChanged(object data)
    {
        Operational component = this.GetComponent<Operational>();
        if (component.Flags.ContainsValue(false))
            component.SetActive(false, false);
        else
            component.SetActive(true, false);
        if (this.sweepDrone != null && !((UnityEngine.Object)this.sweepDrone.Get() == (UnityEngine.Object)null))
            return;
        this.RequestNewDroneBot((object)null);
    }
}
*/