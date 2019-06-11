using Microsoft.EntityFrameworkCore;
using DbsCard.Models.Enums;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using DbsCard.Converters;
using System.ComponentModel.DataAnnotations;

namespace DbsCard.Models    
{
    public class Card
    {
        [Key]
        public int Id { get; set; }

        public int? SideCardId { get; set; }

        public virtual Card SideCard { get; set; }

        public string CardNumber { get; set; }

        public string CardName { get; set; }

        public string CardImg { get; set; }
        public string CardImgFr { get; set; }

        public string Cost { get; set; }

        public CardSerie CardSerie { get; set; }

        public CardRarity CardRarity { get; set; }

        public CardType CardType { get; set; }

        public CardColor CardColor { get; set; }

        public long Power { get; set; }

        public string ComboCost { get; set; }

        public string ComboPower { get; set; }

        public string Character { get; set; }

        public string SpecialTrait { get; set; }

        public string Era { get; set; }

        string AvailDate { get; set; }

        string Skill { get; set; }

        string LocalCardImg { get; set; }

        public string TextMatchScore { get; set; }
        public string CardId { get; set; }
        
        public string BaseCardNumber { get; set; }

        public string SkillPlainText { get; set; }

        public string Keywords { get; set; }

        public string OctgnId { get; set; }

        public long MaxAllowed { get; set; }
        
        public List<TcgData> TcgData { get; set; }

        public DateTimeOffset UpdatedOn { get; set; }

        public long CardCount { get; set; }

        public long SideCardCount { get; set; }

        public long CostInt { get; set; }

        public string Label { get; set; }

        public string FullCardName { get; set; }

        public bool IsPR { get; set; }

        public bool IsSideCard { get; set; }
        public bool IsLeader { get; set; }
        public DateTime? DateDeleted { get; internal set; }
    }


}