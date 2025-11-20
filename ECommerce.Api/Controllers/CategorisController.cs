using ECommerce.Application.Dtos.Categories;
using ECommerce.Application.Features.Categories.Create;
using ECommerce.Application.Features.Categories.Delete;
using ECommerce.Application.Features.Categories.GetAll;
using ECommerce.Application.Features.Categories.GetById;
using ECommerce.Application.Features.Categories.Update;

namespace ECommerce.Api.Controllers;

public class CategorisController(ISender sender) : AppControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await sender.Send(new GetAllCategoriesQuery());

        return NewResponse(result);
    }

    [HttpGet("{id:Guid}")]
    [Authorize]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await sender.Send(new GetCategoryByIdQuery(id));

        return NewResponse(result);
    }

    [HttpPatch("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(Guid id, UpdateCategoryDto dto)
    {
        var command = new UpdateCategoryCommand(id, dto);

        var result = await sender.Send(command);

        return NewResponse(result);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(CreateCategoryCommand command)
    {
        var result = await sender.Send(command);

        return NewResponse(result);
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await sender.Send(new DeleteCategoryCommand(id));

        return NewResponse(result);
    }

}