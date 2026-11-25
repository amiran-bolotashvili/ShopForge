using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ShopForge.Api.Extensions;

public sealed class ValidationExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext context, Exception exception, CancellationToken ct)
    {
        if (exception is not ValidationException validation)
            return false;

        var errors = validation.Errors
            .GroupBy(e => e.PropertyName)
            .ToDictionary(g => g.Key, g => g.Select(e => e.ErrorMessage)).ToArray();

        //contex.Response.StatusCode = StatusCodes.Status400BadRequest;
        //await contex.Response.WriteAsJsonAsync(
        //    new ValidationProblemDetails(errors) { Status = 400}, ct);

        await context.Response.WriteAsJsonAsync(
            new ValidationProblemDetails(
                errors.ToDictionary(e => e.Key, e => e.Value.ToArray()))
                    { Status = 400 },
                    ct);

        return true;
    }
}
