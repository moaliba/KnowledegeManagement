using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using UseCases.Exceptions;

namespace KnowledgeManagementAPI.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi =true)]
    public class ErrorController : ControllerBase
    {
        [Route("/error-local-development")]
        public IActionResult HandlerErrors([FromServices] IWebHostEnvironment webHostEnvironment)
        {
            if (webHostEnvironment.EnvironmentName != "Development")
            {
                throw new InvalidOperationException(
                    "This shouldn't be invoked in non-development environments.");
            }

            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();

            var responseStatusCode = context.Error.GetType();
            var exception = context.Error;
            var code = 500;
            if (exception is NotFoundException) code = StatusCodes.Status404NotFound; // Not Found
            else if (exception is BadRequestException) code = StatusCodes.Status400BadRequest; // Bad Request


            return Problem(
                detail: context.Error.StackTrace,
                statusCode: code,
                title: context.Error.Message); 
        }

        [Route("/error")]
        public IActionResult Error([FromServices] IWebHostEnvironment webHostEnvironment)
        {
            if (webHostEnvironment.EnvironmentName != "Development")
            {
                throw new InvalidOperationException(
                    "This shouldn't be invoked in non-development environments.");
            }

            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();

            var responseStatusCode = context.Error.GetType();
            var exception = context.Error;
            var code = 500;
            if (exception is NotFoundException) code = StatusCodes.Status404NotFound; // Not Found
            else if (exception is BadRequestException) code = StatusCodes.Status400BadRequest; // Bad Request


            return Problem(
                statusCode: code,
                title: context.Error.Message);
        }

       
    }
}
