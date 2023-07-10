using KSerialization;
using System.Collections.Generic;
using UnityEngine;

namespace NightLib.SavegameUnsafe
{
    [SerializationConfig(MemberSerialization.OptIn)]
    internal abstract class PortConduitDispenserBase : KMonoBehaviour, ISaveLoadable
    {
        [SerializeField]
        public CellOffset conduitOffset;
        [SerializeField]
        public CellOffset conduitOffsetFlipped;
        [SerializeField]
        public ConduitType conduitType;
        [SerializeField]
        public SimHashes[] elementFilter = (SimHashes[])null;
        [SerializeField]
        public bool invertElementFilter;
        [SerializeField]
        public bool alwaysDispense;
        [SerializeField]
        public bool SkipSetOperational = false;
        private static readonly Operational.Flag outputConduitFlag = new Operational.Flag("output_conduit", Operational.Flag.Type.Functional);
        private FlowUtilityNetwork.NetworkItem networkItem;
        [MyCmpReq]
        private readonly Operational operational;
        [MyCmpReq]
        public Storage storage;
        private HandleVector<int>.Handle partitionerEntry;
        private int utilityCell = -1;
        private int elementOutputOffset;

        internal void AssignPort(PortDisplayOutput port)
        {
            this.conduitType = port.type;
            this.conduitOffset = port.offset;
            this.conduitOffsetFlipped = port.offsetFlipped;
        }

        internal ConduitType TypeOfConduit => this.conduitType;

        internal ConduitFlow.ConduitContents ConduitContents => this.GetConduitManager().GetContents(this.utilityCell);

        public int UtilityCell => this.utilityCell;

        internal bool IsConnected
        {
            get
            {
                GameObject gameObject = Grid.Objects[this.utilityCell, this.conduitType != ConduitType.Gas ? 16 : 12];
                return (UnityEngine.Object)gameObject != (UnityEngine.Object)null && (UnityEngine.Object)gameObject.GetComponent<BuildingComplete>() != (UnityEngine.Object)null;
            }
        }

        internal void SetConduitData(ConduitType type) => this.conduitType = type;

        internal ConduitFlow GetConduitManager()
        {
            switch (this.conduitType)
            {
                case ConduitType.Gas:
                    return Game.Instance.gasConduitFlow;
                case ConduitType.Liquid:
                    return Game.Instance.liquidConduitFlow;
                default:
                    return (ConduitFlow)null;
            }
        }

        private void OnConduitConnectionChanged(object data) => this.Trigger(-2094018600, (object)this.IsConnected);

        internal virtual CellOffset GetUtilityCellOffset() => new CellOffset(0, 1);

        protected override void OnSpawn()
        {
            base.OnSpawn();
            Building component = this.GetComponent<Building>();
            this.utilityCell = component.GetCellWithOffset(component.Orientation == Orientation.Neutral ? this.conduitOffset : this.conduitOffsetFlipped);
            IUtilityNetworkMgr networkManager = Conduit.GetNetworkManager(this.conduitType);
            this.networkItem = new FlowUtilityNetwork.NetworkItem(this.conduitType, Endpoint.Source, this.utilityCell, this.gameObject);
            networkManager.AddToNetworks(this.utilityCell, (object)this.networkItem, true);
            this.partitionerEntry = GameScenePartitioner.Instance.Add("ConduitConsumer.OnSpawn", (object)this.gameObject, this.utilityCell, GameScenePartitioner.Instance.objectLayers[this.conduitType != ConduitType.Gas ? 16 : 12], new System.Action<object>(this.OnConduitConnectionChanged));
            this.GetConduitManager().AddConduitUpdater(new System.Action<float>(this.ConduitUpdate), ConduitFlowPriority.LastPostUpdate);
            this.OnConduitConnectionChanged((object)null);
        }

        protected override void OnCleanUp()
        {
            Conduit.GetNetworkManager(this.conduitType).RemoveFromNetworks(this.utilityCell, (object)this.networkItem, true);
            this.GetConduitManager().RemoveConduitUpdater(new System.Action<float>(this.ConduitUpdate));
            GameScenePartitioner.Instance.Free(ref this.partitionerEntry);
            base.OnCleanUp();
        }

        protected virtual void ConduitUpdate(float dt)
        {
            if (!this.SkipSetOperational)
                this.operational.SetFlag(PortConduitDispenserBase.outputConduitFlag, this.IsConnected);
            if (!this.operational.IsOperational && !this.alwaysDispense)
                return;
            PrimaryElement suitableElement = this.FindSuitableElement();
            if ((UnityEngine.Object)suitableElement != (UnityEngine.Object)null)
            {
                suitableElement.KeepZeroMassObject = true;
                float num1 = this.GetConduitManager().AddElement(this.utilityCell, suitableElement.ElementID, suitableElement.Mass, suitableElement.Temperature, suitableElement.DiseaseIdx, suitableElement.DiseaseCount);
                if ((double)num1 > 0.0)
                {
                    int num2 = (int)((double)(num1 / suitableElement.Mass) * (double)suitableElement.DiseaseCount);
                    suitableElement.ModifyDiseaseCount(-num2, "CustomConduitDispenser.ConduitUpdate");
                    suitableElement.Mass -= num1;
                    this.Trigger(-1697596308, (object)suitableElement.gameObject);
                }
            }
        }

        protected virtual PrimaryElement FindSuitableElement()
        {
            List<GameObject> items = this.storage.items;
            int count = items.Count;
            for (int index1 = 0; index1 < count; ++index1)
            {
                int index2 = (index1 + this.elementOutputOffset) % count;
                PrimaryElement component = items[index2].GetComponent<PrimaryElement>();
                if ((UnityEngine.Object)component != (UnityEngine.Object)null && (double)component.Mass > 0.0 && (this.conduitType != ConduitType.Liquid ? (component.Element.IsGas ? 1 : 0) : (component.Element.IsLiquid ? 1 : 0)) != 0 && (this.elementFilter == null || this.elementFilter.Length == 0 || !this.invertElementFilter && this.IsFilteredElement(component.ElementID) || this.invertElementFilter && !this.IsFilteredElement(component.ElementID)))
                {
                    this.elementOutputOffset = (this.elementOutputOffset + 1) % count;
                    return component;
                }
            }
            return (PrimaryElement)null;
        }

        private bool IsFilteredElement(SimHashes element)
        {
            for (int index = 0; index != this.elementFilter.Length; ++index)
            {
                if (this.elementFilter[index] == element)
                    return true;
            }
            return false;
        }
    }
}
