namespace Timelogger.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class InvalidProjectException : Exception
    {
        public InvalidProjectException(string message) : base(message)
        {
        }

        public InvalidProjectException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
