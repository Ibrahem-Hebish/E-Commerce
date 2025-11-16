namespace ECommerce.Api.Controllers;

public class UserController(ISender sender) : AppControllerBase
{
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Get()
    {
        var result = await sender.Send(new GetAllCustomersQuery());

        return NewResponse(result);
    }

    [HttpGet("{id:Guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await sender.Send(new GetUserByIdQuery(id));

        return NewResponse(result);
    }

    [HttpPost("{id:Guid}/activate")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Activate(Guid id)
    {
        var result = await sender.Send(new ActivateUserCommand(id));

        return NewResponse(result);
    }

    [HttpDelete("{id:Guid}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await sender.Send(new DeactivateUserCommand(id));

        return NewResponse(result);
    }

    [HttpPut]
    [Authorize]
    public async Task<IActionResult> Update(UpdateCustomerInfo command)
    {
        var result = await sender.Send(command);

        return NewResponse(result);
    }
}