using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCConnect.Logic.Models
{
    public class ResultDTO<T>
    {
        public List<T> Result { get; set; }
        public int ResultCount
        {
            get
            {
                return Result.Count;
            }
        }

        public ResultDTO()
        {
            Result = new List<T>();
        }
    }
}
