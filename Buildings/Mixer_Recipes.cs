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
    public static class SulfuricAcid_Mixer_Recipe
    {
        public static void Postfix()
        {
            ComplexRecipe.RecipeElement[] array = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(SulfurTrioxideElement.SulfurTrioxideSimHash.CreateTag(), 10f),
                new ComplexRecipe.RecipeElement(SimHashes.Water.CreateTag(), 20f),
            };
            ComplexRecipe.RecipeElement[] array2 = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(SulfuricAcidElement.SulfuricAcidSimHash.CreateTag(), 30f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false)
            };
            string id = ComplexRecipeManager.MakeRecipeID("Mixer", array, array2);
            ComplexRecipe complexRecipe = new ComplexRecipe(id, array, array2);
            complexRecipe.time = 10f;
            complexRecipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.Result;
            complexRecipe.description = string.Format(string.Concat(new string[]
            {
                "Refine ",SimHashes.Carbon.CreateTag().ProperName()," with intense heat, producing ",SimHashes.RefinedCarbon.CreateTag().ProperName(),"."}));
            complexRecipe.fabricators = new List<Tag>
            {
                TagManager.Create("Mixer")
            };
        }
    }
    [HarmonyPatch(typeof(MixerConfig), "ConfigureBuildingTemplate")]
    public static class NitricAcid_Mixer_Recipe
    {
        public static void Postfix()
        {
            ComplexRecipe.RecipeElement[] array = new ComplexRecipe.RecipeElement[]
            {

                new ComplexRecipe.RecipeElement(NitrogenDioxideElement.NitrogenDioxideSimHash.CreateTag(), 10f),
                new ComplexRecipe.RecipeElement(SimHashes.Water.CreateTag(), 20f)
            };
            ComplexRecipe.RecipeElement[] array2 = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(NitricAcidElement.NitricAcidSimHash.CreateTag(), 30f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false)
            };
            string id = ComplexRecipeManager.MakeRecipeID("Mixer", array, array2);
            ComplexRecipe complexRecipe = new ComplexRecipe(id, array, array2);
            complexRecipe.time = 10f;
            complexRecipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.Result;
            complexRecipe.description = string.Format(string.Concat(new string[]
            {
                "Refine ",SimHashes.Carbon.CreateTag().ProperName()," with intense heat, producing ",SimHashes.RefinedCarbon.CreateTag().ProperName(),"."}));
            complexRecipe.fabricators = new List<Tag>
            {
                TagManager.Create("Mixer")
            };
        }
    }
    [HarmonyPatch(typeof(MixerConfig), "ConfigureBuildingTemplate")]
    public static class Propane_Mixer_Recipe
    {
        public static void Postfix()
        {
            ComplexRecipe.RecipeElement[] array = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(SimHashes.Methane.CreateTag(), 20f),
                new ComplexRecipe.RecipeElement(SimHashes.Chlorine.CreateTag(), 10f),
                new ComplexRecipe.RecipeElement(SimHashes.Salt.CreateTag(), 10f)
            };
            ComplexRecipe.RecipeElement[] array2 = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(SimHashes.Propane.CreateTag(), 30f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false),
                new ComplexRecipe.RecipeElement(SimHashes.Salt.CreateTag(), 30f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false),
                new ComplexRecipe.RecipeElement(SimHashes.Hydrogen.CreateTag(), 30f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false)
            };
            string id = ComplexRecipeManager.MakeRecipeID("Mixer", array, array2);
            ComplexRecipe complexRecipe = new ComplexRecipe(id, array, array2);
            complexRecipe.time = 10f;
            complexRecipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.Result;
            complexRecipe.description = string.Format(string.Concat(new string[]
            {
                "Refine ",SimHashes.Carbon.CreateTag().ProperName()," with intense heat, producing ",SimHashes.RefinedCarbon.CreateTag().ProperName(),"."}));
            complexRecipe.fabricators = new List<Tag>
            {
                TagManager.Create("Mixer")
            };
        }
    }
    [HarmonyPatch(typeof(MixerConfig), "ConfigureBuildingTemplate")]
    public static class Petroleum_Mixer_Recipe
    {
        public static void Postfix()
        {
            ComplexRecipe.RecipeElement[] array = new ComplexRecipe.RecipeElement[]
            {

                new ComplexRecipe.RecipeElement(HeavyOilElement.HeavyOilSimHash.CreateTag(), 10f),
                new ComplexRecipe.RecipeElement(SimHashes.Water.CreateTag(), 20f)
            };
            ComplexRecipe.RecipeElement[] array2 = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(SimHashes.Petroleum.CreateTag(), 30f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false),
            };
            string id = ComplexRecipeManager.MakeRecipeID("Mixer", array, array2);
            ComplexRecipe complexRecipe = new ComplexRecipe(id, array, array2);
            complexRecipe.time = 10f;
            complexRecipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.Result;
            complexRecipe.description = string.Format(string.Concat(new string[]
            {
                "Refine ",SimHashes.Carbon.CreateTag().ProperName()," with intense heat, producing ",SimHashes.RefinedCarbon.CreateTag().ProperName(),"."}));
            complexRecipe.fabricators = new List<Tag>
            {
                TagManager.Create("Mixer")
            };
        }
    }
    [HarmonyPatch(typeof(MixerConfig), "ConfigureBuildingTemplate")]
    public static class Lime_Mixer_Recipe
    {
        public static void Postfix()
        {
            ComplexRecipe.RecipeElement[] array = new ComplexRecipe.RecipeElement[]
        {
                new ComplexRecipe.RecipeElement(SimHashes.Fossil.CreateTag(), 10f),
                new ComplexRecipe.RecipeElement(SimHashes.Water.CreateTag(), 20f),
                new ComplexRecipe.RecipeElement(SimHashes.CarbonDioxide.CreateTag(), 10f)
        };
            ComplexRecipe.RecipeElement[] array2 = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(SimHashes.Lime.CreateTag(), 30f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false),
                new ComplexRecipe.RecipeElement(SimHashes.DirtyWater.CreateTag(), 30f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false)
            };
            string id = ComplexRecipeManager.MakeRecipeID("Mixer", array, array2);
            ComplexRecipe complexRecipe = new ComplexRecipe(id, array, array2);
            complexRecipe.time = 10f;
            complexRecipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.Result;
            complexRecipe.description = string.Format(string.Concat(new string[]
            {
                "Refine ",SimHashes.Carbon.CreateTag().ProperName()," with intense heat, producing ",SimHashes.RefinedCarbon.CreateTag().ProperName(),"."}));
            complexRecipe.fabricators = new List<Tag>
            {
                TagManager.Create("Mixer")
            };
        }
    }
    [HarmonyPatch(typeof(MixerConfig), "ConfigureBuildingTemplate")]
    public static class YellowCake_Mixer_Recipe
    {
        public static void Postfix()
        {
            if (DlcManager.IsExpansion1Active())
            {
                ComplexRecipe.RecipeElement[] array = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(SimHashes.UraniumOre.CreateTag(), 20f),
                new ComplexRecipe.RecipeElement(SulfuricAcidElement.SulfuricAcidSimHash.CreateTag(), 10f),
                new ComplexRecipe.RecipeElement(NitricAcidElement.NitricAcidSimHash.CreateTag(), 10f),
                new ComplexRecipe.RecipeElement(AmmoniaElement.AmmoniaSimHash.CreateTag(), 10f),
            };
                ComplexRecipe.RecipeElement[] array2 = new ComplexRecipe.RecipeElement[]
                {
                new ComplexRecipe.RecipeElement(SimHashes.Yellowcake.CreateTag(), 30f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false),
                new ComplexRecipe.RecipeElement(SimHashes.CarbonDioxide.CreateTag(), 30f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false)
                };
                string id = ComplexRecipeManager.MakeRecipeID("Mixer", array, array2);
                ComplexRecipe complexRecipe = new ComplexRecipe(id, array, array2);
                complexRecipe.time = 10f;
                complexRecipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.Result;
                complexRecipe.description = string.Format(string.Concat(new string[]
                {
                "Refine ",SimHashes.Carbon.CreateTag().ProperName()," with intense heat, producing ",SimHashes.RefinedCarbon.CreateTag().ProperName(),"."}));
                complexRecipe.fabricators = new List<Tag>
            {
                TagManager.Create("Mixer")
            };
            }
        }
    }

}
