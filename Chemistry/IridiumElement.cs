using UnityEngine;

namespace New_Elements.Chemistry
{
    class IridiumElement
    {

            public static readonly Color32 IRIDIUM_VIOLET = new Color32(228, 173, 255, 255);
            public const string GASIRIDIUM_ID = "GasIridium";
            public const string LIQUIDIRIDIUM_ID = "LiquidIridium";
            public const string IRIDIUM_ID = "Iridium";

            public static readonly SimHashes LiquidIridiumSimHash = (SimHashes)Hash.SDBMLower(LIQUIDIRIDIUM_ID);
            public static readonly SimHashes IridiumSimHash = (SimHashes)Hash.SDBMLower(IRIDIUM_ID);
            public static readonly SimHashes GasIridiumSimHash = (SimHashes)Hash.SDBMLower(GASIRIDIUM_ID);

            public static void RegisterGasIridiumSubstance()
            {
                ElementUtil.CreateRegisteredSubstance(
                  name: GASIRIDIUM_ID,
                  state: Element.State.Gas,
                  kanim: ElementUtil.FindAnim("gas_tank_kanim"),
                  material: Assets.instance.substanceTable.liquidMaterial,
                  colour: IRIDIUM_VIOLET
                );
            }
            public static void RegisterLiquidIridiumSubstance()
            {
                ElementUtil.CreateRegisteredSubstance(
                  name: LIQUIDIRIDIUM_ID,
                  state: Element.State.Liquid,
                  kanim: ElementUtil.FindAnim("liquid_tank_kanim"),
                  material: Assets.instance.substanceTable.liquidMaterial,
                  colour: IRIDIUM_VIOLET
                );
            }

            static Texture2D TintTextureIridiumViolet(Texture sourceTexture, string name)
            {
                Texture2D newTexture = Util.DuplicateTexture(sourceTexture as Texture2D);
                var pixels = newTexture.GetPixels32();
                for (int i = 0; i < pixels.Length; ++i)
                {
                    var gray = ((Color)pixels[i]).grayscale * 1.5f;
                    pixels[i] = (Color)IRIDIUM_VIOLET * gray;
                }
                newTexture.SetPixels32(pixels);
                newTexture.Apply();
                newTexture.name = name;
                return newTexture;
            }

            static Material CreateIridiumMaterial(Material source)
            {
                var iridiumMaterial = new Material(source);

                Texture2D newTexture = TintTextureIridiumViolet(iridiumMaterial.mainTexture, "iridium");

            iridiumMaterial.mainTexture = newTexture;
            iridiumMaterial.name = "matIridium";

                return iridiumMaterial;
            }

            public static void RegisterIridiumSubstance()
            {
                Substance iridium = Assets.instance.substanceTable.GetSubstance(SimHashes.Niobium);

                ElementUtil.CreateRegisteredSubstance(
                  name: IRIDIUM_ID,
                  state: Element.State.Solid,
                  kanim: ElementUtil.FindAnim("cuprite_kanim"),
                  material: CreateIridiumMaterial(iridium.material),
                  colour: IRIDIUM_VIOLET
                );
            }
        }
}
