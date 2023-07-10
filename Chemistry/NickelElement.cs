using UnityEngine;

namespace New_Elements.Chemistry
{
    class NickelElement
    {

        public static readonly Color32 NICKEL_SHINY = new Color32(89, 82, 70, 255);
        public const string GASNICKEL_ID = "GasNickel";
        public const string LIQUIDNICKEL_ID = "LiquidNickel";
        public const string NICKEL_ID = "Nickel";
        public const string NICKELORE_ID = "NickelOre";

        public static readonly SimHashes LiquidNickelSimHash = (SimHashes)Hash.SDBMLower(LIQUIDNICKEL_ID);
        public static readonly SimHashes NickelSimHash = (SimHashes)Hash.SDBMLower(NICKEL_ID);
        public static readonly SimHashes GasNickelSimHash = (SimHashes)Hash.SDBMLower(GASNICKEL_ID);
        public static readonly SimHashes NickelOreSimHash = (SimHashes)Hash.SDBMLower(NICKELORE_ID);

        public static void RegisterGasNickelSubstance()
        {
            ElementUtil.CreateRegisteredSubstance(
              name: GASNICKEL_ID,
              state: Element.State.Gas,
              kanim: ElementUtil.FindAnim("gas_tank_kanim"),
              material: Assets.instance.substanceTable.liquidMaterial,
              colour: NICKEL_SHINY
            );
        }
        public static void RegisterLiquidNickelSubstance()
        {
            ElementUtil.CreateRegisteredSubstance(
              name: LIQUIDNICKEL_ID,
              state: Element.State.Liquid,
              kanim: ElementUtil.FindAnim("liquid_tank_kanim"),
              material: Assets.instance.substanceTable.liquidMaterial,
              colour: NICKEL_SHINY
            );
        }

        static Texture2D TintTextureNickelShiny(Texture sourceTexture, string name)
        {
            Texture2D newTexture = Util.DuplicateTexture(sourceTexture as Texture2D);
            var pixels = newTexture.GetPixels32();
            for (int i = 0; i < pixels.Length; ++i)
            {
                var gray = ((Color)pixels[i]).grayscale * 1.5f;
                pixels[i] = (Color)NICKEL_SHINY * gray;
            }
            newTexture.SetPixels32(pixels);
            newTexture.Apply();
            newTexture.name = name;
            return newTexture;
        }

        static Material CreateNickelMaterial(Material source)
        {
            var nickelMaterial = new Material(source);

            Texture2D newTexture = TintTextureNickelShiny(nickelMaterial.mainTexture, "nickel");

            nickelMaterial.mainTexture = newTexture;
            nickelMaterial.name = "matNickel";

            return nickelMaterial;
        }

        public static void RegisterNickelSubstance()
        {
            Substance nickel = Assets.instance.substanceTable.GetSubstance(SimHashes.Aluminum);

            ElementUtil.CreateRegisteredSubstance(
              name: NICKEL_ID,
              state: Element.State.Solid,
              kanim: ElementUtil.FindAnim("cuprite_kanim"),
              material: CreateNickelMaterial(nickel.material),
              colour: NICKEL_SHINY
            );
        }
        static Material CreateNickelOreMaterial(Material source)
        {
            var nickelOreMaterial = new Material(source);

            Texture2D newTexture = TintTextureNickelShiny(nickelOreMaterial.mainTexture, "nickelOre");

            nickelOreMaterial.mainTexture = newTexture;
            nickelOreMaterial.name = "matNickelOre";

            return nickelOreMaterial;
        }

        public static void RegisterNickelOreSubstance()
        {
            Substance nickelore = Assets.instance.substanceTable.GetSubstance(SimHashes.Cuprite);

            ElementUtil.CreateRegisteredSubstance(
              name: NICKELORE_ID,
              state: Element.State.Solid,
              kanim: ElementUtil.FindAnim("cuprite_kanim"),
              material: CreateNickelOreMaterial(nickelore.material),
              colour: NICKEL_SHINY
            );
        }
    }
}
