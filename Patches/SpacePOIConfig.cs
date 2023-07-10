using HarmonyLib;
using UnityEngine;
using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Collections.Generic;
using New_Elements.Chemistry;
using Database;
using PeterHan.PLib.Core;

namespace New_Elements
{
    class SpacePOIConfig
    {
        [HarmonyPatch(typeof(Db))]
        [HarmonyPatch("Initialize")]
        public static class Db_Init_Patch
        {
            static MethodInfo GetMethodInfo(Type classType, string methodName)
            {
                BindingFlags flags = BindingFlags.Public
                                                    | BindingFlags.NonPublic
                                                    | BindingFlags.Static
                                                    | BindingFlags.Instance;

                MethodInfo method = classType.GetMethod(methodName, flags);
                if (method == null)
                    Debug.Log($"Error - {methodName} method is null...");

                return method;
            }

            public static void Postfix()
            {
                MethodInfo patched = GetMethodInfo(typeof(HarvestablePOIConfig), "GenerateConfigs");
                MethodInfo postfix = GetMethodInfo(typeof(SpacePOI), "Postfix");
                // TODO: Update line below
                Harmony harmony = new Harmony("your.mod.staticId");
                harmony.Patch(patched, null, new HarmonyMethod(postfix));
            }
        }

        private static readonly List<string> GasFieldOrbit = new List<string>()
  {
    Db.Get().OrbitalTypeCategories.iceCloud.Id,
    Db.Get().OrbitalTypeCategories.heliumCloud.Id,
    Db.Get().OrbitalTypeCategories.purpleGas.Id,
    Db.Get().OrbitalTypeCategories.radioactiveGas.Id
  };
        private static readonly List<string> AsteroidFieldOrbit = new List<string>()
  {
    Db.Get().OrbitalTypeCategories.iceRock.Id,
    Db.Get().OrbitalTypeCategories.frozenOre.Id,
    Db.Get().OrbitalTypeCategories.rocky.Id
  };

        [HarmonyPatch()]

        static MethodBase TargetMethod()
        {
            return typeof(HarvestablePOIConfig).GetNestedType("List<HarvestablePOIConfig.HarvestablePOIParams>", BindingFlags.NonPublic).GetMethod("GenerateConfigs");

        }

        public const string NitrogenComet = "NitrogenComet";
        public const string SulfurOxideField = "SulfurOxideField";
        public const string PhophoriteField = "PhophoriteField";
        public const string AmmoniaField = "AmmoniaField";
        public const string KatheriumField = "KatheriumField";
        public const string AbyssaliteField = "AbyssaliteField";

        public static class SpacePOI

        {
            public static void Postfix(List<HarvestablePOIConfig.HarvestablePOIParams> __result)
            {
                __result.Add(new HarvestablePOIConfig.HarvestablePOIParams("cloud", new HarvestablePOIConfigurator.HarvestablePOIType("NitrogenComet", new Dictionary<SimHashes, float>()
                {
      {
        NitrogenElement.NitrogenSimHash,
        3.5f
      },
                    {
        SimHashes.Ice,
       2.5f
                    },
      {
        NitrogenElement.FrozenNitrogenSimHash,
       2.5f
      }
                }, 30000f, 45000f, orbitalObject: SpacePOIConfig.AsteroidFieldOrbit)));
                __result.Add(new HarvestablePOIConfig.HarvestablePOIParams("cloud", new HarvestablePOIConfigurator.HarvestablePOIType("SulfurOxideField", new Dictionary<SimHashes, float>()
                {
      {
        SulfurTrioxideElement.SulfurTrioxideSimHash,
        3.5f
      },
      {
        SimHashes.Sulfur,
        4f
      },
      {
        SimHashes.SulfurGas,
        2.5f
      }
                }, 30000f, 45000f, orbitalObject: SpacePOIConfig.AsteroidFieldOrbit)));
                __result.Add(new HarvestablePOIConfig.HarvestablePOIParams("cloud", new HarvestablePOIConfigurator.HarvestablePOIType("PhophoriteField", new Dictionary<SimHashes, float>()
                {
      {
        SimHashes.PhosphorusGas,
        1.5f
      },
      {
        SimHashes.PhosphateNodules,
        3.5f
      },
      {
        SimHashes.Phosphorite,
        5f
      }
                }, 30000f, 45000f, orbitalObject: SpacePOIConfig.AsteroidFieldOrbit)));
                __result.Add(new HarvestablePOIConfig.HarvestablePOIParams("cloud", new HarvestablePOIConfigurator.HarvestablePOIType("AmmoniaField", new Dictionary<SimHashes, float>()
                {
      {
        SimHashes.Hydrogen,
        3.5f
      },
      {
        AmmoniaElement.FrozenAmmoniaSimHash,
        6.5f
      }
                }, 30000f, 45000f, orbitalObject: SpacePOIConfig.AsteroidFieldOrbit)));
                __result.Add(new HarvestablePOIConfig.HarvestablePOIParams("cloud", new HarvestablePOIConfigurator.HarvestablePOIType("KatheriumField", new Dictionary<SimHashes, float>()
                {
      {
        KatheriumElement.KatheriumOreSimHash,
        2.5f
      },
      {
        SimHashes.IgneousRock,
        4f
      },
      {
        SimHashes.SedimentaryRock,
        1.5f
      },
      {
        SimHashes.CarbonDioxide,
        2f
      }
                }, 30000f, 45000f, orbitalObject: SpacePOIConfig.AsteroidFieldOrbit)));
                __result.Add(new HarvestablePOIConfig.HarvestablePOIParams("cloud", new HarvestablePOIConfigurator.HarvestablePOIType("AbyssaliteField", new Dictionary<SimHashes, float>()
                {
      {
        SimHashes.Katairite,
        1.5f
      },
      {
        SimHashes.TungstenGas,
        2f
      },
                    {
                        SimHashes.Obsidian,
                        6.5f
                    }
                }, 30000f, 45000f, orbitalObject: SpacePOIConfig.AsteroidFieldOrbit)));
            }
        }
    }
}
