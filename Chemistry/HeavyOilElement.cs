using UnityEngine;
namespace New_Elements.Chemistry
{
    public static class HeavyOilElement
    {
        public static readonly Color32 OIL_PURPLE = new Color32(124, 21, 153, 255);
        public const string FROZENHEAVYOIL_ID = "FrozenHeavyOil";
        public const string HEAVYOIL_ID = "HeavyOil";

        public static readonly SimHashes HeavyOilSimHash = (SimHashes)Hash.SDBMLower(HEAVYOIL_ID);
        public static readonly SimHashes FrozenHeavyOilSimHash = (SimHashes)Hash.SDBMLower(FROZENHEAVYOIL_ID);

        public static void RegisterHeavyOilSubstance()
        {
            ElementUtil.CreateRegisteredSubstance(
              name: HEAVYOIL_ID,
              state: Element.State.Liquid,
              kanim: ElementUtil.FindAnim("liquid_tank_kanim"),
              material: Assets.instance.substanceTable.liquidMaterial,
              colour: OIL_PURPLE
            );
        }

        static Texture2D TintTextureOilPurple(Texture sourceTexture, string name)
        {
            Texture2D newTexture = Util.DuplicateTexture(sourceTexture as Texture2D);
            var pixels = newTexture.GetPixels32();
            for (int i = 0; i < pixels.Length; ++i)
            {
                var gray = ((Color)pixels[i]).grayscale * 1.5f;
                pixels[i] = (Color)OIL_PURPLE * gray;
            }
            newTexture.SetPixels32(pixels);
            newTexture.Apply();
            newTexture.name = name;
            return newTexture;
        }

        static Material CreateFrozenHeavyOilMaterial(Material source)
        {
            var frozenHeavyOilMaterial = new Material(source);

            Texture2D newTexture = TintTextureOilPurple(frozenHeavyOilMaterial.mainTexture, "frozenheavyoil");

            frozenHeavyOilMaterial.mainTexture = newTexture;
            frozenHeavyOilMaterial.name = "matFrozenHeavyOil";

            return frozenHeavyOilMaterial;
        }

        public static void RegisterFrozenHeavyOilSubstance()
        {
            Substance heavyoil = Assets.instance.substanceTable.GetSubstance(SimHashes.SolidOxygen);

            ElementUtil.CreateRegisteredSubstance(
              name: FROZENHEAVYOIL_ID,
              state: Element.State.Solid,
              kanim: ElementUtil.FindAnim("ice_kanim"),
              material: CreateFrozenHeavyOilMaterial(heavyoil.material),
              colour: OIL_PURPLE
            );
        }
    }

}