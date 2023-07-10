using UnityEngine;

namespace New_Elements.Chemistry
{
    public static class RubberElement
    {
        public static readonly Color32 RUBBER_DARK = new Color32(36, 36, 36, 255);
        public const string RUBBER_ID = "Rubber";

        public static readonly SimHashes RubberSimHash = (SimHashes)Hash.SDBMLower(RUBBER_ID);

        static Texture2D TintTextureRubberDark(Texture sourceTexture, string name)
        {
            Texture2D newTexture = Util.DuplicateTexture(sourceTexture as Texture2D);
            var pixels = newTexture.GetPixels32();
            for (int i = 0; i < pixels.Length; ++i)
            {
                var gray = ((Color)pixels[i]).grayscale * 1.5f;
                pixels[i] = (Color)RUBBER_DARK * gray;
            }
            newTexture.SetPixels32(pixels);
            newTexture.Apply();
            newTexture.name = name;
            return newTexture;
        }
        static Material CreateRubberMaterial(Material source)
        {
            var rubberMaterial = new Material(source);

            Texture2D newTexture = TintTextureRubberDark(rubberMaterial.mainTexture, "rubber");

            rubberMaterial.mainTexture = newTexture;
            rubberMaterial.name = "matRubber";

            return rubberMaterial;
        }
        public static void RegisterRubberSubstance()
        {
            Substance rubber = Assets.instance.substanceTable.GetSubstance(SimHashes.Fullerene);

            ElementUtil.CreateRegisteredSubstance(
              name: RUBBER_ID,
              state: Element.State.Solid,
              kanim: ElementUtil.FindAnim("ice_kanim"),
              material: CreateRubberMaterial(rubber.material),
              colour: RUBBER_DARK
            );
        }
    }
}
