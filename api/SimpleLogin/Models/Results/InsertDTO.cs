using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Results
{
    public class InsertDTO<T>: BaseDTO
    {
        public int Id { get; set; }
    }
}
