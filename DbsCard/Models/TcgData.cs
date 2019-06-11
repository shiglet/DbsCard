using DbsCard.Converters;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DbsCard.Models
{
    public partial class TcgData
    {
        [Key]
        public int Id { get; set; }

        public long ProductID { get; set; }

        public string ProductUrl { get; set; }

        public string PartnerProductUrl { get; set; }

        public string ProductName { get; set; }

        public double HighPrice { get; set; }

        public double? MarketPrice { get; set; }

        public double MidPrice { get; set; }

        public double LowPrice { get; set; }
    }
}