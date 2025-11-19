
using ECommerce.Application.GenericRespons;
using FluentValidation;
using Serilog;

namespace ECommerce.Api.Middlewares;

public class GlobalExceptionHandler : ResponseHandler, IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);

        }
        catch (Exception ex)
        {
            Log.Error(ex.ToString());

            if (typeof(InvalidOperationException) == ex.GetType() ||
                typeof(ArgumentOutOfRangeException) == ex.GetType() ||
                    typeof(ValidationException) == ex.GetType())
            {
                var response = BadRequest<string>(ex.Message);

                await context.Response.WriteAsJsonAsync(response);

                return;
            }

            var serverError = InternalServerError<string>("An unexpected error occurred.");


            await context.Response.WriteAsJsonAsync(serverError);
        }
    }
}
