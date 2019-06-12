using System;
using System.Collections.Generic;
using System.Text;

namespace DbsCard.Models.Dto
{
    public class LoanedCard
    {
        public CardDto Card { get; set; }

        public UserDto User { get; set; }
    }
}
