using DbsCard.Converters;
using DbsCard.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbsCard.Models.Dto
{
    public class CardDto
    {
        [JsonProperty("Id")]
        public string CardId { get; set; }

        [JsonProperty("AwakenedSide")]
        public virtual CardDto AwakenedSide { get; set; }

        [JsonProperty("CardNumber")]
        public string CardNumber { get; set; }

        [JsonProperty("CardName")]
        public string CardName { get; set; }

        [JsonProperty("CardImg")]
        public string CardImg { get; set; }

        [JsonProperty("Cost")]
        public string Cost { get; set; }

        [JsonProperty("Series")]
        public CardSerie CardSerie { get; set; }

        [JsonProperty("Rarity")]
        public CardRarity CardRarity { get; set; }

        [JsonProperty("Type")]
        public CardType CardType { get; set; }

        [JsonProperty("Color")]
        public CardColor CardColor { get; set; }


        [JsonProperty("Power")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Power { get; set; }

        [JsonProperty("ComboCost")]
        public string ComboCost { get; set; }

        [JsonProperty("ComboPower")]
        public string ComboPower { get; set; }

        [JsonProperty("Character")]
        public string Character { get; set; }

        [JsonProperty("SpecialTrait")]
        public string SpecialTrait { get; set; }

        [JsonProperty("Era")]
        public string Era { get; set; }

        [JsonProperty("AvailDate")]
        string AvailDate { get; set; }

        [JsonProperty("Skill")]
        string Skill { get; set; }

        [JsonProperty("LocalCardImg")]
        string LocalCardImg { get; set; }

        [JsonProperty("TextMatchScore")]
        public string TextMatchScore { get; set; }


        [JsonProperty("BaseCardNumber")]
        public string BaseCardNumber { get; set; }

        [JsonProperty("SkillPlainText")]
        public string SkillPlainText { get; set; }

        [JsonProperty("Keywords")]
        public string Keywords { get; set; }

        [JsonProperty("OctgnId")]
        public string OctgnId { get; set; }

        [JsonProperty("MaxAllowed")]
        public long MaxAllowed { get; set; }

        [JsonProperty("TCGData")]
        public List<TcgData> TcgData { get; set; }

        [JsonProperty("UpdatedOn")]
        public DateTimeOffset UpdatedOn { get; set; }

        [JsonProperty("CardCount")]
        public long CardCount { get; set; }

        [JsonProperty("SideCardCount")]
        public long SideCardCount { get; set; }

        [JsonProperty("CostInt")]
        public long CostInt { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("FullCardName")]
        public string FullCardName { get; set; }

        public bool IsPR { get; set; }

        public bool IsLeader { get; set; }
    }
}
