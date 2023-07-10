using System;
using System.Collections.Generic;
using HarmonyLib;
using STRINGS;
using TUNING;
using UnityEngine;
using New_Elements.Chemistry;

namespace New_Elements
{
    [HarmonyPatch(typeof(AdvancedKilnConfig), "ConfigureBuildingTemplate")]
    public static class RefinedCarbon_Kiln_Recipe
    {
        public static void Postfix()
        {
            ComplexRecipe.RecipeElement[] array = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(SimHashes.Sulfur.CreateTag(), 10f),
                new ComplexRecipe.RecipeElement(SimHashes.Oxygen.CreateTag(), 20f)
            };
            ComplexRecipe.RecipeElement[] array2 = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(SulfurTrioxideElement.SulfurTrioxideSimHash.CreateTag(), 30f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false)
            };
            string id = ComplexRecipeManager.MakeRecipeID("AdvancedKiln", array, array2);
            ComplexRecipe complexRecipe = new ComplexRecipe(id, array, array2);
            complexRecipe.time = 30f;
            complexRecipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.Result;
            complexRecipe.description = string.Format(string.Concat(new string[]
            {
                "Refine ",SimHashes.Carbon.CreateTag().ProperName()," with intense heat, producing ",SimHashes.RefinedCarbon.CreateTag().ProperName(),"."}));
            complexRecipe.fabricators = new List<Tag>
            {
                TagManager.Create("AdvancedKiln")
            };
        }
    }
}
