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
    [HarmonyPatch(typeof(MixerConfig), "ConfigureBuildingTemplate")]
    public static class KatheriumAlloy_MolecularForge_Recipe
    {
        public static void Postfix()
        {
            ComplexRecipe.RecipeElement[] array = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(KatheriumElement.KatheriumSimHash.CreateTag(), 10f),
                new ComplexRecipe.RecipeElement(IridiumElement.IridiumSimHash.CreateTag(), 20f),
            };
            ComplexRecipe.RecipeElement[] array2 = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(KatheriumAlloyElement.KatheriumAlloySimHash.CreateTag(), 30f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false)
            };
            string id = ComplexRecipeManager.MakeRecipeID("SupermaterialRefinery", array, array2);
            ComplexRecipe complexRecipe = new ComplexRecipe(id, array, array2);
            complexRecipe.time = 10f;
            complexRecipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.Result;
            complexRecipe.description = string.Format(string.Concat(new string[]
            {
                "Refine ",SimHashes.Carbon.CreateTag().ProperName()," with intense heat, producing ",SimHashes.RefinedCarbon.CreateTag().ProperName(),"."}));
            complexRecipe.fabricators = new List<Tag>
            {
                TagManager.Create("SupermaterialRefinery")
            };
        }
    }

    [HarmonyPatch(typeof(MixerConfig), "ConfigureBuildingTemplate")]
    public static class Katherium_MetalRefinery_Recipe
    {
        public static void Postfix()
        {
            ComplexRecipe.RecipeElement[] array = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(KatheriumElement.KatheriumOreSimHash.CreateTag(), 100f)
            };
            ComplexRecipe.RecipeElement[] array2 = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(KatheriumElement.KatheriumSimHash.CreateTag(), 50f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false)
            };
            string id = ComplexRecipeManager.MakeRecipeID("MetalRefinery", array, array2);
            ComplexRecipe complexRecipe = new ComplexRecipe(id, array, array2);
            complexRecipe.time = 10f;
            complexRecipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.Result;
            complexRecipe.description = string.Format(string.Concat(new string[]
            {
                "Refine ",SimHashes.Carbon.CreateTag().ProperName()," with intense heat, producing ",SimHashes.RefinedCarbon.CreateTag().ProperName(),"."}));
            complexRecipe.fabricators = new List<Tag>
            {
                TagManager.Create("MetalRefinery")
            };
        }
    }

    [HarmonyPatch(typeof(MixerConfig), "ConfigureBuildingTemplate")]
    public static class Nickel_MetalRefinery_Recipe
    {
        public static void Postfix()
        {
            ComplexRecipe.RecipeElement[] array = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(NickelElement.NickelOreSimHash.CreateTag(), 100f)
            };
            ComplexRecipe.RecipeElement[] array2 = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(NickelElement.NickelSimHash.CreateTag(), 100f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false)
            };
            string id = ComplexRecipeManager.MakeRecipeID("MetalRefinery", array, array2);
            ComplexRecipe complexRecipe = new ComplexRecipe(id, array, array2);
            complexRecipe.time = 10f;
            complexRecipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.Result;
            complexRecipe.description = string.Format(string.Concat(new string[]
            {
                "Refine ",SimHashes.Carbon.CreateTag().ProperName()," with intense heat, producing ",SimHashes.RefinedCarbon.CreateTag().ProperName(),"."}));
            complexRecipe.fabricators = new List<Tag>
            {
                TagManager.Create("MetalRefinery")
            };
        }
    }

    [HarmonyPatch(typeof(MixerConfig), "ConfigureBuildingTemplate")]
    public static class Katherium_RockCrusher_Recipe
    {
        public static void Postfix()
        {
            ComplexRecipe.RecipeElement[] array = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(KatheriumElement.KatheriumOreSimHash.CreateTag(), 100f)
            };
            ComplexRecipe.RecipeElement[] array2 = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(KatheriumElement.KatheriumSimHash.CreateTag(), 25f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false),
                new ComplexRecipe.RecipeElement(SimHashes.Sand.CreateTag(), 75f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false)
            };
            string id = ComplexRecipeManager.MakeRecipeID("RockCrusher", array, array2);
            ComplexRecipe complexRecipe = new ComplexRecipe(id, array, array2);
            complexRecipe.time = 10f;
            complexRecipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.Result;
            complexRecipe.description = string.Format(string.Concat(new string[]
            {
                "Refine ",SimHashes.Carbon.CreateTag().ProperName()," with intense heat, producing ",SimHashes.RefinedCarbon.CreateTag().ProperName(),"."}));
            complexRecipe.fabricators = new List<Tag>
            {
                TagManager.Create("RockCrusher")
            };
        }
    }

    [HarmonyPatch(typeof(MixerConfig), "ConfigureBuildingTemplate")]
    public static class Nickel_RockCrusher_Recipe
    {
        public static void Postfix()
        {
            ComplexRecipe.RecipeElement[] array = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(NickelElement.NickelOreSimHash.CreateTag(), 100f)
            };
            ComplexRecipe.RecipeElement[] array2 = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(NickelElement.NickelSimHash.CreateTag(), 50f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false),
                new ComplexRecipe.RecipeElement(SimHashes.Sand.CreateTag(), 50f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false)
            };
            string id = ComplexRecipeManager.MakeRecipeID("RockCrusher", array, array2);
            ComplexRecipe complexRecipe = new ComplexRecipe(id, array, array2);
            complexRecipe.time = 10f;
            complexRecipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.Result;
            complexRecipe.description = string.Format(string.Concat(new string[]
            {
                "Refine ",SimHashes.Carbon.CreateTag().ProperName()," with intense heat, producing ",SimHashes.RefinedCarbon.CreateTag().ProperName(),"."}));
            complexRecipe.fabricators = new List<Tag>
            {
                TagManager.Create("RockCrusher")
            };
        }
    }
}
