using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Results
{
    public class ResultDTO<T>
    {
        public List<T> Result { get; set; }
        public int ResultCount { get
            {
                return Result.Count;
            } }

        public ResultDTO()
        {
            Result = new List<T>();
        }
    }
}
