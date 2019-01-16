using System;
using System.Collections.Generic;
using System.Text;

namespace Encompass.Models
{
    public class UpdateDTO<T> : BaseDTO
    {
        public T Obj { get; set; }
    }
}
