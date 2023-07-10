using UnityEngine;

namespace New_Elements.Chemistry
{
    public static class NitricAcidElement
    {
        public static readonly Color32 ACID_BLUE = new Color32(56, 129, 207, 255);
        public const string FROZENNITRICACID_ID = "FrozenNitricAcid";
        public const string NITRICACID_ID = "NitricAcid";

        public static readonly SimHashes NitricAcidSimHash = (SimHashes)Hash.SDBMLower(NITRICACID_ID);
        public static readonly SimHashes FrozenNitricAcidSimHash = (SimHashes)Hash.SDBMLower(FROZENNITRICACID_ID);

        public static void RegisterNitricAcidSubstance()
        {
            ElementUtil.CreateRegisteredSubstance(
              name: NITRICACID_ID,
              state: Element.State.Liquid,
              kanim: ElementUtil.FindAnim("liquid_tank_kanim"),
              material: Assets.instance.substanceTable.liquidMaterial,
              colour: ACID_BLUE
            );
        }

        static Texture2D TintTextureAcidBlue(Texture sourceTexture, string name)
        {
            Texture2D newTexture = Util.DuplicateTexture(sourceTexture as Texture2D);
            var pixels = newTexture.GetPixels32();
            for (int i = 0; i < pixels.Length; ++i)
            {
                var gray = ((Color)pixels[i]).grayscale * 1.5f;
                pixels[i] = (Color)ACID_BLUE * gray;
            }
            newTexture.SetPixels32(pixels);
            newTexture.Apply();
            newTexture.name = name;
            return newTexture;
        }

        static Material CreateFrozenNitricAcidMaterial(Material source)
        {
            var frozenNitricAcidMaterial = new Material(source);

            Texture2D newTexture = TintTextureAcidBlue(frozenNitricAcidMaterial.mainTexture, "frozennitricacid");

            frozenNitricAcidMaterial.mainTexture = newTexture;
            frozenNitricAcidMaterial.name = "matFrozenNitricAcid";

            return frozenNitricAcidMaterial;
        }

        public static void RegisterFrozenNitricAcidSubstance()
        {
            Substance nitricacid = Assets.instance.substanceTable.GetSubstance(SimHashes.SolidOxygen);

            ElementUtil.CreateRegisteredSubstance(
              name: FROZENNITRICACID_ID,
              state: Element.State.Solid,
              kanim: ElementUtil.FindAnim("ice_kanim"),
              material: CreateFrozenNitricAcidMaterial(nitricacid.material),
              colour: ACID_BLUE
            );
        }
    }

}