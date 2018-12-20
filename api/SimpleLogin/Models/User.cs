using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    /// <summary>
    /// User model
    /// </summary>
    public class User
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Birthdate { get; set; }
        public char[] Code { get; set; }
    }
}
