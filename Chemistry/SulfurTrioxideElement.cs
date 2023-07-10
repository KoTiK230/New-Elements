using UnityEngine;

namespace New_Elements.Chemistry
{
    public static class SulfurTrioxideElement
    {
        public static readonly Color32 TRIOXIDE_YELLOW = new Color32(255, 244, 84, 255);
        public const string SOLIDSULFURTRIOXIDE_ID = "SolidSulfurTrioxide";
        public const string LIQUIDSULFURTRIOXIDE_ID = "LiquidSulfurTrioxide";
        public const string SULFURTRIOXIDE_ID = "SulfurTrioxide";

        public static readonly SimHashes LiquidSulfurTrioxideSimHash = (SimHashes)Hash.SDBMLower(LIQUIDSULFURTRIOXIDE_ID);
        public static readonly SimHashes SulfurTrioxideSimHash = (SimHashes)Hash.SDBMLower(SULFURTRIOXIDE_ID);
        public static readonly SimHashes SolidSulfurTrioxideSimHash = (SimHashes)Hash.SDBMLower(SOLIDSULFURTRIOXIDE_ID);

        public static void RegisterSulfurTrioxideSubstance()
        {
            ElementUtil.CreateRegisteredSubstance(
              name: SULFURTRIOXIDE_ID,
              state: Element.State.Gas,
              kanim: ElementUtil.FindAnim("gas_tank_kanim"),
              material: Assets.instance.substanceTable.liquidMaterial,
              colour: TRIOXIDE_YELLOW
            );
        }
        public static void RegisterLiquidSulfurTrioxideSubstance()
        {
            ElementUtil.CreateRegisteredSubstance(
              name: LIQUIDSULFURTRIOXIDE_ID,
              state: Element.State.Liquid,
              kanim: ElementUtil.FindAnim("liquid_tank_kanim"),
              material: Assets.instance.substanceTable.liquidMaterial,
              colour: TRIOXIDE_YELLOW
            );
        }

        static Texture2D TintTextureTrioxideYellow(Texture sourceTexture, string name)
        {
            Texture2D newTexture = Util.DuplicateTexture(sourceTexture as Texture2D);
            var pixels = newTexture.GetPixels32();
            for (int i = 0; i < pixels.Length; ++i)
            {
                var gray = ((Color)pixels[i]).grayscale * 1.5f;
                pixels[i] = (Color)TRIOXIDE_YELLOW * gray;
            }
            newTexture.SetPixels32(pixels);
            newTexture.Apply();
            newTexture.name = name;
            return newTexture;
        }

        static Material CreateSolidSulfurTrioxideMaterial(Material source)
        {
            var solidSulfurTrioxideMaterial = new Material(source);

            Texture2D newTexture = TintTextureTrioxideYellow(solidSulfurTrioxideMaterial.mainTexture, "solidsulfurtrioxide");

            solidSulfurTrioxideMaterial.mainTexture = newTexture;
            solidSulfurTrioxideMaterial.name = "matSolidSulfurTrioxide";

            return solidSulfurTrioxideMaterial;
        }

        public static void RegisterSolidSulfurTrioxideSubstance()
        {
            Substance sulfurtrioxide = Assets.instance.substanceTable.GetSubstance(SimHashes.SolidOxygen);

            ElementUtil.CreateRegisteredSubstance(
              name: SOLIDSULFURTRIOXIDE_ID,
              state: Element.State.Solid,
              kanim: ElementUtil.FindAnim("ice_kanim"),
              material: CreateSolidSulfurTrioxideMaterial(sulfurtrioxide.material),
              colour: TRIOXIDE_YELLOW
            );
        }
    }

}