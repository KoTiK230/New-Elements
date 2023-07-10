using UnityEngine;

namespace New_Elements.Chemistry
{
    class AmmoniaElement
    {
        public static readonly Color32 AMMONIA_PINK = new Color32(255, 168, 223, 255);
        public const string FROZENAMMONIA_ID = "FrozenAmmonia";
        public const string LIQUIDAMMONIA_ID = "LiquidAmmonia";
        public const string AMMONIA_ID = "Ammonia";

        public static readonly SimHashes LiquidAmmoniaSimHash = (SimHashes)Hash.SDBMLower(LIQUIDAMMONIA_ID);
        public static readonly SimHashes AmmoniaSimHash = (SimHashes)Hash.SDBMLower(AMMONIA_ID);
        public static readonly SimHashes FrozenAmmoniaSimHash = (SimHashes)Hash.SDBMLower(FROZENAMMONIA_ID);

        public static void RegisterAmmoniaSubstance()
        {
            ElementUtil.CreateRegisteredSubstance(
              name: AMMONIA_ID,
              state: Element.State.Gas,
              kanim: ElementUtil.FindAnim("gas_tank_kanim"),
              material: Assets.instance.substanceTable.liquidMaterial,
              colour: AMMONIA_PINK
            );
        }
        public static void RegisterLiquidAmmoniaSubstance()
        {
            ElementUtil.CreateRegisteredSubstance(
              name: LIQUIDAMMONIA_ID,
              state: Element.State.Liquid,
              kanim: ElementUtil.FindAnim("liquid_tank_kanim"),
              material: Assets.instance.substanceTable.liquidMaterial,
              colour: AMMONIA_PINK
            );
        }

        static Texture2D TintTextureAmmoniaPink(Texture sourceTexture, string name)
        {
            Texture2D newTexture = Util.DuplicateTexture(sourceTexture as Texture2D);
            var pixels = newTexture.GetPixels32();
            for (int i = 0; i < pixels.Length; ++i)
            {
                var gray = ((Color)pixels[i]).grayscale * 1.5f;
                pixels[i] = (Color)AMMONIA_PINK * gray;
            }
            newTexture.SetPixels32(pixels);
            newTexture.Apply();
            newTexture.name = name;
            return newTexture;
        }

        static Material CreateFrozenAmmoniaMaterial(Material source)
        {
            var frozenAmmoniaMaterial = new Material(source);

            Texture2D newTexture = TintTextureAmmoniaPink(frozenAmmoniaMaterial.mainTexture, "frozenammonia");

            frozenAmmoniaMaterial.mainTexture = newTexture;
            frozenAmmoniaMaterial.name = "matFrozenAmmonia";

            return frozenAmmoniaMaterial;
        }

        public static void RegisterFrozenAmmoniaSubstance()
        {
            Substance ammonia = Assets.instance.substanceTable.GetSubstance(SimHashes.SolidOxygen);

            ElementUtil.CreateRegisteredSubstance(
              name: FROZENAMMONIA_ID,
              state: Element.State.Solid,
              kanim: ElementUtil.FindAnim("ice_kanim"),
              material: CreateFrozenAmmoniaMaterial(ammonia.material),
              colour: AMMONIA_PINK
            );
        }
    }
}
