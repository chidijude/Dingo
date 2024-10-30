using Dingo.Api.Domain;

namespace Dingo.Api.Services;

public class UserService
{
    private static List<User> _users = [];
    public void CreateUser(User user)
    {
        _users.Add(user);
    }

    public User? Get(Guid userId)
    {
        return _users.Find(u => u.Id.Equals(userId));
    }

    public IEnumerable<User> Get()
    {
        return _users.AsReadOnly();
    }

    public IEnumerable<User> AsQueryable()
    {
        return _users.AsQueryable();
    }
}
