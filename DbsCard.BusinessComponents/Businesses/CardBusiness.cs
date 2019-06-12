using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DbsCard.BusinessComponents.Contracts;
using DbsCard.Models;
using DbsCard.Models.Dto;
using DbsCard.Models.Entities;

namespace DbsCard.BusinessComponents.Businesses
{
    public class CardBusiness : ICardBusiness
    {

        public AppDbContext _context { get; set; }

        private readonly IMapper _mapper;

        public CardBusiness(AppDbContext _context, IMapper _mapper)
        {
            this._context = _context;
            this._mapper = _mapper;
        }
        public void Add(CardDto cardDto)
        {
            var card = _mapper.Map<Card>(cardDto);

            FillCard(card);

            _context.Add(card);

            _context.SaveChanges();
        }

        private void FillCard(Card card)
        {
            card.IsPR = card.CardNumber.Contains("PR");
            card.UpdatedOn = DateTime.Now;
            if (card.SideCard != null)
            {
                card.IsLeader = true;
                card.SideCard.UpdatedOn = DateTime.Now;
                card.SideCard.IsSideCard = true;
                card.SideCard.IsPR = card.SideCard.CardNumber.Contains("PR");
            }
        }

        public void AddRange(IEnumerable<CardDto> cardsDto)
        {
            var cards = _mapper.Map<IEnumerable<Card>>(cardsDto);
            cards.ToList().ForEach(x => FillCard(x));
            _context.AddRange(cards);
            _context.SaveChanges();
        }

        public void Delete(int cardId)
        {
            var card = _context.Cards.SingleOrDefault(x => x.Id == cardId);
            card.DateDeleted = DateTime.Now;
            if (card.SideCard != null)
                card.SideCard.DateDeleted = DateTime.Now;

            _context.SaveChanges();
        }

        public IEnumerable<Card> Get()
        {
            return _context.Cards.Where(x => x.DateDeleted == null && !x.IsSideCard && !x.IsPR).OrderBy(x => x.CardNumber);
        }

        public Card Get(int cardId)
        {
            return _context.Cards.SingleOrDefault(x => x.Id == cardId);
        }

        public Card GetByCardNumber(string cardNumber)
        {
            return _context.Cards.SingleOrDefault(x => x.CardNumber == cardNumber);
        }
    }
}
