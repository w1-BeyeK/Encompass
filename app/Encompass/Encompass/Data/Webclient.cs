using Encompass.Models;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Encompass.Data
{
    public enum HttpRequestType
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    public class Webclient : IWebclient
    {
        protected string baseUrl = "http://pti409368core.venus.fhict.nl/api/";
        
        HttpClient client;

        public Webclient(string baseUrl)
        {
            this.baseUrl = baseUrl;
            
            client = new HttpClient();
        }

        public T Send<T>(FilterDTO data, HttpRequestType type, string uri)
        {
            HttpRequestMessage message = new HttpRequestMessage(new HttpMethod(type.ToString()), baseUrl + uri);

            if (data != null)
            {
                message.Content = new StringContent(JsonConvert.SerializeObject(data));
                message.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }

            HttpResponseMessage response = client.SendAsync(message).GetAwaiter().GetResult();
            return Parser.GetInstance().Convert<T>(response);
        }
    }
}
