using STRINGS;
using System.Collections.Generic;
using UnityEngine;

namespace New_Elements
{
    class QuantumComputerConfig : IEntityConfig
    {
        public const string ID = "QuantumComputer";
        public static readonly Tag tag = TagManager.Create("QuantumComputer");
        public const float MASS = 5f;

        public string[] GetDlcIds() => DlcManager.AVAILABLE_ALL_VERSIONS;

        public GameObject CreatePrefab()
        {
            GameObject looseEntity = EntityTemplates.CreateLooseEntity("QuantumComputer", "extrabooba", (string)ITEMS.INDUSTRIAL_PRODUCTS.POWER_STATION_TOOLS.DESC, MASS, true, Assets.GetAnim((HashedString)"kit_electrician_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.6f, true, additionalTags: new List<Tag>()
    {
      GameTags.ManufacturedMaterial,
      QuantumComputerConfig.tag
    });
            return looseEntity;
        }

        public void OnPrefabInit(GameObject inst)
        {
        }

        public void OnSpawn(GameObject inst)
        {
        }
    }
}
