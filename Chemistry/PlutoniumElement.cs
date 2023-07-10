using UnityEngine;

namespace New_Elements.Chemistry
{
    class PlutoniumElement
    {

        public static readonly Color32 PLUTONIUM_BLUE = new Color32(110, 219, 255, 255);
        public const string LIQUIDPLUTONIUM_ID = "LiquidPlutonium";
        public const string PLUTONIUM_ID = "Plutonium";

        public static readonly SimHashes LiquidPlutoniumSimHash = (SimHashes)Hash.SDBMLower(LIQUIDPLUTONIUM_ID);
        public static readonly SimHashes PlutoniumSimHash = (SimHashes)Hash.SDBMLower(PLUTONIUM_ID);

        public static void RegisterLiquidPlutoniumSubstance()
        {
            ElementUtil.CreateRegisteredSubstance(
              name: LIQUIDPLUTONIUM_ID,
              state: Element.State.Liquid,
              kanim: ElementUtil.FindAnim("liquid_tank_kanim"),
              material: Assets.instance.substanceTable.liquidMaterial,
              colour: PLUTONIUM_BLUE
            );
        }

        static Texture2D TintTexturePlutoniumBlue(Texture sourceTexture, string name)
        {
            Texture2D newTexture = Util.DuplicateTexture(sourceTexture as Texture2D);
            var pixels = newTexture.GetPixels32();
            for (int i = 0; i < pixels.Length; ++i)
            {
                var gray = ((Color)pixels[i]).grayscale * 1.5f;
                pixels[i] = (Color)PLUTONIUM_BLUE * gray;
            }
            newTexture.SetPixels32(pixels);
            newTexture.Apply();
            newTexture.name = name;
            return newTexture;
        }

        static Material CreatePlutoniumMaterial(Material source)
        {
            var plutoniumMaterial = new Material(source);

            Texture2D newTexture = TintTexturePlutoniumBlue(plutoniumMaterial.mainTexture, "plutonium");

            plutoniumMaterial.mainTexture = newTexture;
            plutoniumMaterial.name = "matPlutonium";

            return plutoniumMaterial;
        }

        public static void RegisterPlutoniumSubstance()
        {
            Substance plutonium = Assets.instance.substanceTable.GetSubstance(SimHashes.FoolsGold);

            ElementUtil.CreateRegisteredSubstance(
              name: PLUTONIUM_ID,
              state: Element.State.Solid,
              kanim: ElementUtil.FindAnim("cuprite_kanim"),
              material: CreatePlutoniumMaterial(plutonium.material),
              colour: PLUTONIUM_BLUE
            );
        }
    }
}
