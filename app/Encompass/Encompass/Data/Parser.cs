using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Encompass.Data
{
    public class Parser
    {
        private static Parser instance = null;

        private Parser() { }

        public static Parser GetInstance()
        {
            if (instance == null)
            {
                instance = new Parser();
            }
            return instance;
        }

        public T Convert<T>(HttpResponseMessage message)
        {
            string response = message.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            return JsonConvert.DeserializeObject<T>(response);
        }
    }
}
