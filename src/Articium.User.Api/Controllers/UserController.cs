using Articium.Services;
using Microsoft.AspNetCore.Mvc;

namespace Articium.User.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost(Name = "register")]
    public async Task<string> Register(UserRegister registerModel)
    {
        return await _userService.RegisterAsync(registerModel);
    }
}

