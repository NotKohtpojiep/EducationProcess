using System;
using System.Net;

namespace EducationProcess.ApiClient
{
    public sealed class EducationProcessException : Exception
    {
        public EducationProcessException(HttpStatusCode statusCode)
            => HttpStatusCode = statusCode;

        public EducationProcessException(HttpStatusCode statusCode, string message) : base(message)
            => HttpStatusCode = statusCode;

        public EducationProcessException(HttpStatusCode statusCode, string message, Exception innerException) : base(message, innerException)
            => HttpStatusCode = statusCode;

        public HttpStatusCode HttpStatusCode { get; }
    }
}