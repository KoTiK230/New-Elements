﻿using STRINGS;
using System.Collections.Generic;
using UnityEngine;

namespace New_Elements
{
    class PhosphorusGrapeFruitConfig : IEntityConfig
    {
        public static string ID = "PhosphorusGrapeFruit";
        public static string NAME = UI.FormatAsLink("Phosphorus Grapes", ID.ToUpper());
        public static string DESC = "Oh These Are Pretty Cool Babanas";
        public const int quality = TUNING.FOOD.FOOD_QUALITY_MEDIOCRE;
        public const float caloriesPerUnit = 600f * 1000f;
        public const float preserveTemperatue = TUNING.FOOD.DEFAULT_PRESERVE_TEMPERATURE;
        public const float rotTemperature = TUNING.FOOD.DEFAULT_ROT_TEMPERATURE;
        public const float spoilTime = TUNING.FOOD.SPOIL_TIME.DEFAULT;
        public const string dlcId = DlcManager.VANILLA_ID;

        public string[] GetDlcIds() => DlcManager.AVAILABLE_ALL_VERSIONS;

        public GameObject CreatePrefab()
        {
            var looseEntity = EntityTemplates.CreateLooseEntity(
                id: ID,
                name: NAME,
                desc: DESC,
                mass: 1f,
                unitMass: false,
                anim: Assets.GetAnim("swampcrop_fruit_kanim"),
                initialAnim: "object",
                sceneLayer: Grid.SceneLayer.Front,
                collisionShape: EntityTemplates.CollisionShape.RECTANGLE,
                width: 0.8f,
                height: 0.4f,
                isPickupable: true);

            var foodInfo = new EdiblesManager.FoodInfo(
                id: ID,
                dlcId: dlcId,
                caloriesPerUnit: caloriesPerUnit,
                quality: quality,
                preserveTemperatue: preserveTemperatue,
                rotTemperature: rotTemperature,
                spoilTime: spoilTime,
                can_rot: true);

            var foodEntity = EntityTemplates.ExtendEntityToFood(
                template: looseEntity,
                foodInfo: foodInfo);

            return foodEntity;
        }
        public void OnPrefabInit(GameObject inst)
        {
        }

        public void OnSpawn(GameObject inst)
        {
        }
    }
}