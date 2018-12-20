using Newtonsoft.Json;
using POCConnect.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace POCConnect.Logic
{
    public enum HttpRequestType
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    public class Webclient: IWebclient
    {
        protected string baseUrl = "http://pti409368core.venus.fhict.nl/api/";
        
        HttpClient client;

        public Webclient(string baseUrl)
        {
            this.baseUrl = baseUrl;
            
            client = new HttpClient();
        }

        public T Send<T>(FilterDTO filters, HttpRequestType type, string uri)
        {
            HttpRequestMessage message = new HttpRequestMessage(new HttpMethod(type.ToString()), baseUrl + uri);
            if (filters != null)
            {
                message.Content = new StringContent(JsonConvert.SerializeObject(filters));
                message.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }

            HttpResponseMessage response = client.SendAsync(message).GetAwaiter().GetResult();
            return Parser.GetInstance().Convert<T>(response);
        }
    }
}
