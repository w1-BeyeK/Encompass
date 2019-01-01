using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encompass.Models
{
    public class Balance
    {
        public int UserId { get; set; }
        public int CardId { get; set; }
        public decimal Amount { get; set; }
        public bool Favorite { get; set; }

        public Card Card { get; set; }
    }
}
