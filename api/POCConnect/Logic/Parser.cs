using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace POCConnect.Logic
{
    public class Parser
    {
        private static Parser instance = null;

        private Parser() { }

        public static Parser GetInstance()
        {
            if(instance == null)
            {
                instance = new Parser();
            }
            return instance;
        }

        public T Convert<T>(HttpResponseMessage message)
        {
            return JsonConvert.DeserializeObject<T>(message.Content.ReadAsStringAsync().GetAwaiter().GetResult());
        }
    }
}
