using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingSystem.Exceptions
{
    public class PermissionException : Exception
    {
        public PermissionException(string message, Exception innerException) 
            : base(message, innerException) { }

    }
}
