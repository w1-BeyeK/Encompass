using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encompass.Models
{
    public class Card
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Image { get; set; }
        public Card(string name)
        {
            Name = name;
        }
    }
}
