using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Company
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public int Category { get; set; }
        public string Logo { get; set; }
    }
}
