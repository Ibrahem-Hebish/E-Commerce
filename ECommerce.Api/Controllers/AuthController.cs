namespace ECommerce.Api.Controllers;


public class AuthController(ISender sender) : AppControllerBase
{
    [HttpGet("me")]
    [Authorize]
    public async Task<IActionResult> GetMe()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var id = Guid.Parse(userId!);

        var result = await sender.Send(new GetUserByIdQuery(id));

        return NewResponse(result);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterCommand command)
    {
        var result = await sender.Send(command);

        return NewResponse(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginCommand command)
    {
        var result = await sender.Send(command);

        return NewResponse(result);
    }

    [HttpPost("refreshToken")]
    public async Task<IActionResult> Login(RefreshTokenCommand command)
    {
        var result = await sender.Send(command);

        return NewResponse(result);
    }
}
