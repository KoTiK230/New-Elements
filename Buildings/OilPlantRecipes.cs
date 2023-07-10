using System;
using System.Collections.Generic;
using HarmonyLib;
using STRINGS;
using TUNING;
using UnityEngine;
using New_Elements.Chemistry;
using New_Elements.Buildings;

namespace New_Elements
{
    [HarmonyPatch(typeof(OilPlantConfig), "ConfigureBuildingTemplate")]
    public static class Petroleum_OilPlant_Recipe
    {
        public static void Postfix()
        {
            ComplexRecipe.RecipeElement[] array = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(SimHashes.CrudeOil.CreateTag(), 20f)
            };
            ComplexRecipe.RecipeElement[] array2 = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(SimHashes.Petroleum.CreateTag(), 30f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false),
                new ComplexRecipe.RecipeElement(PolymerResinElement.PolymerResinSimHash.CreateTag(), 30f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false),
                new ComplexRecipe.RecipeElement(SimHashes.Methane.CreateTag(), 30f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false)
            };
            string id = ComplexRecipeManager.MakeRecipeID("OilPlant", array, array2);
            ComplexRecipe complexRecipe = new ComplexRecipe(id, array, array2);
            complexRecipe.time = 10f;
            complexRecipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.Result;
            complexRecipe.description = string.Format(string.Concat(new string[]
            {
                "Refine ",SimHashes.Carbon.CreateTag().ProperName()," with intense heat, producing ",SimHashes.RefinedCarbon.CreateTag().ProperName(),"."}));
            complexRecipe.fabricators = new List<Tag>
            {
                TagManager.Create("OilPlant")
            };
        }
    }
    [HarmonyPatch(typeof(OilPlantConfig), "ConfigureBuildingTemplate")]
    public static class Resin_OilPlant_Recipe
    {
        public static void Postfix()
        {
            ComplexRecipe.RecipeElement[] array = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(SimHashes.CrudeOil.CreateTag(), 20f)
            };
            ComplexRecipe.RecipeElement[] array2 = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(PolymerResinElement.PolymerResinSimHash.CreateTag(), 30f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false),
                new ComplexRecipe.RecipeElement(HeavyOilElement.HeavyOilSimHash.CreateTag(), 30f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false),
                new ComplexRecipe.RecipeElement(SimHashes.Methane.CreateTag(), 30f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false),
            };
            string id = ComplexRecipeManager.MakeRecipeID("OilPlant", array, array2);
            ComplexRecipe complexRecipe = new ComplexRecipe(id, array, array2);
            complexRecipe.time = 10f;
            complexRecipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.Result;
            complexRecipe.description = string.Format(string.Concat(new string[]
            {
                "Refine ",SimHashes.Carbon.CreateTag().ProperName()," with intense heat, producing ",SimHashes.RefinedCarbon.CreateTag().ProperName(),"."}));
            complexRecipe.fabricators = new List<Tag>
            {
                TagManager.Create("OilPlant")
            };
        }
        [HarmonyPatch(typeof(OilPlantConfig), "ConfigureBuildingTemplate")]
        public static class Cocke_OilPlant_Recipe
        {
            public static void Postfix()
            {
                ComplexRecipe.RecipeElement[] array = new ComplexRecipe.RecipeElement[]
                {
                new ComplexRecipe.RecipeElement(HeavyOilElement.HeavyOilSimHash.CreateTag(), 20f)
                };
                ComplexRecipe.RecipeElement[] array2 = new ComplexRecipe.RecipeElement[]
                {
                new ComplexRecipe.RecipeElement(SimHashes.Carbon.CreateTag(), 30f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false)
                };
                string id = ComplexRecipeManager.MakeRecipeID("OilPlant", array, array2);
                ComplexRecipe complexRecipe = new ComplexRecipe(id, array, array2);
                complexRecipe.time = 10f;
                complexRecipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.Result;
                complexRecipe.description = string.Format(string.Concat(new string[]
                {
                "Refine ",SimHashes.Carbon.CreateTag().ProperName()," with intense heat, producing ",SimHashes.RefinedCarbon.CreateTag().ProperName(),"."}));
                complexRecipe.fabricators = new List<Tag>
            {
                TagManager.Create("OilPlant")
            };
            }
        }
    }
}