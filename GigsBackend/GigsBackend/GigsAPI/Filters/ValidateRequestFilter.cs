using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GigsAPI.Filters;

public class ValidateRequestFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        // Check if the request is POST and has any null arguments
        if (context.HttpContext.Request.Method == HttpMethods.Post &&
            context.ActionArguments.Values.Any(value => value == null))
        {
            context.Result = new BadRequestObjectResult(new
            {
                Message = "Request cannot be null",
                StatusCode = 400
            });
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        // No action needed after execution
    }
}