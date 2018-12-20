using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Exceptions
{
    public class WhereException: Exception
    {
        public WhereException()
        {
        }

        public WhereException(string message)
            : base(message)
        {
        }

        public WhereException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
