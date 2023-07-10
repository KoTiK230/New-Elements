using HarmonyLib;
using Database;
using System.Collections.Generic;
using System;
using UnityEngine;
using UtilLibs;
using New_Elements.Buildings;

namespace New_Elements
{
    internal class ResearchTreePatches
    {/// <summary>
     /// add research card to research screen
     /// </summary>
        public class Techs
        {
            public static string ChemicalTech = "ChemicalTech";
            public static string PlutoniumTech = "PlutoniumTech";
            public static string MixerTech = "MixerTech";
            public static string OilPlantTech = "OilPlantTech";
            public static string ImprovedOilExtractionTech = "ImprovedOilExtractionTech";
            public static string SuperConductorTech = "SuperConductorTech";
            public static string SuperConductorElectronicsTech = "SuperConductorElectronicsTech";
            public static string SuperConductorTurbineTech = "SuperConductorTurbineTech";
        }
        [HarmonyPatch(typeof(ResourceTreeLoader<ResourceTreeNode>), MethodType.Constructor, typeof(TextAsset))]
        public class ResourceTreeLoader_Load_Patch
        {
            public static void Postfix(ResourceTreeLoader<ResourceTreeNode> __instance, TextAsset file)
            {
                if (DlcManager.IsExpansion1Active())
                {
                    TechUtils.AddNode(__instance,
                        Techs.PlutoniumTech,
                        GameStrings.Technology.ColonyDevelopment.RadboltPropulsion,
                        GameStrings.Technology.ColonyDevelopment.CryoFuelPropulsion,
                        GameStrings.Technology.ColonyDevelopment.RadboltPropulsion
                        );
                }

                TechUtils.AddNode(__instance,
                Techs.ChemicalTech,
                GameStrings.Technology.Liquids.LiquidBasedRefinementProcess,
                GameStrings.Technology.Liquids.AdvancedCaffeination,
                GameStrings.Technology.Liquids.LiquidBasedRefinementProcess
                );

                if (DlcManager.IsExpansion1Active())
                {
                    TechUtils.AddNode(__instance,
                    Techs.OilPlantTech,
                    GameStrings.Technology.Power.ValveMiniaturization,
                    GameStrings.Technology.SolidMaterial.SolidManagement,
                    GameStrings.Technology.Power.AdvancedCombustion
                    );
                    TechUtils.AddNode(__instance,
                    Techs.ImprovedOilExtractionTech,
                    new[] { Techs.OilPlantTech, Techs.SuperConductorElectronicsTech },
                    GameStrings.Technology.ColonyDevelopment.CryoFuelPropulsion,
                    GameStrings.Technology.Power.AdvancedCombustion
                    );
                    TechUtils.AddNode(__instance,
                    Techs.SuperConductorTech,
                    GameStrings.Technology.Power.SpacePower,
                    GameStrings.Technology.Power.HydrocarbonPropulsion,
                    GameStrings.Technology.Power.SoundAmplifiers
                    );
                    TechUtils.AddNode(__instance,
                    Techs.SuperConductorElectronicsTech,
                    Techs.SuperConductorTech,
                    GameStrings.Technology.Power.ImprovedHydrocarbonPropulsion,
                    GameStrings.Technology.Power.SoundAmplifiers
                    );
                    TechUtils.AddNode(__instance,
                    Techs.SuperConductorTurbineTech,
                    new[] { GameStrings.Technology.Power.RenewableEnergy, Techs.SuperConductorElectronicsTech },
                    GameStrings.Technology.ColonyDevelopment.CryoFuelPropulsion,
                    GameStrings.Technology.Power.RenewableEnergy
                    );
                }
                else
                {
                    TechUtils.AddNode(__instance,
                    Techs.OilPlantTech,
                    GameStrings.Technology.Power.ValveMiniaturization,
                    GameStrings.Technology.SolidMaterial.SolidManagement,
                    GameStrings.Technology.Power.ValveMiniaturization
                    );
                    TechUtils.AddNode(__instance,
                    Techs.ImprovedOilExtractionTech,
                    new[] { Techs.OilPlantTech, Techs.SuperConductorElectronicsTech },
                    GameStrings.Technology.Rocketry.IntroductoryRocketry,
                    GameStrings.Technology.Power.ValveMiniaturization
                    );
                    TechUtils.AddNode(__instance,
                    Techs.SuperConductorTech,
                    GameStrings.Technology.Power.LowResistanceConductors,
                    GameStrings.Technology.Power.ValveMiniaturization,
                    GameStrings.Technology.Power.SoundAmplifiers
                    );
                    TechUtils.AddNode(__instance,
                    Techs.SuperConductorElectronicsTech,
                    Techs.SuperConductorTech,
                    GameStrings.Technology.SolidMaterial.SolidManagement,
                    GameStrings.Technology.Power.SoundAmplifiers
                    );
                    TechUtils.AddNode(__instance,
                    Techs.SuperConductorTurbineTech,
                    new[] { GameStrings.Technology.Power.RenewableEnergy, Techs.SuperConductorElectronicsTech },
                    GameStrings.Technology.Rocketry.IntroductoryRocketry,
                    GameStrings.Technology.Power.RenewableEnergy
                    );
                }
                TechUtils.AddNode(__instance,
                    Techs.MixerTech,
                    new[] { Techs.ChemicalTech, GameStrings.Technology.Gases.Catalytics },
                    GameStrings.Technology.Liquids.Jetpacks,
                    GameStrings.Technology.Gases.Catalytics
                    );
            }
        }

        /// <summary>
        /// Add research node to tree
        /// </summary>
        [HarmonyPatch(typeof(Database.Techs), "Init")]
        public class Techs_TargetMethod_Patch
        {
            public static void Postfix(Database.Techs __instance)
            {
                if (DlcManager.IsExpansion1Active())
                {
                    new Tech(Techs.PlutoniumTech, new List<string>
                {
                    ParticleAcceleratorConfig.ID,
                    //AdvancedNuclearReactorConfig.ID
                },
                    __instance
                    ,new Dictionary<string, float>()
                    {
                        {"basic", 50f },
                        {"advanced", 50f},
                        {"orbital", 400f},
                        {"nuclear", 0f},
                        {"molecular", 50f}
                    }
                    );
                }

                new Tech(Techs.ChemicalTech, new List<string>
                {
                    ChemicalPlantConfig.ID,
                },
                __instance
                );

                new Tech(Techs.SuperConductorTech, new List<string>
                {
                    SuperConductorWireTinyConfig.ID,
                    SuperConductorWireTinyBridgeConfig.ID,
                    SuperConductorWireThiccConfig.ID,
                    SuperConductorWireThiccBridgeConfig.ID,
                    SuperConductorTransformerConfig.ID,
                },
                __instance
                );

                new Tech(Techs.OilPlantTech, new List<string>
                {
                    OilPlantConfig.ID,
                },
                __instance
                );

                new Tech(Techs.ImprovedOilExtractionTech, new List<string>
                {
                    AdvancedOilWellCapConfig.ID,
                },
                __instance
                );

                new Tech(Techs.MixerTech, new List<string>
                {
                    MixerConfig.ID,
                },
                __instance
                );

                new Tech(Techs.SuperConductorElectronicsTech, new List<string>
                {
                    MixerConfig.ID,
                },
                __instance
                );

                new Tech(Techs.SuperConductorTurbineTech, new List<string>
                {
                    HighTempSteamTurbineConfig.ID,
                },
                __instance
                );
            }
        }
        [HarmonyPatch(typeof(ResearchTypes))]
        [HarmonyPatch(MethodType.Constructor)]
        [HarmonyPatch(new Type[] { })]
        public static class NewResearchPoint

        {
            public static void Postfix(ResearchTypes __instance)
            {
                __instance.Types.Add(new ResearchType("molecular", "Sigma", "If you see this, it works!", Assets.GetSprite((HashedString)"research_type_alpha_icon"), (Color)new Color32((byte)235, (byte)52, (byte)210, byte.MaxValue), new Recipe.Ingredient[1]
    {
      new Recipe.Ingredient(SimHashes.Phosphorus.CreateTag(), 50f)
    }, 600f, (HashedString)"research_center_kanim", new string[1]
    {
      "ResearchCenter"
    }, "idk"));
            }
        }
    }
}