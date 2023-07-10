using STRINGS;
using System.Collections.Generic;
using UnityEngine;

namespace New_Elements
{
    class AccumulatorEntityConfig : IEntityConfig
    {
        public const string ID = "AccumulatorEntity";
        public static string NAME = UI.FormatAsLink("Accumulator", ID.ToUpper());
        public const string DESC = "No booba?";
        public static readonly Tag tag = TagManager.Create(ID, NAME);
        public const float MASS = 5f;

        public string[] GetDlcIds() => DlcManager.AVAILABLE_ALL_VERSIONS;

        public GameObject CreatePrefab()
        {
            GameObject looseEntity = EntityTemplates.CreateLooseEntity(ID, NAME, DESC, MASS, false, Assets.GetAnim((HashedString)"kit_electrician_kanim"), "object", Grid.SceneLayer.Front, EntityTemplates.CollisionShape.RECTANGLE, 0.8f, 0.6f, true, additionalTags: new List<Tag>()
    {
      GameTags.ManufacturedMaterial,
     AccumulatorEntityConfig.tag
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
