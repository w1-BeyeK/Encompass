using API.Models;
using API.Models.Exceptions;
using API.Models.Results;
using API.Repositories;
using System.Linq;
using System.Collections.Generic;
using System;

namespace API.Services
{
    public class UserService: IUserService
    {
        /// <summary>
        /// Repository
        /// </summary>
        UserRepository _repo;

        SaldoRepository _srepo;

        public UserService()
        {
            _repo = new UserRepository();
            _srepo = new SaldoRepository();
        }

        /// <summary>
        /// Login method
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public ResultDTO<User> Login(FilterDTO filters)
        {
            // checks here
            if(filters.Fields.First().Key == "code")
            {
                return _repo.Get(filters.Fields.Where(f => f.Key == "code").FirstOrDefault().Value.ToArray());
            }

            if (!filters.Fields.Any(f => f.Key == "email") || !filters.Fields.Any(f => f.Key == "wachtwoord"))
            {
                throw new WhereException("No email or password found.");
            }
            
            return _repo.Get(filters);
        }

        public ResultDTO<User> Get()
        {
            return _repo.Get();
        }

        public ResultDTO<Balance> GetCards(int id)
        {
            if(!int.TryParse(id.ToString(), out int result))
            {
                throw new ArgumentNullException("No user id provided.");
            }
            return _srepo.GetCards(id);
        }

        public UpdateDTO<User> Update(FilterDTO filters)
        {
            if(!(filters.Fields.Any(f => f.Key.ToLower() == _repo.PrimaryKey.ToLower())))
            {
                return _repo.Insert(filters);
            }
            else
            {
                return _repo.Update(filters);
            }
        }

        public UpdateDTO<Balance> UpdateCard(FilterDTO filters, int userId)
        {
            if(!(filters.Fields.Any(f => f.Key.ToLower() == _repo.PrimaryKey.ToLower())))
            {
                throw new MissingFieldException("Missing primary key for update.");
            }

            return _srepo.Update(filters, userId);
        }

        public BaseDTO DeleteCard(FilterDTO filters)
        {
            return _srepo.Delete(filters);
        }
    }
}
