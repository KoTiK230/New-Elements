using HarmonyLib;

namespace New_Elements.Chemistry.Patches
{
    [HarmonyPatch(typeof(Assets), "SubstanceListHookup")]
    class Assets_SubstanceListHookup
    {
        static void Prefix()
        {
            ElementUtil.RegisterElementStrings(NitrogenElement.NITROGEN_ID, "Nitrogen", "Test");
            ElementUtil.RegisterElementStrings(NitrogenElement.LIQUIDNITROGEN_ID, "Liquid Nitrogen", "Test");
            ElementUtil.RegisterElementStrings(NitrogenElement.FROZENNITROGEN_ID, "Frozen Nitrogen", "Test");
            ElementUtil.RegisterElementStrings(FluorineElement.FLUORINE_ID, "Fluorine", "Test");
            ElementUtil.RegisterElementStrings(FluorineElement.LIQUIDFLUORINE_ID, "Liquid Fluorine", "Test");
            ElementUtil.RegisterElementStrings(FluorineElement.FROZENFLUORINE_ID, "Frozen Fluorine", "Test");
            ElementUtil.RegisterElementStrings(NitricAcidElement.NITRICACID_ID, "Nitric Acid", "Test");
            ElementUtil.RegisterElementStrings(NitricAcidElement.FROZENNITRICACID_ID, "Frozen Nitric Acid", "Test");
            ElementUtil.RegisterElementStrings(SulfurTrioxideElement.SULFURTRIOXIDE_ID, "Sulfur Trioxide", "Test");
            ElementUtil.RegisterElementStrings(SulfurTrioxideElement.LIQUIDSULFURTRIOXIDE_ID, "Liquid Sulfur Trioxide", "Test");
            ElementUtil.RegisterElementStrings(SulfurTrioxideElement.SOLIDSULFURTRIOXIDE_ID, "Solid Sulfur Trioxide", "Test");
            ElementUtil.RegisterElementStrings(NitrogenDioxideElement.NITROGENDIOXIDE_ID, "Nitrogen Dioxide", "Test");
            ElementUtil.RegisterElementStrings(NitrogenDioxideElement.LIQUIDNITROGENDIOXIDE_ID, "Dinitrogen Tetraoxide", "Test");
            ElementUtil.RegisterElementStrings(NitrogenDioxideElement.FROZENNITROGENDIOXIDE_ID, "Frozen Dinitrogen Tetraoxide", "Test");
            ElementUtil.RegisterElementStrings(SulfuricAcidElement.SULFURICACID_ID, "Sulfuric Acid", "Test");
            ElementUtil.RegisterElementStrings(SulfuricAcidElement.FROZENSULFURICACID_ID, "Frozen Sulfuric Acid", "Test");
            ElementUtil.RegisterElementStrings(HeavyOilElement.HEAVYOIL_ID, "Heavy Oil", "Test");
            ElementUtil.RegisterElementStrings(HeavyOilElement.FROZENHEAVYOIL_ID, "Solid Heavy Oil", "Test");
            ElementUtil.RegisterElementStrings(PolymerResinElement.POLYMERRESIN_ID, "Polymer Resin", "Test");
            ElementUtil.RegisterElementStrings(RubberElement.RUBBER_ID, "Rubber", "Test");
            ElementUtil.RegisterElementStrings(AmmoniaElement.AMMONIA_ID, "Ammonia", "Test");
            ElementUtil.RegisterElementStrings(AmmoniaElement.LIQUIDAMMONIA_ID, "Liquid Ammonia", "Test");
            ElementUtil.RegisterElementStrings(AmmoniaElement.FROZENAMMONIA_ID, "Frozen Ammonia", "Test");
            ElementUtil.RegisterElementStrings(NickelElement.LIQUIDNICKEL_ID, "Liquid Nickel", "Test");
            ElementUtil.RegisterElementStrings(NickelElement.NICKEL_ID, "Nickel", "Test");
            ElementUtil.RegisterElementStrings(NickelElement.GASNICKEL_ID, "Gas Nickel", "Test");
            ElementUtil.RegisterElementStrings(NickelElement.NICKELORE_ID, "Nickel Ore", "Test");
            ElementUtil.RegisterElementStrings(PlutoniumElement.PLUTONIUM_ID, "Plutonium", "Test");
            ElementUtil.RegisterElementStrings(PlutoniumElement.LIQUIDPLUTONIUM_ID, "Liquid Plutonium", "Test");
            ElementUtil.RegisterElementStrings(IridiumElement.LIQUIDIRIDIUM_ID, "Liquid Iridium", "Test");
            ElementUtil.RegisterElementStrings(IridiumElement.IRIDIUM_ID, "Iridium", "Test");
            ElementUtil.RegisterElementStrings(IridiumElement.GASIRIDIUM_ID, "Gas Iridium", "Test");
            ElementUtil.RegisterElementStrings(KatheriumElement.LIQUIDKATHERIUM_ID, "Liquid Katherium", "Test");
            ElementUtil.RegisterElementStrings(KatheriumElement.KATHERIUM_ID, "Katherium", "Test");
            ElementUtil.RegisterElementStrings(KatheriumElement.GASKATHERIUM_ID, "Gas Katherium", "Test");
            ElementUtil.RegisterElementStrings(KatheriumElement.KATHERIUMORE_ID, "Katherium Ore", "Test");
            ElementUtil.RegisterElementStrings(KatheriumAlloyElement.KATHERIUMALLOY_ID, "Katherium Alloy", "Test");
        }

        static void Postfix()
        {
            NitrogenElement.RegisterNitrogenSubstance();
            NitrogenElement.RegisterLiquidNitrogenSubstance();
            NitrogenElement.RegisterFrozenNitrogenSubstance();
            FluorineElement.RegisterFluorineSubstance();
            FluorineElement.RegisterLiquidFluorineSubstance();
            FluorineElement.RegisterFrozenFluorineSubstance();
            NitricAcidElement.RegisterNitricAcidSubstance();
            NitricAcidElement.RegisterFrozenNitricAcidSubstance();
            SulfurTrioxideElement.RegisterSulfurTrioxideSubstance();
            SulfurTrioxideElement.RegisterLiquidSulfurTrioxideSubstance();
            SulfurTrioxideElement.RegisterSolidSulfurTrioxideSubstance();
            SulfuricAcidElement.RegisterSulfuricAcidSubstance();
            SulfuricAcidElement.RegisterFrozenSulfuricAcidSubstance();
            NitrogenDioxideElement.RegisterNitrogenDioxideSubstance();
            NitrogenDioxideElement.RegisterLiquidNitrogenDioxideSubstance();
            NitrogenDioxideElement.RegisterFrozenNitrogenDioxideSubstance();
            HeavyOilElement.RegisterHeavyOilSubstance();
            HeavyOilElement.RegisterFrozenHeavyOilSubstance();
            PolymerResinElement.RegisterPolymerResinSubstance();
            RubberElement.RegisterRubberSubstance();
            AmmoniaElement.RegisterAmmoniaSubstance();
            AmmoniaElement.RegisterLiquidAmmoniaSubstance();
            AmmoniaElement.RegisterFrozenAmmoniaSubstance();
            NickelElement.RegisterNickelSubstance();
            NickelElement.RegisterLiquidNickelSubstance();
            NickelElement.RegisterGasNickelSubstance();
            NickelElement.RegisterNickelOreSubstance();
            PlutoniumElement.RegisterLiquidPlutoniumSubstance();
            PlutoniumElement.RegisterPlutoniumSubstance();
            IridiumElement.RegisterGasIridiumSubstance();
            IridiumElement.RegisterLiquidIridiumSubstance();
            IridiumElement.RegisterIridiumSubstance();
            KatheriumElement.RegisterKatheriumSubstance();
            KatheriumElement.RegisterLiquidKatheriumSubstance();
            KatheriumElement.RegisterGasKatheriumSubstance();
            KatheriumElement.RegisterKatheriumOreSubstance();
            KatheriumAlloyElement.RegisterKatheriumAlloySubstance();
        }
    }
}

