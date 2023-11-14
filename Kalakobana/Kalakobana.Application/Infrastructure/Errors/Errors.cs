using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using Kalakobana.Application.Infrastructure.Errors.Custom;

namespace Kalakobana.Application.Infrastructure.Errors
{
    public class Errors : ProblemDetails
    {
        private HttpContext _context;
        private Exception _ex;
        public const string UnhandlerErrorCode = "UnhandledError";
        public LogLevel Level { get; set; }
        public string Code { get; set; }

        public string Message { get; set; }
        //public string TraceId
        //{
        //    //get
        //    //{
        //    //    if (Extensions.TryGetValue("TraceId", out var traceId))
        //    //    {
        //    //        return (string)traceId;
        //    //    }

        //    //    return null;
        //    //}

        //    //set => Extensions["TraceId"] = value;
        //}
        public Errors(HttpContext httpContext, Exception exception)
        {
            _context = httpContext;
            _ex = exception;
            //TraceId = httpContext.TraceIdentifier;
            Code = UnhandlerErrorCode;
            Status = (int)HttpStatusCode.InternalServerError;
            Title = exception.Message;
            Level = LogLevel.Error;
            Instance = httpContext.Request.Path;
            HandleException((dynamic)exception);
        }
        private void HandleException(NotFoundException exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.NotFound;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";
            Title = exception.Message;
            Level = LogLevel.Information;
        }

        private void HandleException(AlreadyExistsException exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.Conflict;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.9";
            Title = exception.Message;
            Level = LogLevel.Information;
        }
        private void HandleException(CriticalException exception)
        {
            Code = exception.Code;
            Status = (int)HttpStatusCode.InternalServerError;
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1";
            Title = exception.Message;
            Level = LogLevel.Error;
        }

        private void HandleException(Exception exception)
        {

        }
    }
}
