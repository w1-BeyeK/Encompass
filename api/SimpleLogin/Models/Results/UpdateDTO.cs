using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Results
{
    public class UpdateDTO<T>: BaseDTO
    {
        public T Obj { get; set; }
    }
}
