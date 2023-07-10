using UnityEngine;

namespace New_Elements.Chemistry
{
    public static class PolymerResinElement
    {
        public static readonly Color32 RESIN_BLUE = new Color32(31, 61, 255, 255);
        public const string POLYMERRESIN_ID = "PolymerResin";

        public static readonly SimHashes PolymerResinSimHash = (SimHashes)Hash.SDBMLower(POLYMERRESIN_ID);

        static Texture2D TintTextureResinBlue(Texture sourceTexture, string name)
        {
            Texture2D newTexture = Util.DuplicateTexture(sourceTexture as Texture2D);
            var pixels = newTexture.GetPixels32();
            for (int i = 0; i < pixels.Length; ++i)
            {
                var gray = ((Color)pixels[i]).grayscale * 1.5f;
                pixels[i] = (Color)RESIN_BLUE * gray;
            }
            newTexture.SetPixels32(pixels);
            newTexture.Apply();
            newTexture.name = name;
            return newTexture;
        }
        static Material CreatePolymerResinMaterial(Material source)
        {
            var polymerResinMaterial = new Material(source);

            Texture2D newTexture = TintTextureResinBlue(polymerResinMaterial.mainTexture, "polymerresin");

            polymerResinMaterial.mainTexture = newTexture;
            polymerResinMaterial.name = "matPolymerResin";

            return polymerResinMaterial;
        }
        public static void RegisterPolymerResinSubstance()
        {
            Substance polymerresin = Assets.instance.substanceTable.GetSubstance(SimHashes.Carbon);

            ElementUtil.CreateRegisteredSubstance(
              name: POLYMERRESIN_ID,
              state: Element.State.Solid,
              kanim: ElementUtil.FindAnim("ice_kanim"),
              material: CreatePolymerResinMaterial(polymerresin.material),
              colour: RESIN_BLUE
            );
        }
    }
}