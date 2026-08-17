using DevHabits.api.Middleware.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace DevHabits.api.Middleware.ExceptionHandlers;

public sealed class NotFoundExceptionHandler(
    IProblemDetailsService problemDetailsService) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is not NotFoundException notFoundException)
        {
            return  false;
        }

        httpContext.Response.StatusCode = StatusCodes.Status404NotFound;

        ProblemDetails problemDetails = new()
        {
            Status = StatusCodes.Status404NotFound,
            Title = "Resource Not Found",
            Detail = notFoundException.Message,
        };

        await problemDetailsService.WriteAsync(new ProblemDetailsContext 
        {
            HttpContext = httpContext,
            ProblemDetails = problemDetails,
        });

        return true;
    }
}
