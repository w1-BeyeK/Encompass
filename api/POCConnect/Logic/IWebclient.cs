using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using POCConnect.Logic.Models;

namespace POCConnect.Logic
{
    public interface IWebclient
    {
        T Send<T>(FilterDTO filters, HttpRequestType type, string uri);
    }
}
