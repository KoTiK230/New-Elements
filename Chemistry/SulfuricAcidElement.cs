using UnityEngine;

namespace New_Elements.Chemistry
{
    public static class SulfuricAcidElement
    {
        public static readonly Color32 ACID_YELLOW = new Color32(191, 190, 101, 0);
        public const string SULFURICACID_ID = "SulfuricAcid";
        public const string FROZENSULFURICACID_ID = "FrozenSulfuricAcid";

        public static readonly SimHashes SulfuricAcidSimHash = (SimHashes)Hash.SDBMLower(SULFURICACID_ID);
        public static readonly SimHashes FrozenSulfuricAcidSimHash = (SimHashes)Hash.SDBMLower(FROZENSULFURICACID_ID);

        static Texture2D TintTextureAcidYellow(Texture sourceTexture, string name)
        {
            Texture2D newTexture = Util.DuplicateTexture(sourceTexture as Texture2D);
            var pixels = newTexture.GetPixels32();
            for (int i = 0; i < pixels.Length; ++i)
            {
                var gray = ((Color)pixels[i]).grayscale * 1.5f;
                pixels[i] = (Color)ACID_YELLOW * gray;
            }
            newTexture.SetPixels32(pixels);
            newTexture.Apply();
            newTexture.name = name;
            return newTexture;
        }
        public static void RegisterSulfuricAcidSubstance()
        {
            ElementUtil.CreateRegisteredSubstance(
              name: SULFURICACID_ID,
              state: Element.State.Liquid,
              kanim: ElementUtil.FindAnim("gas_tank_kanim"),
              material: Assets.instance.substanceTable.liquidMaterial,
              colour: ACID_YELLOW
            );
        }

        static Material CreateFrozenSulfuricAcidMaterial(Material source)
        {
            var frozenSulfuricAcidMaterial = new Material(source);

            Texture2D newTexture = TintTextureAcidYellow(frozenSulfuricAcidMaterial.mainTexture, "frozensulfuricacid");

            frozenSulfuricAcidMaterial.mainTexture = newTexture;
            frozenSulfuricAcidMaterial.name = "matFrozenSulfuricAcid";

            return frozenSulfuricAcidMaterial;
        }
        public static void RegisterFrozenSulfuricAcidSubstance()
        {
            Substance sulfuricacid = Assets.instance.substanceTable.GetSubstance(SimHashes.SolidHydrogen);

            ElementUtil.CreateRegisteredSubstance(
              name: FROZENSULFURICACID_ID,
              state: Element.State.Solid,
              kanim: ElementUtil.FindAnim("ice_kanim"),
              material: CreateFrozenSulfuricAcidMaterial(sulfuricacid.material),
              colour: ACID_YELLOW
            );
        }
    }

}