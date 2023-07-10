using HarmonyLib;
using System.Collections.Generic;
using UnityEngine;
using System;
using STRINGS;

namespace New_Elements
{
    [HarmonyPatch(typeof(ElementLoader), "FinaliseElementsTable")]
    public static class YellowCakePatches
    {
        public static void Postfix()
        {
            Element elementByHash = ElementLoader.FindElementByHash(SimHashes.Yellowcake);
            elementByHash.disabled = false;
            elementByHash.radiationPer1000Mass = 50f;
            elementByHash.materialCategory = GameTags.ManufacturedMaterial;
            elementByHash.oreTags = new List<Tag>((IEnumerable<Tag>)elementByHash.oreTags)
        {
          GameTags.ManufacturedMaterial
        }.ToArray();
            GameTags.SolidElements.Add(elementByHash.tag);
        }
    }

    [HarmonyPatch(typeof(ElementLoader), "FinaliseElementsTable")]
    public static class EthanolPatches
    {
        public static void Postfix()
        {
            Element elementByHash = ElementLoader.FindElementByHash(SimHashes.Ethanol);
            elementByHash.toxicity = 20f;
        }
    }

    [HarmonyPatch(typeof(ElementLoader), "FinaliseElementsTable")]
    public static class PropanePatch
    {
        public static void Postfix()
        {
            Element elementByHash = ElementLoader.FindElementByHash(SimHashes.Propane);
            elementByHash.disabled = false;
        }
    }

    [HarmonyPatch(typeof(ElementLoader), "FinaliseElementsTable")]
    public static class HeliumPatch
    {
        public static void Postfix()
        {
            Element elementByHash = ElementLoader.FindElementByHash(SimHashes.Helium);
            elementByHash.disabled = false;
        }
    }

    [HarmonyPatch(typeof(ElementLoader), "FinaliseElementsTable")]
    public static class SyngasPatch
    {
        public static void Postfix()
        {
            Element elementByHash = ElementLoader.FindElementByHash(SimHashes.Syngas);
            elementByHash.disabled = false;
        }
    }

    [HarmonyPatch(typeof(ElementLoader), "FinaliseElementsTable")]
    public static class PhosphatePatch
    {
        public static void Postfix()
        {
            Element elementByHash = ElementLoader.FindElementByHash(SimHashes.PhosphateNodules);
            elementByHash.disabled = false;
        }
    }

    [HarmonyPatch(typeof(ElementLoader), "FinaliseElementsTable")]
    public static class CoriumPatch
    {
        public static void Postfix()
        {
            Element elementByHash = ElementLoader.FindElementByHash(SimHashes.Corium);
            elementByHash.radiationPer1000Mass = 300f;
            elementByHash.sublimateId = SimHashes.Fallout;
        }
    }

    [HarmonyPatch(typeof(ElementLoader), "FinaliseElementsTable")]
    public static class ChlorinePatch
    {
        public static void Postfix()
        {
            Element elementByHash = ElementLoader.FindElementByHash(SimHashes.ChlorineGas);
            elementByHash.toxicity = 10f;
        }
    }

    [HarmonyPatch(typeof(ElementLoader), "FinaliseElementsTable")]
    public static class CarbonDioxidePatch
    {
        public static void Postfix()
        {
            Element elementByHash = ElementLoader.FindElementByHash(SimHashes.CarbonDioxide);
            elementByHash.toxicity = 0f;
        }
    }

    [HarmonyPatch(typeof(ElementLoader), "FinaliseElementsTable")]
    public static class RadiumPatch
    {
        public static void Postfix()
        {
            Element elementByHash = ElementLoader.FindElementByHash(SimHashes.Radium);
            elementByHash.radiationPer1000Mass = 150f;
        }
    }
    /*[HarmonyPatch(nameof(GameTags))]
    public static class MaterialBuilding_Patch
    {
        public static void Prefix()
        {
            TagSet MaterialBuildingElements = new TagSet()
            {
    GameTags.BuildingFiber,
    GameTags.BuildingWood,
    KatheriumChipConfig.tag,
    QuantumComputerConfig.tag,
    AccumulatorEntityConfig.tag
            };
        }
    };
    
    /*[HarmonyPatch(typeof(ELEMENTS.SOURGAS))]
        public static class OilGasFix
        {
            public static void Prefix()
            {
                {
            LocString NAME = (LocString)UI.FormatAsLink("Oil Gas", nameof(ELEMENTS.SOURGAS));
            LocString NAME_TWO = (LocString)UI.FormatAsLink("Oil Gas", nameof(ELEMENTS.SOURGAS));
            LocString DESC = (LocString)("Oil Gas is a hydrocarbon " + UI.FormatAsLink("Gas", "ELEMENTS_GAS") + " containing high concentrations of hydrogen sulfide.\n\nIt is a byproduct of highly heated " + UI.FormatAsLink("Petroleum", "PETROLEUM") + ".");
                }
            }
        };*/
}
