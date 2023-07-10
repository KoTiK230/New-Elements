using UnityEngine;

namespace New_Elements.Chemistry
{
    public static class FluorineElement
    {
        public static readonly Color32 FLUORINE_BROWN = new Color32(161, 112, 29, 255);
        public const string FLUORINE_ID = "Fluorine";
        public const string FROZENFLUORINE_ID = "FrozenFluorine";
        public const string LIQUIDFLUORINE_ID = "LiquidFluorine";

        public static readonly SimHashes FluorineSimHash = (SimHashes)Hash.SDBMLower(FLUORINE_ID);
        public static readonly SimHashes LiquidFluorineSimHash = (SimHashes)Hash.SDBMLower(LIQUIDFLUORINE_ID);
        public static readonly SimHashes FrozenFluorineSimHash = (SimHashes)Hash.SDBMLower(FROZENFLUORINE_ID);

        static Texture2D TintTextureFluorineBrown(Texture sourceTexture, string name)
        {
            Texture2D newTexture = Util.DuplicateTexture(sourceTexture as Texture2D);
            var pixels = newTexture.GetPixels32();
            for (int i = 0; i < pixels.Length; ++i)
            {
                var gray = ((Color)pixels[i]).grayscale * 1.5f;
                pixels[i] = (Color)FLUORINE_BROWN * gray;
            }
            newTexture.SetPixels32(pixels);
            newTexture.Apply();
            newTexture.name = name;
            return newTexture;
        }

        public static void RegisterLiquidFluorineSubstance()
        {
            ElementUtil.CreateRegisteredSubstance(
              name: LIQUIDFLUORINE_ID,
              state: Element.State.Liquid,
              kanim: ElementUtil.FindAnim("liquid_tank_kanim"),
              material: Assets.instance.substanceTable.liquidMaterial,
              colour: FLUORINE_BROWN
            );
        }
        public static void RegisterFluorineSubstance()
        {
            ElementUtil.CreateRegisteredSubstance(
              name: FLUORINE_ID,
              state: Element.State.Gas,
              kanim: ElementUtil.FindAnim("gas_tank_kanim"),
              material: Assets.instance.substanceTable.liquidMaterial,
              colour: FLUORINE_BROWN
            );
        }

        static Material CreateFrozenFluorineMaterial(Material source)
        {
            var frozenFluorineMaterial = new Material(source);

            Texture2D newTexture = TintTextureFluorineBrown(frozenFluorineMaterial.mainTexture, "frozenfluorine");

            frozenFluorineMaterial.mainTexture = newTexture;
            frozenFluorineMaterial.name = "matFrozenFluorine";

            return frozenFluorineMaterial;
        }
        public static void RegisterFrozenFluorineSubstance()
        {
            Substance fluorine = Assets.instance.substanceTable.GetSubstance(SimHashes.SolidHydrogen);

            ElementUtil.CreateRegisteredSubstance(
              name: FROZENFLUORINE_ID,
              state: Element.State.Solid,
              kanim: ElementUtil.FindAnim("ice_kanim"),
              material: CreateFrozenFluorineMaterial(fluorine.material),
              colour: FLUORINE_BROWN
            );
        }
    }
}