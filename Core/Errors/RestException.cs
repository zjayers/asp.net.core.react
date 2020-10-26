using System;
using System.Net;

namespace Core.Errors
{
    public class RestException : Exception
    {
        public object Errors;
        public HttpStatusCode StatusCode;

        public RestException(HttpStatusCode statusCode, object errors = null)
        {
            StatusCode = statusCode;
            Errors = errors;
        }
    }
}