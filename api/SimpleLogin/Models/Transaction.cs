using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Transaction
    {
        public int ID { get; set; }
        public int BalanceID { get; set; }
        public DateTime PaymentTime { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
    }
}
