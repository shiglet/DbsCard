namespace DbsCard.Models.Enums
{
    public enum CardColor
    {
        Black,
        Blue,
        BlueYellow,
        Green,
        Red,
        RedGreen,
        Yellow
    };

    public enum CardRarity
    {
        CommonC,
        DestructionRareDr,
        ExpansionRareEx,
        FeatureRareFr,
        PromotionPr,
        RareR,
        SecretRareScr,
        StarterRareSt,
        SuperRareSr,
        UncommonUc
    };

    public enum CardSerie
    {
        ExpansionDeckBoxSet01BrMightyHeroes,
        ExpansionDeckBoxSet02BrDarkDemonSVillains,
        ExpansionSet04BrUnityOfSaiyans,
        ExpansionSet05BrUnityOfDestruction,
        PromotionCards,
        Series1BoosterBrGalacticBattle,
        Series1StarterBrTheAwakening,
        Series2BoosterBrUnionForce,
        Series3BoosterBrCrossWorlds,
        Series3StarterBrTheDarkInvasion,
        Series3StarterBrTheExtremeEvolution,
        Series4BrColossalWarfare,
        Series5BrMiraculousRevival,
        Series6BrDestroyerKings,
        SpecialAnniversaryBox,
        StarterDeckBrResurrectedFusionDbsSd06,
        StarterDeckBrRisingBrolyDbsSd08,
        StarterDeckBrShenronSAdventDbsSd07,
        StarterDeckBrTheCrimsonSaiyanDbsSd05,
        StarterDeckBrTheGuardianOfNamekiansDbsSd04,
        ThemedBoosterBrClashOfFates,
        ThemedBoosterBrTheTournamentOfPower,
        ThemedBoosterBrWorldMartialArtsTournament,
        UltimateBox
    };

    public enum CardType
    {
        Battle,
        Extra,
        Leader
    };
}