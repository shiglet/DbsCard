using DbsCard.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbsCard.Models.Dto
{
    public class TcgDataDto
    {
        [JsonProperty("ProductID")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long ProductID { get; set; }

        [JsonProperty("ProductUrl")]
        public string ProductUrl { get; set; }

        [JsonProperty("PartnerProductUrl")]
        public string PartnerProductUrl { get; set; }

        [JsonProperty("ProductName")]
        public string ProductName { get; set; }

        [JsonProperty("HighPrice")]
        public double HighPrice { get; set; }

        [JsonProperty("MarketPrice")]
        public double? MarketPrice { get; set; }

        [JsonProperty("MidPrice")]
        public double MidPrice { get; set; }

        [JsonProperty("LowPrice")]
        public double LowPrice { get; set; }
    }
}
