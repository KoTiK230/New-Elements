using UnityEngine;

namespace New_Elements.Chemistry
{
    class KatheriumElement
    {
        public static readonly Color32 KATHERIUM_GOLD = new Color32(252, 255, 77, 255);
        public const string GASKATHERIUM_ID = "GasKatherium";
        public const string LIQUIDKATHERIUM_ID = "LiquidKatherium";
        public const string KATHERIUM_ID = "Katherium";
        public const string KATHERIUMORE_ID = "KatheriumOre";

        public static readonly SimHashes LiquidKatheriumSimHash = (SimHashes)Hash.SDBMLower(LIQUIDKATHERIUM_ID);
        public static readonly SimHashes KatheriumSimHash = (SimHashes)Hash.SDBMLower(KATHERIUM_ID);
        public static readonly SimHashes GasKatheriumSimHash = (SimHashes)Hash.SDBMLower(GASKATHERIUM_ID);
        public static readonly SimHashes KatheriumOreSimHash = (SimHashes)Hash.SDBMLower(KATHERIUMORE_ID);

        public static void RegisterGasKatheriumSubstance()
        {
            ElementUtil.CreateRegisteredSubstance(
              name: GASKATHERIUM_ID,
              state: Element.State.Gas,
              kanim: ElementUtil.FindAnim("gas_tank_kanim"),
              material: Assets.instance.substanceTable.liquidMaterial,
              colour: KATHERIUM_GOLD
            );
        }
        public static void RegisterLiquidKatheriumSubstance()
        {
            ElementUtil.CreateRegisteredSubstance(
              name: LIQUIDKATHERIUM_ID,
              state: Element.State.Liquid,
              kanim: ElementUtil.FindAnim("liquid_tank_kanim"),
              material: Assets.instance.substanceTable.liquidMaterial,
              colour: KATHERIUM_GOLD
            );
        }

        static Texture2D TintTextureKatheriumGold(Texture sourceTexture, string name)
        {
            Texture2D newTexture = Util.DuplicateTexture(sourceTexture as Texture2D);
            var pixels = newTexture.GetPixels32();
            for (int i = 0; i < pixels.Length; ++i)
            {
                var gray = ((Color)pixels[i]).grayscale * 1.5f;
                pixels[i] = (Color)KATHERIUM_GOLD * gray;
            }
            newTexture.SetPixels32(pixels);
            newTexture.Apply();
            newTexture.name = name;
            return newTexture;
        }

        static Material CreateKatheriumMaterial(Material source)
        {
            var katheriumMaterial = new Material(source);

            Texture2D newTexture = TintTextureKatheriumGold(katheriumMaterial.mainTexture, "katherium");

            katheriumMaterial.mainTexture = newTexture;
            katheriumMaterial.name = "matKatherium";

            return katheriumMaterial;
        }

        public static void RegisterKatheriumSubstance()
        {
            Substance katherium = Assets.instance.substanceTable.GetSubstance(SimHashes.Aluminum);

            ElementUtil.CreateRegisteredSubstance(
              name: KATHERIUM_ID,
              state: Element.State.Solid,
              kanim: ElementUtil.FindAnim("cuprite_kanim"),
              material: CreateKatheriumMaterial(katherium.material),
              colour: KATHERIUM_GOLD
            );
        }
        static Material CreateKatheriumOreMaterial(Material source)
        {
            var katheriumOreMaterial = new Material(source);

            Texture2D newTexture = TintTextureKatheriumGold(katheriumOreMaterial.mainTexture, "katheriumOre");

            katheriumOreMaterial.mainTexture = newTexture;
            katheriumOreMaterial.name = "matKatheriumOre";

            return katheriumOreMaterial;
        }

        public static void RegisterKatheriumOreSubstance()
        {
            Substance katheriumore = Assets.instance.substanceTable.GetSubstance(SimHashes.GoldAmalgam);

            ElementUtil.CreateRegisteredSubstance(
              name: KATHERIUMORE_ID,
              state: Element.State.Solid,
              kanim: ElementUtil.FindAnim("cuprite_kanim"),
              material: CreateKatheriumOreMaterial(katheriumore.material),
              colour: KATHERIUM_GOLD
            );
        }
    }
}
