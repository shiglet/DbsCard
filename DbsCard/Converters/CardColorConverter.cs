using DbsCard.Models.Enums;
using Newtonsoft.Json;
using System;

namespace DbsCard.Converters
{
    internal class CardColorConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(CardColor) || t == typeof(CardColor?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Black":
                    return CardColor.Black;
                case "Blue":
                    return CardColor.Blue;
                case "Blue/Yellow":
                    return CardColor.BlueYellow;
                case "Green":
                    return CardColor.Green;
                case "Red":
                    return CardColor.Red;
                case "Red/Green":
                    return CardColor.RedGreen;
                case "Yellow":
                    return CardColor.Yellow;
            }
            throw new Exception("Cannot unmarshal type CardColor");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (CardColor)untypedValue;
            switch (value)
            {
                case CardColor.Black:
                    serializer.Serialize(writer, "Black");
                    return;
                case CardColor.Blue:
                    serializer.Serialize(writer, "Blue");
                    return;
                case CardColor.BlueYellow:
                    serializer.Serialize(writer, "Blue/Yellow");
                    return;
                case CardColor.Green:
                    serializer.Serialize(writer, "Green");
                    return;
                case CardColor.Red:
                    serializer.Serialize(writer, "Red");
                    return;
                case CardColor.RedGreen:
                    serializer.Serialize(writer, "Red/Green");
                    return;
                case CardColor.Yellow:
                    serializer.Serialize(writer, "Yellow");
                    return;
            }
            throw new Exception("Cannot marshal type CardColor");
        }

        public static readonly CardColorConverter Singleton = new CardColorConverter();
    }
}
