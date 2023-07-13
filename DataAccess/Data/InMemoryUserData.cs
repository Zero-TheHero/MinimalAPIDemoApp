using DataAccess.Models;

namespace DataAccess.Data;
public class InMemoryUserData : IUserData
{
    private readonly List<UserModel> _users;

    public InMemoryUserData()
    {
        _users = new()
        {
            new() { Id = 1, FirstName = "TimTest", LastName = "Corey" },
            new() { Id = 2, FirstName = "SueTest", LastName = "Storm" },
            new() { Id = 3, FirstName = "JohnTest", LastName = "Smith" },
            new() { Id = 4, FirstName = "MaryTest", LastName = "Jones" }
        };
    }
 
    public Task DeleteUser(int id)
    {
        _users.Remove(_users.Single(x => x.Id == id));
        return Task.CompletedTask;
    }

    public Task<UserModel?> GetUser(int id)
    {
        var result = _users.FirstOrDefault(x => x.Id == id);
        return Task.FromResult(result);
    }


    public Task<IEnumerable<UserModel>> GetUsers() => Task.FromResult<IEnumerable<UserModel>>(_users);

    public Task InsertUser(UserModel user)
    {
        var maxId = _users.Max(x => x.Id) + 1;
        user.Id = maxId;
        _users.Add(user);
        return Task.CompletedTask;  
    }

    public Task UpdateUser(UserModel user)
    {
        var result = _users.Find(x => x.Id == user.Id);
        if (result != null)
        {
            user.FirstName = result.FirstName;
            user.LastName = result.LastName;
        }
        return Task.CompletedTask;
    }
}
