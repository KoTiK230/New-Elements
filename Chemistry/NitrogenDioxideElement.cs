using UnityEngine;

namespace New_Elements.Chemistry
{
    public static class NitrogenDioxideElement
    {
        public static readonly Color32 NITROGENDIOXIDE_BROWN = new Color32(128, 65, 6, 255);
        public const string FROZENNITROGENDIOXIDE_ID = "FrozenNitrogenDioxide";
        public const string LIQUIDNITROGENDIOXIDE_ID = "LiquidNitrogenDioxide";
        public const string NITROGENDIOXIDE_ID = "NitrogenDioxide";

        public static readonly SimHashes LiquidNitrogenDioxideSimHash = (SimHashes)Hash.SDBMLower(LIQUIDNITROGENDIOXIDE_ID);
        public static readonly SimHashes NitrogenDioxideSimHash = (SimHashes)Hash.SDBMLower(NITROGENDIOXIDE_ID);
        public static readonly SimHashes FrozenNitrogenDioxideSimHash = (SimHashes)Hash.SDBMLower(FROZENNITROGENDIOXIDE_ID);

        public static void RegisterNitrogenDioxideSubstance()
        {
            ElementUtil.CreateRegisteredSubstance(
              name: NITROGENDIOXIDE_ID,
              state: Element.State.Gas,
              kanim: ElementUtil.FindAnim("gas_tank_kanim"),
              material: Assets.instance.substanceTable.liquidMaterial,
              colour: NITROGENDIOXIDE_BROWN
            );
        }
        public static void RegisterLiquidNitrogenDioxideSubstance()
        {
            ElementUtil.CreateRegisteredSubstance(
              name: LIQUIDNITROGENDIOXIDE_ID,
              state: Element.State.Liquid,
              kanim: ElementUtil.FindAnim("liquid_tank_kanim"),
              material: Assets.instance.substanceTable.liquidMaterial,
              colour: NITROGENDIOXIDE_BROWN
            );
        }

        static Texture2D TintTextureNitrogenDioxideBrown(Texture sourceTexture, string name)
        {
            Texture2D newTexture = Util.DuplicateTexture(sourceTexture as Texture2D);
            var pixels = newTexture.GetPixels32();
            for (int i = 0; i < pixels.Length; ++i)
            {
                var gray = ((Color)pixels[i]).grayscale * 1.5f;
                pixels[i] = (Color)NITROGENDIOXIDE_BROWN * gray;
            }
            newTexture.SetPixels32(pixels);
            newTexture.Apply();
            newTexture.name = name;
            return newTexture;
        }

        static Material CreateFrozenNitrogenDioxideMaterial(Material source)
        {
            var frozenNitrogenDioxideMaterial = new Material(source);

            Texture2D newTexture = TintTextureNitrogenDioxideBrown(frozenNitrogenDioxideMaterial.mainTexture, "frozennitrogendioxide");

            frozenNitrogenDioxideMaterial.mainTexture = newTexture;
            frozenNitrogenDioxideMaterial.name = "matFrozenNitrogenDioxide";

            return frozenNitrogenDioxideMaterial;
        }

        public static void RegisterFrozenNitrogenDioxideSubstance()
        {
            Substance nitrogendioxide = Assets.instance.substanceTable.GetSubstance(SimHashes.SolidOxygen);

            ElementUtil.CreateRegisteredSubstance(
              name: FROZENNITROGENDIOXIDE_ID,
              state: Element.State.Solid,
              kanim: ElementUtil.FindAnim("ice_kanim"),
              material: CreateFrozenNitrogenDioxideMaterial(nitrogendioxide.material),
              colour: NITROGENDIOXIDE_BROWN
            );
        }
    }

}