using System;
using System.Net;

namespace Core.Errors
{
    public class RestException : Exception
    {
        public  HttpStatusCode StatusCode;
        public  object Errors;

        public RestException(HttpStatusCode statusCode, object errors = null)
        {
            StatusCode = statusCode;
            Errors = errors;
        }
    }
}
