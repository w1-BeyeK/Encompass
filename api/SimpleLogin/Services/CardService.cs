using API.Models;
using API.Models.Results;
using API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class CardService: ICardService
    {
        CardRepository _repo;

        public CardService()
        {
            _repo = new CardRepository();
        }

        public ResultDTO<Card> GetAvailableCards()
        {
            throw new NotImplementedException();
        }
    }
}
