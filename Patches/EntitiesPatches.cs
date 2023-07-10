using HarmonyLib;
using System.Collections.Generic;
using Database;
using TUNING;

namespace New_Elements
{
    class EntitiesPatches
    {
        [HarmonyPatch(typeof(EntityConfigManager), "LoadGeneratedEntities")]
        public class EntityConfigManager_LoadGeneratedEntities_Patch
        {
            public static void Prefix()
            {
                CROPS.CROP_TYPES.Add(new Crop.CropVal(BabanaFruitConfig.ID, 12f * 600.0f, 1));
                CROPS.CROP_TYPES.Add(new Crop.CropVal(IceMelonFruitConfig.ID, 8f * 600.0f, 1));
                CROPS.CROP_TYPES.Add(new Crop.CropVal(PhosphorusGrapeFruitConfig.ID, 16f * 600.0f, 1));
                CROPS.CROP_TYPES.Add(new Crop.CropVal(EyeShroomFoodConfig.ID, 16f * 600.0f, 1));
                CROPS.CROP_TYPES.Add(new Crop.CropVal(ButterFoodConfig.ID, 16f * 600.0f, 1));
                CROPS.CROP_TYPES.Add(new Crop.CropVal(OilBerryFruitConfig.ID, 4f * 600.0f, 1));
            }
        }

    }
}
