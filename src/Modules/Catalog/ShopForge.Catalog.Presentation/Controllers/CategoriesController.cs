using Microsoft.AspNetCore.Mvc;
using ShopForge.BuildingBlocks.Presentation;
using ShopForge.Catalog.Application.Categories.Commands.CreateCategory;
using ShopForge.Catalog.Presentation.Requests;

namespace ShopForge.Catalog.Presentation.Controllers;

public sealed class CategoriesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create(CategoryCreateRequest request, CancellationToken ct)
    {
        var result = await Mediator.Send(new CreateCategoryCommand(request.Name, request.Description, request.ParentId, request.IsActive));

        return result.IsSuccess
            ? CreatedAtAction(nameof(GetById), new { id = result.Value }, result.Value)
            : HandleFailure(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken ct)
    {
        var result = await Mediator.Send(new GetCategoryQuery(id), ct);
        return result.IsSuccess ? Ok(result.Value) : HandleFailure(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        var result = await Mediator.Send(new GetCategoriesQuery(), ct);
        return Ok(result.Value);
    }

    [HttpPut("{id:guid}/name")]
    public async Task<IActionResult> Rename(Guid id, RenameCategoryRequest request, CancellationToken ct)
    {
        var result = await Mediator.Send(new RenameCategoryCommand(id, request.Name), ct);
        return result.IsSuccess ? NoContent() : HandleFailure(result);
    }
}
