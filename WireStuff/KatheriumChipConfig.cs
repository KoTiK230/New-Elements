using STRINGS;
using System.Collections.Generic;
using UnityEngine;

namespace New_Elements
{
    class KatheriumChipConfig : IEntityConfig
    {
        public const string ID = "KatheriumChip";
        public static string NAME = UI.FormatAsLink("Katherium Chip", ID.ToUpper());
        public const string DESC = "Yes booba?";
        public static readonly Tag tag = TagManager.Create(ID, NAME);
        public const float MASS = 5f;

        public string[] GetDlcIds() => DlcManager.AVAILABLE_ALL_VERSIONS;

        public GameObject CreatePrefab()
        {
            GameObject looseEntity = EntityTemplates.CreateLooseEntity(ID, NAME, DESC, MASS, true, Assets.GetAnim((HashedString)"kit_electrician_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.6f, true, additionalTags: new List<Tag>()
    {
      GameTags.ManufacturedMaterial,
      KatheriumChipConfig.tag
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
