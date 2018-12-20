using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Results
{
    public class MODResultDTO<T>
    {
        public bool Success { get; set; }
        public int Id { get; set; }
        public T Obj { get; set; }
    }
}
