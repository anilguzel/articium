using Articium.User.Api;

namespace Articium.Services;

public interface IUserService
{
    Task<string> RegisterAsync(UserRegister model);
}

