using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TechLibrary.Comunication.Response;
using TechLibrary.Exception;

namespace TechLibrary.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if(context.Exception is TechLibraryException exception)
            {
                context.HttpContext.Response.StatusCode = (int)exception.GetStatusCode();
                context.Result = new ObjectResult(new ResponseRegisterValidatorJson
                {
                    Errors = exception.GetMessageError()
                });
            }
        }
    }
}
