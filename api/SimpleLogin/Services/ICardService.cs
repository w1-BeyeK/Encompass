using API.Models;
using API.Models.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    interface ICardService
    {
        ResultDTO<Card> GetAvailableCards();
    }
}
