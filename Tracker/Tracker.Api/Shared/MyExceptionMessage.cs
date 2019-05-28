using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracker.Shared
{
    public class MyExceptionMessage
    {
        public string message { get; set; }
        public string detail { get; set; }

        public MyExceptionMessage(string message)
        {
            this.message = message;
        }
    }
}
