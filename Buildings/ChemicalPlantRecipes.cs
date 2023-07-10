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
    [HarmonyPatch(typeof(ChemicalPlantConfig), "ConfigureBuildingTemplate")]
    public static class Plastic_ChemicalPlant_Recipe
    {
        public static void Postfix()
        {
            ComplexRecipe.RecipeElement[] array = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(PolymerResinElement.PolymerResinSimHash.CreateTag(), 20f),
                new ComplexRecipe.RecipeElement(SimHashes.Water.CreateTag(), 10f)
            };
            ComplexRecipe.RecipeElement[] array2 = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(SimHashes.Polypropylene.CreateTag(), 30f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false)
            };
            string id = ComplexRecipeManager.MakeRecipeID("ChemicalPlant", array, array2);
            ComplexRecipe complexRecipe = new ComplexRecipe(id, array, array2);
            complexRecipe.time = 10f;
            complexRecipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.Result;
            complexRecipe.description = string.Format(string.Concat(new string[]
            {
                "Refine ",SimHashes.Carbon.CreateTag().ProperName()," with intense heat, producing ",SimHashes.RefinedCarbon.CreateTag().ProperName(),"."}));
            complexRecipe.fabricators = new List<Tag>
            {
                TagManager.Create("ChemicalPlant")
            };
        }
    }
    [HarmonyPatch(typeof(ChemicalPlantConfig), "ConfigureBuildingTemplate")]
    public static class Rubber_ChemicalPlant_Recipe
    {
        public static void Postfix()
        {
            ComplexRecipe.RecipeElement[] array = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(PolymerResinElement.PolymerResinSimHash.CreateTag(), 10f),
                new ComplexRecipe.RecipeElement(SimHashes.Water.CreateTag(), 20f)
                
            };
            ComplexRecipe.RecipeElement[] array2 = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(RubberElement.RubberSimHash.CreateTag(), 30f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false)
            };
            string id = ComplexRecipeManager.MakeRecipeID("ChemicalPlant", array, array2);
            ComplexRecipe complexRecipe = new ComplexRecipe(id, array, array2);
            complexRecipe.time = 10f;
            complexRecipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.Result;
            complexRecipe.description = string.Format(string.Concat(new string[]
            {
                "Refine ",SimHashes.Carbon.CreateTag().ProperName()," with intense heat, producing ",SimHashes.RefinedCarbon.CreateTag().ProperName(),"."}));
            complexRecipe.fabricators = new List<Tag>
            {
                TagManager.Create("ChemicalPlant")
            };
        }
    }
    [HarmonyPatch(typeof(ChemicalPlantConfig), "ConfigureBuildingTemplate")]
    public static class bleh_ChemicalPlant_Recipe
    {
        public static void Postfix()
        {
            ComplexRecipe.RecipeElement[] array = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(PolymerResinElement.PolymerResinSimHash.CreateTag(), 10f)
            };
            ComplexRecipe.RecipeElement[] array2 = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(KatheriumChipConfig.tag, 30f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false)
            };
            string id = ComplexRecipeManager.MakeRecipeID("ChemicalPlant", array, array2);
            ComplexRecipe complexRecipe = new ComplexRecipe(id, array, array2);
            complexRecipe.time = 10f;
            complexRecipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.Result;
            complexRecipe.description = string.Format(string.Concat(new string[]
            {
                "Refine ",SimHashes.Carbon.CreateTag().ProperName()," with intense heat, producing ",SimHashes.RefinedCarbon.CreateTag().ProperName(),"."}));
            complexRecipe.fabricators = new List<Tag>
            {
                TagManager.Create("ChemicalPlant")
            };
        }
    }
    [HarmonyPatch(typeof(ChemicalPlantConfig), "ConfigureBuildingTemplate")]
    public static class Ethanol_ChemicalPlant_Recipe
    {
        public static void Postfix()
        {
            if (DlcManager.IsExpansion1Active())
            {
                ComplexRecipe.RecipeElement[] array = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(SimHashes.Water.CreateTag(), 20f),
                new ComplexRecipe.RecipeElement(SimHashes.Sucrose.CreateTag(), 10f)
            };
                ComplexRecipe.RecipeElement[] array2 = new ComplexRecipe.RecipeElement[]
                {
                new ComplexRecipe.RecipeElement(SimHashes.Ethanol.CreateTag(), 30f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false),
                new ComplexRecipe.RecipeElement(SimHashes.CarbonDioxide.CreateTag(), 30f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false)
                };
                string id = ComplexRecipeManager.MakeRecipeID("ChemicalPlant", array, array2);
                ComplexRecipe complexRecipe = new ComplexRecipe(id, array, array2);
                complexRecipe.time = 10f;
                complexRecipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.Result;
                complexRecipe.description = string.Format(string.Concat(new string[]
                {
                "Refine ",SimHashes.Carbon.CreateTag().ProperName()," with intense heat, producing ",SimHashes.RefinedCarbon.CreateTag().ProperName(),"."}));
                complexRecipe.fabricators = new List<Tag>
            {
                TagManager.Create("ChemicalPlant")
            };
            }
        }
    }
    [HarmonyPatch(typeof(ChemicalPlantConfig), "ConfigureBuildingTemplate")]
    public static class Bauxite_ChemicalPlant_Recipe
    {
        public static void Postfix()
        {
                ComplexRecipe.RecipeElement[] array = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(SimHashes.Water.CreateTag(), 20f),
                new ComplexRecipe.RecipeElement(SimHashes.Clay.CreateTag(), 10f),
                new ComplexRecipe.RecipeElement(SimHashes.RefinedCarbon.CreateTag(), 10f)
            };
                ComplexRecipe.RecipeElement[] array2 = new ComplexRecipe.RecipeElement[]
                {
                new ComplexRecipe.RecipeElement(SimHashes.AluminumOre.CreateTag(), 30f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false),
                new ComplexRecipe.RecipeElement(SimHashes.DirtyWater.CreateTag(), 30f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false)
                };
                string id = ComplexRecipeManager.MakeRecipeID("ChemicalPlant", array, array2);
                ComplexRecipe complexRecipe = new ComplexRecipe(id, array, array2);
                complexRecipe.time = 10f;
                complexRecipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.Result;
                complexRecipe.description = string.Format(string.Concat(new string[]
                {
                "Refine ",SimHashes.Carbon.CreateTag().ProperName()," with intense heat, producing ",SimHashes.RefinedCarbon.CreateTag().ProperName(),"."}));
                complexRecipe.fabricators = new List<Tag>
            {
                TagManager.Create("ChemicalPlant")
            };
        }
    }

    [HarmonyPatch(typeof(ChemicalPlantConfig), "ConfigureBuildingTemplate")]
    public static class Saltwater_ChemicalPlant_Recipe
    {
        public static void Postfix()
        {
            ComplexRecipe.RecipeElement[] array = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(SimHashes.Salt.CreateTag(), 20f),
                new ComplexRecipe.RecipeElement(SimHashes.Water.CreateTag(), 10f)
            };
            ComplexRecipe.RecipeElement[] array2 = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(SimHashes.SaltWater.CreateTag(), 30f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false)
            };
            string id = ComplexRecipeManager.MakeRecipeID("ChemicalPlant", array, array2);
            ComplexRecipe complexRecipe = new ComplexRecipe(id, array, array2);
            complexRecipe.time = 10f;
            complexRecipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.Result;
            complexRecipe.description = string.Format(string.Concat(new string[]
            {
                "Refine ",SimHashes.Carbon.CreateTag().ProperName()," with intense heat, producing ",SimHashes.RefinedCarbon.CreateTag().ProperName(),"."}));
            complexRecipe.fabricators = new List<Tag>
            {
                TagManager.Create("ChemicalPlant")
            };
        }
    }
    [HarmonyPatch(typeof(ChemicalPlantConfig), "ConfigureBuildingTemplate")]
    public static class Dirtywater_ChemicalPlant_Recipe
    {
        public static void Postfix()
        {
            ComplexRecipe.RecipeElement[] array = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(SimHashes.ToxicSand.CreateTag(), 20f),
                new ComplexRecipe.RecipeElement(SimHashes.Water.CreateTag(), 10f)
            };
            ComplexRecipe.RecipeElement[] array2 = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(SimHashes.DirtyWater.CreateTag(), 30f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false)
            };
            string id = ComplexRecipeManager.MakeRecipeID("ChemicalPlant", array, array2);
            ComplexRecipe complexRecipe = new ComplexRecipe(id, array, array2);
            complexRecipe.time = 10f;
            complexRecipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.Result;
            complexRecipe.description = string.Format(string.Concat(new string[]
            {
                "Refine ",SimHashes.Carbon.CreateTag().ProperName()," with intense heat, producing ",SimHashes.RefinedCarbon.CreateTag().ProperName(),"."}));
            complexRecipe.fabricators = new List<Tag>
            {
                TagManager.Create("ChemicalPlant")
            };
        }
    }

    [HarmonyPatch(typeof(MixerConfig), "ConfigureBuildingTemplate")]
    public static class Katherium_ChemicalPlant_Recipe
    {
        public static void Postfix()
        {
            ComplexRecipe.RecipeElement[] array = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(KatheriumElement.KatheriumOreSimHash.CreateTag(), 100f),
                new ComplexRecipe.RecipeElement(SimHashes.Water.CreateTag(), 10f)
            };
            ComplexRecipe.RecipeElement[] array2 = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(KatheriumElement.KatheriumSimHash.CreateTag(), 100f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false)
            };
            string id = ComplexRecipeManager.MakeRecipeID("ChemicalPlant", array, array2);
            ComplexRecipe complexRecipe = new ComplexRecipe(id, array, array2);
            complexRecipe.time = 10f;
            complexRecipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.Result;
            complexRecipe.description = string.Format(string.Concat(new string[]
            {
                "Refine ",SimHashes.Carbon.CreateTag().ProperName()," with intense heat, producing ",SimHashes.RefinedCarbon.CreateTag().ProperName(),"."}));
            complexRecipe.fabricators = new List<Tag>
            {
                TagManager.Create("ChemicalPlant")
            };
        }
    }

    [HarmonyPatch(typeof(ChemicalPlantConfig), "ConfigureBuildingTemplate")]
    public static class Sucrose_ChemicalPlant_Recipe
    {
        public static void Postfix()
        {
            if (DlcManager.IsExpansion1Active())
            {
                ComplexRecipe.RecipeElement[] array = new ComplexRecipe.RecipeElement[]
{
                new ComplexRecipe.RecipeElement(WoodLogConfig.TAG, 150f),
                new ComplexRecipe.RecipeElement(SulfuricAcidElement.SulfuricAcidSimHash.CreateTag(), 20f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false)
};
                ComplexRecipe.RecipeElement[] array2 = new ComplexRecipe.RecipeElement[]
                {
                new ComplexRecipe.RecipeElement(SimHashes.Sucrose.CreateTag(), 1f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false),
                new ComplexRecipe.RecipeElement(SimHashes.ToxicSand.CreateTag(), 1f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false)
                };
                string id = ComplexRecipeManager.MakeRecipeID("ChemicalPlant", array, array2);
                ComplexRecipe complexRecipe = new ComplexRecipe(id, array, array2);
                complexRecipe.time = 30f;
                complexRecipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.IngredientToResult;
                complexRecipe.description = string.Format(string.Concat(new string[]
                {
                "Produces ",SimHashes.Sucrose.CreateTag().ProperName()," from the pulp of ",WoodLogConfig.TAG.ProperName(),"."}));
                complexRecipe.fabricators = new List<Tag>
            {
                TagManager.Create("ChemicalPlant")
            };
            }
            else
            {
                ComplexRecipe.RecipeElement[] array = new ComplexRecipe.RecipeElement[]
            {
                new ComplexRecipe.RecipeElement(WoodLogConfig.TAG, 150f),
                new ComplexRecipe.RecipeElement(SulfuricAcidElement.SulfuricAcidSimHash.CreateTag(), 20f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false)
            };
                ComplexRecipe.RecipeElement[] array2 = new ComplexRecipe.RecipeElement[]
                {
                new ComplexRecipe.RecipeElement(SimHashes.Ethanol.CreateTag(), 1f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false),
                new ComplexRecipe.RecipeElement(SimHashes.ToxicSand.CreateTag(), 1f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false),
                new ComplexRecipe.RecipeElement(SimHashes.CarbonDioxide.CreateTag(), 30f, ComplexRecipe.RecipeElement.TemperatureOperation.AverageTemperature, false)
                };
                string id = ComplexRecipeManager.MakeRecipeID("ChemicalPlant", array, array2);
                ComplexRecipe complexRecipe = new ComplexRecipe(id, array, array2);
                complexRecipe.time = 30f;
                complexRecipe.nameDisplay = ComplexRecipe.RecipeNameDisplay.IngredientToResult;
                complexRecipe.description = string.Format(string.Concat(new string[]
                {
                "Produces ",SimHashes.Sucrose.CreateTag().ProperName()," from the pulp of ",WoodLogConfig.TAG.ProperName(),"."}));
                complexRecipe.fabricators = new List<Tag>
            {
                TagManager.Create("ChemicalPlant")
            };
            }
        }
    }
}
