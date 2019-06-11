using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using DbsCard.BusinessComponents.Contracts;
using DbsCard.Models;
using DbsCard.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DbsCard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private ICardBusiness _cardBusiness;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CardController(AppDbContext db, IMapper mapper, ICardBusiness cardBusiness)
        {
            this._context = db;
            this._mapper = mapper;
            this._cardBusiness = cardBusiness;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<CardDto>>> SyncCardsAsync()
        {
            HttpClient client = new HttpClient();
            var result = await client.GetStringAsync("https://www.shenronslair.com/api/Cards");

            var cards = JsonConvert.DeserializeObject<IEnumerable<CardDto>>(result);

            _cardBusiness.AddRange(cards);

            return Ok(_mapper.Map<IEnumerable<CardDto>>(_cardBusiness.Get()));
        }
        [HttpGet]
        public ActionResult<IEnumerable<CardDto>> GetCards()
        {
            return Ok(_mapper.Map<IEnumerable<CardDto>>(_cardBusiness.Get()));
        }


        [HttpGet]
        [Route("GetAmount/{amount}")]
        public ActionResult<IEnumerable<CardDto>> GetAmount(int amount)
        {
            return Ok(_mapper.Map<IEnumerable<CardDto>>(_cardBusiness.Get()).Take(amount));
        }

        [HttpGet]
        [Route("{cardId}")]
        public ActionResult<IEnumerable<CardDto>> GetCard(int id)
        {
            return Ok(_mapper.Map<IEnumerable<CardDto>>(_cardBusiness.Get(id)));
        }

        [HttpGet]
        [Route("/cardNumber/{cardNumber}")]
        public ActionResult<IEnumerable<CardDto>> GetCardByCardNumber(string cardNumber)
        {
            return Ok(_mapper.Map<IEnumerable<CardDto>>(_cardBusiness.GetByCardNumber(cardNumber)));
        }
    }
}