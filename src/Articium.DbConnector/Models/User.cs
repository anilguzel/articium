namespace Articium.DbConnector.Models;

public class User : TEntity
{
    public User(string userName, string role)
    {
        UserName = userName;
        Role = role;
    }

    public string UserName { get; set; }
    public string Role { get; set; }
}

