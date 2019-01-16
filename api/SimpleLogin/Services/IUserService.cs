using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.Exceptions;
using API.Models.Results;

namespace API.Services
{
    interface IUserService
    {
        ResultDTO<Balance> GetCards(int id);
        ResultDTO<User> Get();
        ResultDTO<User> Login(FilterDTO filters);
    
        UpdateDTO<User> Update(FilterDTO filters);
        UpdateDTO<Balance> UpdateCard(FilterDTO filter, int cardId, int userId);
        BaseDTO DeleteCard(FilterDTO filters);
    }
}
