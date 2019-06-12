using DbsCard.Models.Enums;
using Newtonsoft.Json;
using System;

namespace DbsCard.Models.Converters
{
    internal class TypeEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(CardType) || t == typeof(CardType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "BATTLE":
                    return CardType.Battle;
                case "EXTRA":
                    return CardType.Extra;
                case "LEADER":
                    return CardType.Leader;
            }
            throw new Exception("Cannot unmarshal type TypeEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (CardType)untypedValue;
            switch (value)
            {
                case CardType.Battle:
                    serializer.Serialize(writer, "BATTLE");
                    return;
                case CardType.Extra:
                    serializer.Serialize(writer, "EXTRA");
                    return;
                case CardType.Leader:
                    serializer.Serialize(writer, "LEADER");
                    return;
            }
            throw new Exception("Cannot marshal type TypeEnum");
        }

        public static readonly TypeEnumConverter Singleton = new TypeEnumConverter();
    }
}
