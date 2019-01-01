using Newtonsoft.Json;
using POCConnect.Logic.Models;
using POCConnect.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace POCConnect
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebclient client = new Webclient("http://pti409368core.venus.fhict.nl/api/");

            var data = new FilterDTO()
            {
                Fields = new List<KeyValuePair<string, string>>()
                    {
                        // new KeyValuePair<string, string>("email", "kbeye1999@hotmail.com"),
                        // new KeyValuePair<string, string>("wachtwoord", "asdf123"),
                        // voor inloggen met code:
                        new KeyValuePair<string, string>("code", "55827"),
                        // 55827

                    }
            };

            var json = JsonConvert.SerializeObject(data);

            ResultDTO<User> login = client.Send<ResultDTO<User>>(
                data, 
                HttpRequestType.POST, 
                "user/login"
            );
            
            foreach(User u in login.Result)
            {
                var cards = client.Send<ResultDTO<Balance>>(null, HttpRequestType.GET, "api/user/" + u.ID + "/cards");
            }
        }
    }
}
