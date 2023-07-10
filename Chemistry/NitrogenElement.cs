using UnityEngine;

namespace New_Elements.Chemistry
{
    public static class NitrogenElement
    {
        public static readonly Color32 NITROGEN_BLUE = new Color32(4, 154, 184, 255);
        public const string FROZENNITROGEN_ID = "FrozenNitrogen";
        public const string LIQUIDNITROGEN_ID = "LiquidNitrogen";
        public const string NITROGEN_ID = "Nitrogen";

        public static readonly SimHashes LiquidNitrogenSimHash = (SimHashes)Hash.SDBMLower(LIQUIDNITROGEN_ID);
        public static readonly SimHashes NitrogenSimHash = (SimHashes)Hash.SDBMLower(NITROGEN_ID);
        public static readonly SimHashes FrozenNitrogenSimHash = (SimHashes)Hash.SDBMLower(FROZENNITROGEN_ID);

        public static void RegisterNitrogenSubstance()
        {
            ElementUtil.CreateRegisteredSubstance(
              name: NITROGEN_ID,
              state: Element.State.Gas,
              kanim: ElementUtil.FindAnim("gas_tank_kanim"),
              material: Assets.instance.substanceTable.liquidMaterial,
              colour: NITROGEN_BLUE
            );
        }
        public static void RegisterLiquidNitrogenSubstance()
        {
            ElementUtil.CreateRegisteredSubstance(
              name: LIQUIDNITROGEN_ID,
              state: Element.State.Liquid,
              kanim: ElementUtil.FindAnim("liquid_tank_kanim"),
              material: Assets.instance.substanceTable.liquidMaterial,
              colour: NITROGEN_BLUE
            );
        }

        static Texture2D TintTextureNitrogenBlue(Texture sourceTexture, string name)
        {
            Texture2D newTexture = Util.DuplicateTexture(sourceTexture as Texture2D);
            var pixels = newTexture.GetPixels32();
            for (int i = 0; i < pixels.Length; ++i)
            {
                var gray = ((Color)pixels[i]).grayscale * 1.5f;
                pixels[i] = (Color)NITROGEN_BLUE * gray;
            }
            newTexture.SetPixels32(pixels);
            newTexture.Apply();
            newTexture.name = name;
            return newTexture;
        }

        static Material CreateFrozenNitrogenMaterial(Material source)
        {
            var frozenNitrogenMaterial = new Material(source);

            Texture2D newTexture = TintTextureNitrogenBlue(frozenNitrogenMaterial.mainTexture, "frozennitrogen");

            frozenNitrogenMaterial.mainTexture = newTexture;
            frozenNitrogenMaterial.name = "matFrozenNitrogen";

            return frozenNitrogenMaterial;
        }

        public static void RegisterFrozenNitrogenSubstance()
        {
            Substance nitrogen = Assets.instance.substanceTable.GetSubstance(SimHashes.SolidOxygen);

            ElementUtil.CreateRegisteredSubstance(
              name: FROZENNITROGEN_ID,
              state: Element.State.Solid,
              kanim: ElementUtil.FindAnim("ice_kanim"),
              material: CreateFrozenNitrogenMaterial(nitrogen.material),
              colour: NITROGEN_BLUE
            );
        }
    }

}