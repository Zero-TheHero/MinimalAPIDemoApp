using Core.Business.Models;

namespace Core.Business.Repositories;

public interface IUserRepository
{
    Task DeleteUser(int id);
    Task<UserModel?> GetUser(int id);
    Task<IEnumerable<UserModel>> GetAllUsers();
    Task<IEnumerable<UserModel>> GetUsersByName(string name);
    Task InsertUser(UserModel user);
    Task UpdateUser(UserModel user);
}