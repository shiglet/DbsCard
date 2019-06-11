using DbsCard.Models.Enums;
using Newtonsoft.Json;
using System;

namespace DbsCard.Converters
{
    internal class RarityConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(CardRarity) || t == typeof(CardRarity?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Common[C]":
                    return CardRarity.CommonC;
                case "Destruction Rare[DR]":
                    return CardRarity.DestructionRareDr;
                case "Expansion Rare[EX]":
                    return CardRarity.ExpansionRareEx;
                case "Feature Rare[FR]":
                    return CardRarity.FeatureRareFr;
                case "Promotion[PR］":
                    return CardRarity.PromotionPr;
                case "Rare[R]":
                    return CardRarity.RareR;
                case "Secret Rare[SCR]":
                    return CardRarity.SecretRareScr;
                case "Starter Rare[ST]":
                    return CardRarity.StarterRareSt;
                case "Super Rare[SR]":
                    return CardRarity.SuperRareSr;
                case "Uncommon[UC]":
                    return CardRarity.UncommonUc;
            }
            throw new Exception("Cannot unmarshal type Rarity");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (CardRarity)untypedValue;
            switch (value)
            {
                case CardRarity.CommonC:
                    serializer.Serialize(writer, "Common[C]");
                    return;
                case CardRarity.DestructionRareDr:
                    serializer.Serialize(writer, "Destruction Rare[DR]");
                    return;
                case CardRarity.ExpansionRareEx:
                    serializer.Serialize(writer, "Expansion Rare[EX]");
                    return;
                case CardRarity.FeatureRareFr:
                    serializer.Serialize(writer, "Feature Rare[FR]");
                    return;
                case CardRarity.PromotionPr:
                    serializer.Serialize(writer, "Promotion[PR］");
                    return;
                case CardRarity.RareR:
                    serializer.Serialize(writer, "Rare[R]");
                    return;
                case CardRarity.SecretRareScr:
                    serializer.Serialize(writer, "Secret Rare[SCR]");
                    return;
                case CardRarity.StarterRareSt:
                    serializer.Serialize(writer, "Starter Rare[ST]");
                    return;
                case CardRarity.SuperRareSr:
                    serializer.Serialize(writer, "Super Rare[SR]");
                    return;
                case CardRarity.UncommonUc:
                    serializer.Serialize(writer, "Uncommon[UC]");
                    return;
            }
            throw new Exception("Cannot marshal type Rarity");
        }

        public static readonly RarityConverter Singleton = new RarityConverter();
    }
}
