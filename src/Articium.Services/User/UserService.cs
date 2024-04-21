using Articium.DbConnector;
using Articium.User.Api;
using Articium.Utils;

namespace Articium.Services;
public class UserService : IUserService
{
    private readonly ArticiumDbContext _context;

    public UserService(ArticiumDbContext context)
    {
        _context = context;
    }

    public async Task<string> RegisterAsync(UserRegister model)
    {
        // model validation & etc ...

        var user = new DbConnector.Models.User(model.UserName, model.Role);

        _context.Add(user);
        await _context.SaveChangesAsync();

        return JwtHelper.GenerateToken(user.Id, user.Role, user.UserName);
    }
}

