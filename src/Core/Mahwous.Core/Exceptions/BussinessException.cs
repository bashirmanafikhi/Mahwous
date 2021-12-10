using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Mahwous.Core.Exceptions
{
    public class BussinessException : Exception
    {
        public BussinessException() 
            : base() { }

        public BussinessException(string message) 
            : base(message) { }

        public BussinessException(string[] messages) 
            : this(string.Join(",", messages)) { }

        public BussinessException(IEnumerable<string> messages) 
            : this(messages.ToArray()) { }

    }
}
