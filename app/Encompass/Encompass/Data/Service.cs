    using Encompass.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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
            // client = new Webclient("http://pti409368core.venus.fhict.nl/api/");
            client = new Webclient("http://localhost:5000/api/");
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
            ResultDTO<Balance> balances;

            try
            {
                balances = client.Send<ResultDTO<Balance>>(null, HttpRequestType.GET, $"user/{userId}/cards");
            }
            catch (Exception e)
            {
                return new List<Balance>();
            }

            return balances.Result;
        }

        public bool UpdateUserCode(int userId, string code)
        {
            var data = new FilterDTO
            {
                Fields = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("id", userId.ToString()),
                    new KeyValuePair<string, string>("code", code.ToString())
                }
            };

            UpdateDTO<User> result = client.Send<UpdateDTO<User>>(data, HttpRequestType.POST, "user/update");

            if (result != null)
            {
                return result.Success;
            }

            return false;
        }

        public bool UpdateBalanceAmount(int cardId, int userId, decimal newAmount)
        {
           
            var data = new FilterDTO
            {
                Fields = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("hoeveelheid", newAmount.ToString(System.Globalization.CultureInfo.InvariantCulture))
                }
            };

            UpdateDTO<Balance> result;

            try
            {
                result = client.Send<UpdateDTO<Balance>>(data, HttpRequestType.POST, $"user/{userId}/cards/{cardId}/update");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            if (result != null)
            {
                return result.Success;
            }

            return false;
        }
        //0x24
    }
}
