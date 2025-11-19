using ECommerce.Application.Features.Products.SortProducts;
using Serilog;
using System.Diagnostics;

namespace ECommerce.Api.Controllers;

public class ProductsController(ISender sender) : AppControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await sender.Send(new GetAllProductsQuery());

        return NewResponse(result);
    }

    [HttpGet("{id:Guid}")]
    [Authorize]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await sender.Send(new GetProductByIdQuery(id));

        return NewResponse(result);
    }

    [HttpGet("category/{id:Guid}")]
    [Authorize]
    public async Task<IActionResult> GetByCategoryId(Guid id)
    {
        var result = await sender.Send(new GetProductsByCategoryIdQuery(id));

        return NewResponse(result);
    }

    [HttpGet("paginate")]
    // [Authorize]
    public async Task<IActionResult> Paginate([FromQuery] PaginateProductsQuery command)
    {
        var result = await sender.Send(command);

        return NewResponse(result);
    }

    [HttpGet("sort-by")]
    //[Authorize]
    public async Task<IActionResult> SortBy([FromQuery] SortProductsQuery command)
    {
        var clock = new Stopwatch();

        clock.Start();
        var result = await sender.Send(command);

        clock.Stop();

        Log.Information(clock.ElapsedMilliseconds.ToString());
        return NewResponse(result);
    }

    [HttpGet("search")]
    [Authorize]
    public async Task<IActionResult> Search(string name)
    {
        var result = await sender.Send(new SearchProductsByNameQuery(name));

        return NewResponse(result);
    }

    [HttpPatch("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(Guid id, UpdateProductDto dto, [FromServices] IMapper mapper)
    {
        var command = mapper.Map<UpdateProductCommand>(dto);

        command.Id = id;

        var result = await sender.Send(command);

        return NewResponse(result);
    }

    [HttpPost("apply-discount")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> ApplyDiscount(ApplyDiscountCommand command)
    {
        var result = await sender.Send(command);

        return NewResponse(result);
    }

    [HttpPost("reseat-discount")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> ReseatDiscount(ReseatDiscountCommand command)
    {
        var result = await sender.Send(command);

        return NewResponse(result);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(CreateProductCommand command)
    {
        var result = await sender.Send(command);

        return NewResponse(result);
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await sender.Send(new DeleteProductCommand(id));

        return NewResponse(result);
    }
}
