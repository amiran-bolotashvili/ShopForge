using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using ShopForge.BuildingBlocks.Domain;

namespace ShopForge.BuildingBlocks.Presentation;

[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : ControllerBase
{
    private ISender? _mediator;

    protected ISender Mediator =>
        _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

    protected IActionResult HandleFailure<T>(Result result) => result.Error.Code switch
    {
        var code when code.EndsWith("NotFound") => Problem(
            statusCode: StatusCodes.Status404NotFound, title: result.Error.Code, detail: result.Error.Description),
        var code when code.EndsWith("AlreadyExists") => Problem(
            statusCode: StatusCodes.Status409Conflict, title: result.Error.Code, detail: result.Error.Description),
        _ => Problem(
            statusCode: StatusCodes.Status400BadRequest, title: result.Error.Code, detail: result.Error.Description)
    };
}
