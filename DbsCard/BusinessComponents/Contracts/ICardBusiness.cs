using DbsCard.Models;
using DbsCard.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbsCard.BusinessComponents.Contracts
{
    public interface ICardBusiness
    {
        void Add(CardDto card);

        void Delete(int cardId);

        void AddRange(IEnumerable<CardDto> cards);

        IEnumerable<Card> Get();

        Card Get(int cardId);

        Card GetByCardNumber(string CardNumber);
    }
}
