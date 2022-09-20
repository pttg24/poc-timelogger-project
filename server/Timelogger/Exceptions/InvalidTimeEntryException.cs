namespace Timelogger.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class InvalidTimeEntryException : Exception
    {
        public InvalidTimeEntryException(string message) : base(message)
        {
        }

        public InvalidTimeEntryException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
