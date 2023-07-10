using System.Collections.Generic;
    using HarmonyLib;
    using STRINGS;
    using UnityEngine;
    using Klei;
    using UtilLibs;
    using ProcGen;
    using Newtonsoft.Json;
    using New_Elements;
namespace Wires_Patch
{
    [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
    public static class Wires_Patch_UI
    {
        public static void Prefix()
        {
            ModUtil.AddBuildingToPlanScreen("Power", "SuperConductorWireTiny");
            ModUtil.AddBuildingToPlanScreen("Power", "SuperConductorWireTinyBridge");
            ModUtil.AddBuildingToPlanScreen("Power", "SuperConductorWireThicc");
            ModUtil.AddBuildingToPlanScreen("Power", "SuperConductorWireThiccBridge");
            ModUtil.AddBuildingToPlanScreen("Power", "SuperConductorTransformer");
        }
    }
}
namespace AdvancedApothecary
{
    [HarmonyPatch(typeof(AdvancedApothecaryConfig), "CreateBuildingDef")]
    public static class AdvancedApothecaryConfig_CreateBuildingDef_Patch
    {
        public static void Postfix(BuildingDef __result)
        { 
            __result.Deprecated = false;
        }

    }
    [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
    public static class AdvancedApothecaryUI
    {
        public static void Prefix()
        {
            ModUtil.AddBuildingToPlanScreen("Medical", "AdvancedApothecary");
        }
    }
}
namespace SuperOilWellCap_Patch
{
    [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
    public static class AdvancedoilWellCapUI
    {
        public static void Prefix()
        {
            ModUtil.AddBuildingToPlanScreen("Utilities", "AdvancedOilWellCap");
        }
    }
}

namespace HighTempSteamTurbine_Patch
{
    [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
    public static class HighTempSteamTurbineUI
    {
        public static void Prefix()
        {
            ModUtil.AddBuildingToPlanScreen("Power", "HighTempSteamTurbine");
        }
    }
}

namespace MolecularResearchCenter_Patch
{
    [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
    public static class MolecularResearchCenterUI
    {
        public static void Prefix()
        {
            ModUtil.AddBuildingToPlanScreen("Equipment", "MolecularResearchCenter");
        }
    }
}

namespace MolecularResearchCenter_Patch
{
    [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
    public static class RocketAccumulatorModuleUI
    {
        public static void Prefix()
        {
            RocketryUtils.AddRocketModuleToBuildList(AccumulatorModuleConfig.ID, RocketryUtils.RocketCategory.power, "HabitatModuleMedium");
        }
    }
}

namespace AdvancedKiln_Patch
{
    [HarmonyPatch(typeof(Db), "Initialize")]
    internal class AdvancedKilnTechMod
    {
        private static void Postfix()
        {
            Db.Get().Techs.Get("HighTempForging").unlockedItemIDs.Add("AdvancedKiln");
        }
    }

    [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
    internal class AdvancedKilnUI
    {
        private static void Prefix()
        {
            string[] value = new string[]
            {
                "STRINGS.BUILDINGS.PREFABS.ADVANCEDKILN.NAME",
                "Advanced Kiln"
            };
            Strings.Add(value);
            string[] value2 = new string[]
            {
                "STRINGS.BUILDINGS.PREFABS.ADVANCEDKILN.DESC",
                "An advanced form of Kiln that uses induction to produce heat."
            };
            Strings.Add(value2);
            string[] value3 = new string[]
            {
                "STRINGS.BUILDINGS.PREFABS.ADVANCEDKILN.EFFECT",
                "The advantage of the induction kiln is a clean, energy-efficient and well-controllable heating process compared to most other means of fuel heating."
            };
            Strings.Add(value3);
            ModUtil.AddBuildingToPlanScreen("Refining", "AdvancedKiln");
        }
    }
}
namespace CoalHeatGenerator
{
    [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
    internal class CoalHeatGeneratorUI
    {
        private static void Prefix()
        {
            string[] value = new string[]
            {
                "STRINGS.BUILDINGS.PREFABS.COALHEATGENERATOR.NAME",
                "Coal Heat Generator"
            };
            Strings.Add(value);
            string[] value2 = new string[]
            {
                "STRINGS.BUILDINGS.PREFABS.COALHEATGENERATOR.DESC",
                "Test"
            };
            Strings.Add(value2);
            string[] value3 = new string[]
            {
                "STRINGS.BUILDINGS.PREFABS.COALHEATGENERATOR.EFFECT",
                "Test."
            };
            Strings.Add(value3);
            ModUtil.AddBuildingToPlanScreen("Utilities", "CoalHeatGenerator");
        }
    }
}
namespace MinerMK1_Patch
{
    [HarmonyPatch(typeof(Db), "Initialize")]
    internal class MinerMK1TechMod
    {
        private static void Postfix()
        {
            Db.Get().Techs.Get("HighTempForging").unlockedItemIDs.Add("MinerMK1");
        }
    }

    [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
    internal class MinerMK1UI
    {
        private static void Prefix()
        {
            string[] value = new string[]
            {
                "STRINGS.BUILDINGS.PREFABS.MINERMK1.NAME",
                "MinerMK1"
            };
            Strings.Add(value);
            string[] value2 = new string[]
            {
                "STRINGS.BUILDINGS.PREFABS.MINERMK1.DESC",
                "Test."
            };
            Strings.Add(value2);
            string[] value3 = new string[]
            {
                "STRINGS.BUILDINGS.PREFABS.MINERMK1.EFFECT",
                "Test."
            };
            Strings.Add(value3);
            ModUtil.AddBuildingToPlanScreen("Refining", "MinerMK1");
        }
    }
}

namespace DroneBotHive_Patch
{
    [HarmonyPatch(typeof(Db), "Initialize")]
    internal class DroneBotHiveTechMod
    {
        private static void Postfix()
        {
            Db.Get().Techs.Get("HighTempForging").unlockedItemIDs.Add("DroneBotHive");
        }
    }

    [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
    internal class DroneBotHiveUI
    {
        private static void Prefix()
        {
            string[] value = new string[]
            {
                "STRINGS.BUILDINGS.PREFABS.DRONEBOTHIVE.NAME",
                "Drone Hive"
            };
            Strings.Add(value);
            string[] value2 = new string[]
            {
                "STRINGS.BUILDINGS.PREFABS.DRONEBOTHIVE.DESC",
                "Test."
            };
            Strings.Add(value2);
            string[] value3 = new string[]
            {
                "STRINGS.BUILDINGS.PREFABS.DRONEBOTHIVE.EFFECT",
                "Test."
            };
            Strings.Add(value3);
            ModUtil.AddBuildingToPlanScreen("Refining", "DroneBotHive");
        }
    }
}

namespace OilPlant_Patch
{
    [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
    internal class OilPlantUI
    {
        private static void Prefix()
        {
            string[] value = new string[]
            {
                "STRINGS.BUILDINGS.PREFABS.OILPLANT.NAME",
                "OilPlant"
            };
            Strings.Add(value);
            string[] value2 = new string[]
            {
                "STRINGS.BUILDINGS.PREFABS.OILPLANT.DESC",
                "Test."
            };
            Strings.Add(value2);
            string[] value3 = new string[]
            {
                "STRINGS.BUILDINGS.PREFABS.OILPLANT.EFFECT",
                "Test."
            };
            Strings.Add(value3);
            ModUtil.AddBuildingToPlanScreen("Refining", "OilPlant");
        }
    }
}
namespace Mixer_Patch
{

    [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
    internal class MixerUI
    {
        private static void Prefix()
        {
            string[] value = new string[]
            {
                "STRINGS.BUILDINGS.PREFABS.MIXER.NAME",
                "Mixer"
            };
            Strings.Add(value);
            string[] value2 = new string[]
            {
                "STRINGS.BUILDINGS.PREFABS.MIXER.DESC",
                "Test."
            };
            Strings.Add(value2);
            string[] value3 = new string[]
            {
                "STRINGS.BUILDINGS.PREFABS.MIXER.EFFECT",
                "Test."
            };
            Strings.Add(value3);
            ModUtil.AddBuildingToPlanScreen("Refining", "Mixer");
        }
    }
}
namespace ChemicalPlant_Patch
{
    [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
    internal class ChemicalPlantUI
    {
        private static void Prefix()
        {
            string[] value = new string[]
            {
                "STRINGS.BUILDINGS.PREFABS.CHEMICALPLANT.NAME",
                "ChemicalPlant"
            };
            Strings.Add(value);
            string[] value2 = new string[]
            {
                "STRINGS.BUILDINGS.PREFABS.CHEMICALPLANT.DESC",
                "Test."
            };
            Strings.Add(value2);
            string[] value3 = new string[]
            {
                "STRINGS.BUILDINGS.PREFABS.CHEMICALPLANT.EFFECT",
                "Test."
            };
            Strings.Add(value3);
            ModUtil.AddBuildingToPlanScreen("Refining", "ChemicalPlant");
        }
    }
}
    namespace ParticleAccelerator
    {
        [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
        internal class ParticleAcceleratorUI
        {
            private static void Prefix()
            {
                string[] value = new string[]
                {
                "STRINGS.BUILDINGS.PREFABS.PARTICLEACCELERATOR.NAME",
                "Particle Accelerator"
                };
                Strings.Add(value);
                string[] value2 = new string[]
                {
                "STRINGS.BUILDINGS.PREFABS.PARTICLEACCELERATOR.DESC",
                "Test."
                };
                Strings.Add(value2);
                string[] value3 = new string[]
                {
                "STRINGS.BUILDINGS.PREFABS.PARTICLEACCELERATOR.EFFECT",
                "Test."
                };
                Strings.Add(value3);
                ModUtil.AddBuildingToPlanScreen("HEP", "ParticleAccelerator");
            }
        }
    }
    namespace AdvancedNuclearReactorAccelerator
    {
        [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
        internal class AdvancedNuclearReactorUI
        {
            private static void Prefix()
            {
                string[] value = new string[]
                {
                "STRINGS.BUILDINGS.PREFABS.ADVANCEDNUCLEARREACTOR.NAME",
                "Advanced Nuclear Reactor"
                };
                Strings.Add(value);
                string[] value2 = new string[]
                {
                "STRINGS.BUILDINGS.PREFABS.ADVANCEDNUCLEARREACTOR.DESC",
                "Test."
                };
                Strings.Add(value2);
                string[] value3 = new string[]
                {
                "STRINGS.BUILDINGS.PREFABS.ADVANCEDNUCLEARREACTOR.EFFECT",
                "Test."
                };
                Strings.Add(value3);
                ModUtil.AddBuildingToPlanScreen("HEP", "AdvancedNuclearReactor");
            }
        }
    }