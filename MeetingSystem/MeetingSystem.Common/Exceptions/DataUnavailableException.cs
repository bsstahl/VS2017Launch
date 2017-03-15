using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingSystem.Exceptions
{
    public class DataUnavailableException: Exception
    {
        public DataUnavailableException(string message)
            : base(message) { }

        public DataUnavailableException(string message, Exception innerException) 
            : base(message, innerException) { }
    }
}
