using API.Models.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    /// <summary>
    /// Base service methods nessecairy
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IBaseService<T>
    {
        ResultDTO<T> Get();
        ResultDTO<T> GetById(FilterDTO filters);
        InsertDTO<T> Insert(FilterDTO filters);
        UpdateDTO<T> Update(FilterDTO filters);
        BaseDTO Delete(FilterDTO filters);
    }
}
