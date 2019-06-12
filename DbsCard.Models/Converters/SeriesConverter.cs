using DbsCard.Models.Enums;
using Newtonsoft.Json;
using System;

namespace DbsCard.Models.Converters
{
    internal class SeriesConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(CardSerie) || t == typeof(CardSerie?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "EXPANSION DECK BOX SET 01<br>-Mighty Heroes-":
                    return CardSerie.ExpansionDeckBoxSet01BrMightyHeroes;
                case "EXPANSION DECK BOX SET 02<br>-Dark Demon’s Villains-":
                    return CardSerie.ExpansionDeckBoxSet02BrDarkDemonSVillains;
                case "EXPANSION SET04<br>-Unity of Saiyans- ":
                    return CardSerie.ExpansionSet04BrUnityOfSaiyans;
                case "EXPANSION SET05<br>-Unity of Destruction- ":
                    return CardSerie.ExpansionSet05BrUnityOfDestruction;
                case "Promotion Cards":
                    return CardSerie.PromotionCards;
                case "STARTER DECK<br>～RESURRECTED FUSION～【DBS-SD06】":
                    return CardSerie.StarterDeckBrResurrectedFusionDbsSd06;
                case "STARTER DECK<br>～RISING BROLY～【DBS-SD08】":
                    return CardSerie.StarterDeckBrRisingBrolyDbsSd08;
                case "STARTER DECK<br>～SHENRON’s ADVENT～【DBS-SD07】":
                    return CardSerie.StarterDeckBrShenronSAdventDbsSd07;
                case "STARTER DECK<br>～THE CRIMSON SAIYAN～【DBS-SD05】":
                    return CardSerie.StarterDeckBrTheCrimsonSaiyanDbsSd05;
                case "STARTER DECK<br>～THE Guardian of Namekians～【DBS-SD04】":
                    return CardSerie.StarterDeckBrTheGuardianOfNamekiansDbsSd04;
                case "Series 1 Booster<br>～GALACTIC BATTLE～ ":
                    return CardSerie.Series1BoosterBrGalacticBattle;
                case "Series 1 Starter<br>～THE AWAKENING～":
                    return CardSerie.Series1StarterBrTheAwakening;
                case "Series 2 Booster<br>～UNION FORCE～ ":
                    return CardSerie.Series2BoosterBrUnionForce;
                case "Series 3 Booster<br>～CROSS WORLDS～ ":
                    return CardSerie.Series3BoosterBrCrossWorlds;
                case "Series 3 Starter<br>～THE DARK INVASION～":
                    return CardSerie.Series3StarterBrTheDarkInvasion;
                case "Series 3 Starter<br>～THE EXTREME EVOLUTION～":
                    return CardSerie.Series3StarterBrTheExtremeEvolution;
                case "Series 4<br> ～COLOSSAL WARFARE～":
                    return CardSerie.Series4BrColossalWarfare;
                case "Series 5<br> ～MIRACULOUS REVIVAL～":
                    return CardSerie.Series5BrMiraculousRevival;
                case "Series6<br>～DESTROYER KINGS～":
                    return CardSerie.Series6BrDestroyerKings;
                case "Special Anniversary Box":
                    return CardSerie.SpecialAnniversaryBox;
                case "Themed Booster<br>～CLASH OF FATES～":
                    return CardSerie.ThemedBoosterBrClashOfFates;
                case "Themed Booster<br>～The Tournament Of Power～":
                    return CardSerie.ThemedBoosterBrTheTournamentOfPower;
                case "Themed Booster<br>～World Martial Arts Tournament～":
                    return CardSerie.ThemedBoosterBrWorldMartialArtsTournament;
                case "ULTIMATE BOX":
                    return CardSerie.UltimateBox;
            }
            throw new Exception("Cannot unmarshal type Series");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (CardSerie)untypedValue;
            switch (value)
            {
                case CardSerie.ExpansionDeckBoxSet01BrMightyHeroes:
                    serializer.Serialize(writer, "EXPANSION DECK BOX SET 01<br>-Mighty Heroes-");
                    return;
                case CardSerie.ExpansionDeckBoxSet02BrDarkDemonSVillains:
                    serializer.Serialize(writer, "EXPANSION DECK BOX SET 02<br>-Dark Demon’s Villains-");
                    return;
                case CardSerie.ExpansionSet04BrUnityOfSaiyans:
                    serializer.Serialize(writer, "EXPANSION SET04<br>-Unity of Saiyans- ");
                    return;
                case CardSerie.ExpansionSet05BrUnityOfDestruction:
                    serializer.Serialize(writer, "EXPANSION SET05<br>-Unity of Destruction- ");
                    return;
                case CardSerie.PromotionCards:
                    serializer.Serialize(writer, "Promotion Cards");
                    return;
                case CardSerie.StarterDeckBrResurrectedFusionDbsSd06:
                    serializer.Serialize(writer, "STARTER DECK<br>～RESURRECTED FUSION～【DBS-SD06】");
                    return;
                case CardSerie.StarterDeckBrRisingBrolyDbsSd08:
                    serializer.Serialize(writer, "STARTER DECK<br>～RISING BROLY～【DBS-SD08】");
                    return;
                case CardSerie.StarterDeckBrShenronSAdventDbsSd07:
                    serializer.Serialize(writer, "STARTER DECK<br>～SHENRON’s ADVENT～【DBS-SD07】");
                    return;
                case CardSerie.StarterDeckBrTheCrimsonSaiyanDbsSd05:
                    serializer.Serialize(writer, "STARTER DECK<br>～THE CRIMSON SAIYAN～【DBS-SD05】");
                    return;
                case CardSerie.StarterDeckBrTheGuardianOfNamekiansDbsSd04:
                    serializer.Serialize(writer, "STARTER DECK<br>～THE Guardian of Namekians～【DBS-SD04】");
                    return;
                case CardSerie.Series1BoosterBrGalacticBattle:
                    serializer.Serialize(writer, "Series 1 Booster<br>～GALACTIC BATTLE～ ");
                    return;
                case CardSerie.Series1StarterBrTheAwakening:
                    serializer.Serialize(writer, "Series 1 Starter<br>～THE AWAKENING～");
                    return;
                case CardSerie.Series2BoosterBrUnionForce:
                    serializer.Serialize(writer, "Series 2 Booster<br>～UNION FORCE～ ");
                    return;
                case CardSerie.Series3BoosterBrCrossWorlds:
                    serializer.Serialize(writer, "Series 3 Booster<br>～CROSS WORLDS～ ");
                    return;
                case CardSerie.Series3StarterBrTheDarkInvasion:
                    serializer.Serialize(writer, "Series 3 Starter<br>～THE DARK INVASION～");
                    return;
                case CardSerie.Series3StarterBrTheExtremeEvolution:
                    serializer.Serialize(writer, "Series 3 Starter<br>～THE EXTREME EVOLUTION～");
                    return;
                case CardSerie.Series4BrColossalWarfare:
                    serializer.Serialize(writer, "Series 4<br> ～COLOSSAL WARFARE～");
                    return;
                case CardSerie.Series5BrMiraculousRevival:
                    serializer.Serialize(writer, "Series 5<br> ～MIRACULOUS REVIVAL～");
                    return;
                case CardSerie.Series6BrDestroyerKings:
                    serializer.Serialize(writer, "Series6<br>～DESTROYER KINGS～");
                    return;
                case CardSerie.SpecialAnniversaryBox:
                    serializer.Serialize(writer, "Special Anniversary Box");
                    return;
                case CardSerie.ThemedBoosterBrClashOfFates:
                    serializer.Serialize(writer, "Themed Booster<br>～CLASH OF FATES～");
                    return;
                case CardSerie.ThemedBoosterBrTheTournamentOfPower:
                    serializer.Serialize(writer, "Themed Booster<br>～The Tournament Of Power～");
                    return;
                case CardSerie.ThemedBoosterBrWorldMartialArtsTournament:
                    serializer.Serialize(writer, "Themed Booster<br>～World Martial Arts Tournament～");
                    return;
                case CardSerie.UltimateBox:
                    serializer.Serialize(writer, "ULTIMATE BOX");
                    return;
            }
            throw new Exception("Cannot marshal type Series");
        }

        public static readonly SeriesConverter Singleton = new SeriesConverter();
    }
}
