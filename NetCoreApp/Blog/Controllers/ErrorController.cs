using System;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Features;
using System.Diagnostics;
using System.Net;
using Blog.Model.ViewModel;

namespace Gabbler.Conversation.Api.Controllers
{
    public class HttpException : Exception
    {
        public HttpException(HttpStatusCode statusCode) { StatusCode = statusCode; }
        public HttpStatusCode StatusCode { get; private set; }
    }

    [Produces("application/json")]
    [Route("api/Error")]
    public class ErrorController : Controller
    {
        [AllowAnonymous]
        public IActionResult Error()
        {
            // Gets the status code from the exception or web server.
            var statusCode = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error is HttpException httpEx ?
                httpEx.StatusCode : (HttpStatusCode)Response.StatusCode;

            // For API errors, responds with just the status code (no page).
            if (HttpContext.Features.Get<IHttpRequestFeature>().RawTarget.StartsWith("/api/", StringComparison.Ordinal))
                return Json((int)statusCode);

            // Creates a view model for a user-friendly error page.
            string text = null;
            switch (statusCode)
            {
                case HttpStatusCode.NotFound: text = "Page not found."; break;
                    // Add more as desired.
            }
            return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, ErrorText = text });

        }

    }
}