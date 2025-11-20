namespace ECommerce.Api.Controllers;

public class OrdersController(ISender sender) : AppControllerBase
{
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Get()
    {
        var result = await sender.Send(new GetAllOrdersQuery());

        return NewResponse(result);
    }

    [HttpGet("{id:Guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await sender.Send(new GetOrderByIdQuery(id));
        return NewResponse(result);
    }

    [HttpGet("details/{id:Guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetDetailsById(Guid id)
    {
        var result = await sender.Send(new GetOrderDetailsQuery(id));

        return NewResponse(result);
    }

    [HttpGet("customer/{customerId:Guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetByCustomerId(Guid customerId)
    {
        var result = await sender.Send(new GetOrdersByCastomerIdQuery(customerId));

        return NewResponse(result);
    }

    [HttpGet("history/{id:guid}")]
    [Authorize]
    public async Task<IActionResult> GetOrderHistory(Guid id)
    {
        var result = await sender.Send(new GetOrderHistoryQuery(id));
        return NewResponse(result);
    }

    [HttpGet("paginate")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAllPaged([FromQuery] PaginateOrdersQuery query)
    {
        var result = await sender.Send(query);

        return NewResponse(result);
    }

    [HttpGet("sort")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAllSorted([FromQuery] SortOrdersQuery query)
    {
        var result = await sender.Send(query);

        return NewResponse(result);
    }


    [HttpPost]
    [Authorize(Roles = "Customer")]
    public async Task<IActionResult> Create(CreateOrderCommand command)
    {
        var result = await sender.Send(command);

        return NewResponse(result);
    }

    [HttpPost("cancel/{id:Guid}")]
    [Authorize]
    public async Task<IActionResult> CancelOrder(Guid id)
    {
        var result = await sender.Send(new CancelOrderCommand(id));
        return NewResponse(result);
    }

    [HttpPost("confirm/{id:Guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Confirm(Guid id)
    {
        var result = await sender.Send(new ConfirmOrderCommand(id));
        return NewResponse(result);
    }
}