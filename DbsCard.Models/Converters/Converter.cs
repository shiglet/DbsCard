using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace DbsCard.Models.Converters
{
    public static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                CardColorConverter.Singleton,
                RarityConverter.Singleton,
                SeriesConverter.Singleton,
                TypeEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
