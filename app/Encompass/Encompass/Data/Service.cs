    using Encompass.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Encompass.Data
{
    public class Service
    {
        private IWebclient client;  
        public Service()
        {
            client = new Webclient("http://pti409368core.venus.fhict.nl/api/");
        }

        public User Login(string username, string password)
        {
            var data = new FilterDTO
            {
                Fields = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("email", username),
                    new KeyValuePair<string, string>("wachtwoord", password)
                }
            };

            ResultDTO<User> login = client.Send<ResultDTO<User>>(data, HttpRequestType.POST, "user/login");

            if (login == null || login.ResultCount == 0)
            {
                return null;
            }

            return login.Result[0];
        }

        public User LoginWithPinCode(string pinCode)
        {
            var data = new FilterDTO
            {
                Fields = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("code", pinCode),
                }
            };

            ResultDTO<User> login = client.Send<ResultDTO<User>>(data, HttpRequestType.POST, "user/login");

            if (login == null || login.ResultCount == 0)
            {
                return null;
            }

            return login.Result[0];
        }

        public List<Balance> GetUserCards(int userId)
        {
            ResultDTO<Balance> balances = client.Send<ResultDTO<Balance>>(null, HttpRequestType.GET, $"user/{userId}/cards");

            return balances.Result;
        }
    }
}
