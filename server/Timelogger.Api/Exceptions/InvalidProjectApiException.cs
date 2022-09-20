namespace Timelogger.Api.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class InvalidProjectApiException : Exception
    {
        public InvalidProjectApiException(string message) : base(message)
        {
        }

        public InvalidProjectApiException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
