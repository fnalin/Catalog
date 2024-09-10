using Catalog.Domain.Exceptions.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Catalog.Api.Infra.Filters;

public class CustomExceptionFilter (IHostEnvironment env) : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var details = new ProblemDetails();
        switch (context.Exception)
        {
            
            case EntityNotFoundException en:
                details.Title = "Resource not found";
                details.Status = 404;
                details.Type = "NotFound";
                break;
            default:
                details.Title = "Unexpected error";
                if (env.IsDevelopment())
                {
                    details.Detail = context.Exception.Message;
                    details.Extensions.Add("StackTrace", context.Exception.StackTrace);
                }
                details.Status = 500;
                details.Type = "InternalServerError";
                break;
        }
        context.ExceptionHandled = true;
        context.Result = new ObjectResult(details)
        {
            StatusCode = details.Status
        };
        
    }
}