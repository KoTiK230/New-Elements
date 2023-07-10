using UnityEngine;

namespace New_Elements.Chemistry
{
    public static class KatheriumAlloyElement
    {
        public static readonly Color32 KATHERIUMALLOY_SHINY = new Color32(245, 210, 247, 255);
        public const string KATHERIUMALLOY_ID = "KatheriumAlloy";

        public static readonly SimHashes KatheriumAlloySimHash = (SimHashes)Hash.SDBMLower(KATHERIUMALLOY_ID);

        static Texture2D TintTextureResinBlue(Texture sourceTexture, string name)
        {
            Texture2D newTexture = Util.DuplicateTexture(sourceTexture as Texture2D);
            var pixels = newTexture.GetPixels32();
            for (int i = 0; i < pixels.Length; ++i)
            {
                var gray = ((Color)pixels[i]).grayscale * 1.5f;
                pixels[i] = (Color)KATHERIUMALLOY_SHINY * gray;
            }
            newTexture.SetPixels32(pixels);
            newTexture.Apply();
            newTexture.name = name;
            return newTexture;
        }
        static Material CreateKatheriumAlloyMaterial(Material source)
        {
            var katheriumAlloyMaterial = new Material(source);

            Texture2D newTexture = TintTextureResinBlue(katheriumAlloyMaterial.mainTexture, "katheriumalloy");

            katheriumAlloyMaterial.mainTexture = newTexture;
            katheriumAlloyMaterial.name = "matKatheriumAlloy";

            return katheriumAlloyMaterial;
        }
        public static void RegisterKatheriumAlloySubstance()
        {
            Substance katheriumalloy = Assets.instance.substanceTable.GetSubstance(SimHashes.Aluminum);

            ElementUtil.CreateRegisteredSubstance(
              name: KATHERIUMALLOY_ID,
              state: Element.State.Solid,
              kanim: ElementUtil.FindAnim("ice_kanim"),
              material: CreateKatheriumAlloyMaterial(katheriumalloy.material),
              colour: KATHERIUMALLOY_SHINY
            );
        }
    }
}
