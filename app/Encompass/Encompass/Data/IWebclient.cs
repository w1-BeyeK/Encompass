using Encompass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Encompass.Data
{
    public interface IWebclient
    {
        T Send<T>(FilterDTO data, HttpRequestType type, string uri);
    }
}
