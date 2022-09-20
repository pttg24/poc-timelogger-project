namespace Timelogger.Api.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class InvalidTimeEntryApiException : Exception
    {
        public InvalidTimeEntryApiException(string message) : base(message)
        {
        }

        public InvalidTimeEntryApiException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
