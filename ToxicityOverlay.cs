using STRINGS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using HarmonyLib;
using UnityEngine;
using System.Reflection;
using System.Reflection.Emit;
using ChemicalBurn;

namespace New_Elements
{
    class ToxicityOverlay : OverlayModes.Mode
    {
        public static readonly HashedString ID = nameof(ToxicityOverlay);
        public const string Icon = "overlay_temerature";
        public const string Name = "Toxicity Overlay";
        public const string Desc = "Газовая камера";
        public const string Sound = "Temperature";
        public const string LocName = "MAPOVERLAY.TITLE";
        public static string hazardLevel;
        public static int damage;
        public static int DamageCalc(int cell)
        {
            Element element1 = Grid.Element[cell];
            float mass1 = Grid.Mass[cell];
            float multiplier1;
            if (element1.toxicity > 0f && mass1 > 0.2f)
            {
                if (element1.IsGas) { multiplier1 = 10f; } else { multiplier1 = 0.01f; }
                damage = Convert.ToInt32(Math.Sqrt(element1.toxicity * mass1 * multiplier1));
                return damage;
            }
            else return damage = 0;
        }

        public static Color GetBackgroundColor(int cell)
        {
            Color color = new Color(1f, 0.7f, 0.11f, 1f);
            color.a = DamageCalc(cell)/100f;
            return color;
        }

        public List<LegendEntry> toxicLegend = new List<LegendEntry>()
    {

      new LegendEntry("5 Hazard", "test", new Color(1f, 0.7f, 0.11f, 1f)),
      new LegendEntry("4 Hazard", "test", new Color(1f, 0.7f, 0.11f, 0.8f)),
      new LegendEntry("3 Hazard", "test", new Color(1f, 0.7f, 0.11f, 0.6f)),
      new LegendEntry("2 Hazard", "test", new Color(1f, 0.7f, 0.11f, 0.4f)),
      new LegendEntry("1 Hazard", "test", new Color(1f, 0.7f, 0.11f, 0.2f)),
      new LegendEntry("Safe area", "test", new Color(1f, 0.7f, 0.11f, 0f))
    };
        public override List<LegendEntry> GetCustomLegendData()
        {
            return this.toxicLegend;
        }

        [HarmonyPatch(typeof(SelectToolHoverTextCard), "UpdateHoverElements")]
        public static class SelectToolHoverTextCard_UpdateHoverElements_Patch
        {
            private static readonly FieldInfo InfoId = AccessTools.Field(typeof(New_Elements.ToxicityOverlay), "ID");
            private static readonly FieldInfo LogicId = AccessTools.Field(typeof(OverlayModes.Logic), "ID");
            private static readonly MethodInfo HashEq = AccessTools.Method(typeof(HashedString), "op_Equality", new System.Type[2]
            {
        typeof (HashedString),
        typeof (HashedString)
            }, (System.Type[])null);
            private static readonly MethodInfo Helper = AccessTools.Method(typeof(ToxicityOverlay.SelectToolHoverTextCard_UpdateHoverElements_Patch), "DrawerHelper", (System.Type[])null, (System.Type[])null);

            public static IEnumerable<CodeInstruction> Transpiler(
              IEnumerable<CodeInstruction> orig,
              ILGenerator generator)
            {
                List<CodeInstruction> list = orig.ToList<CodeInstruction>();
                int index1 = list.FindIndex((Predicate<CodeInstruction>)(ci =>
                {
                    FieldInfo operand = ci.operand as FieldInfo;
                    return (object)operand != null && operand == ToxicityOverlay.SelectToolHoverTextCard_UpdateHoverElements_Patch.LogicId;
                }));
                System.Reflection.Emit.Label label1 = generator.DefineLabel();
                list[index1 + 2].operand = (ValueType)label1;
                int index2 = list.FindIndex(index1, (Predicate<CodeInstruction>)(ci => (OpCode)ci.opcode == OpCodes.Endfinally)) + 1;
                System.Reflection.Emit.Label label2 = generator.DefineLabel();
                ((List<System.Reflection.Emit.Label>)list[index2].labels).Add(label2);
                int index3 = index2;
                int num1 = index3 + 1;
                CodeInstruction codeInstruction = new CodeInstruction(OpCodes.Ldloc_2, (object)null);
                ((List<System.Reflection.Emit.Label>)codeInstruction.labels).Add(label1);
                list.Insert(index3, codeInstruction);
                int index4 = num1;
                int num2 = index4 + 1;
                list.Insert(index4, new CodeInstruction(OpCodes.Ldsfld, (object)ToxicityOverlay.SelectToolHoverTextCard_UpdateHoverElements_Patch.InfoId));
                int index5 = num2;
                int num3 = index5 + 1;
                list.Insert(index5, new CodeInstruction(OpCodes.Call, (object)ToxicityOverlay.SelectToolHoverTextCard_UpdateHoverElements_Patch.HashEq));
                int index6 = num3;
                int num4 = index6 + 1;
                list.Insert(index6, new CodeInstruction(OpCodes.Brfalse, (object)label2));
                int index7 = num4;
                int num5 = index7 + 1;
                list.Insert(index7, new CodeInstruction(OpCodes.Ldarg_0, (object)null));
                int index8 = num5;
                int num6 = index8 + 1;
                list.Insert(index8, new CodeInstruction(OpCodes.Ldloc_0, (object)null));
                int index9 = num6;
                int num7 = index9 + 1;
                list.Insert(index9, new CodeInstruction(OpCodes.Ldloc_1, (object)null));
                int index10 = num7;
                int num8 = index10 + 1;
                list.Insert(index10, new CodeInstruction(OpCodes.Call, (object)ToxicityOverlay.SelectToolHoverTextCard_UpdateHoverElements_Patch.Helper));
                int index11 = num8;
                int num9 = index11 + 1;
                list.Insert(index11, new CodeInstruction(OpCodes.Br, (object)label2));
                return (IEnumerable<CodeInstruction>)list;
            }
            public static void DrawerHelper(SelectToolHoverTextCard inst, int cell, HoverTextDrawer drawer)
            {
                if (SimDebugView.Instance.GetMode() == New_Elements.ToxicityOverlay.ID)
                {
                    Camera main = Camera.main;
                    if (main != null)
                        cell = Grid.PosToCell(main.ScreenToWorldPoint(KInputManager.GetMousePos()));
                    if (Grid.Element[cell] != null)
                    {
                         int damage = DamageCalc(cell);
                        switch (damage)
                        {
                            case 0:
                                hazardLevel = "Safe area";
                                break;
                            case int i when (0 < i && i < 10):
                                hazardLevel = "1 Hazard";
                                break;
                            case int i when (10 <= i && i < 30):
                                hazardLevel = "2 Hazard";
                                break;
                            case int i when (30 <= i && i < 60):
                                hazardLevel = "3 Hazard";
                                break;
                            case int i when (60 <= i && i < 100):
                                hazardLevel = "4 Hazard";
                                break;
                            case int i when (100 <= i):
                                hazardLevel = "5 Hazard";
                                break;
                        }
                        /*if (damage == 0) { hazardLevel = "Safe area"; }
                        else if (0 < damage && damage < 10) { hazardLevel = "1 Hazard"; }
                        else if (10 <= damage && damage < 30) { hazardLevel = "2 Hazard"; }
                        else if (30 <= damage && damage < 60) { hazardLevel = "3 Hazard"; }
                        else if (60 <= damage && damage < 100) { hazardLevel = "4 Hazard"; }
                        else if (100 <= damage) { hazardLevel = "5 Hazard"; }*/
                    }
                    drawer.BeginShadowBar();
                    drawer.DrawText("TOXICITY", inst.Styles_Title.Standard);
                    drawer.NewLine();
                    drawer.DrawText("Duplicunts will recieve "+ damage + " damage in this area (" + hazardLevel + ")", inst.Styles_BodyText.Standard);
                    drawer.EndShadowBar();
                }
            }
        }

        public override string GetSoundName()
        {
            return Sound;
        }
        public override HashedString ViewMode()
        {
            return ID;
        }
    }
}
