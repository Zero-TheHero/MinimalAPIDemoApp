using Core.Business.Models;

namespace MinimalAPIRestClient;
public interface IApiClient
{
    bool DeleteUser(int id);
    UserModel? GetUser(int id);
    List<UserModel>? GetUsers();
    bool InsertUser(UserModel user);
    bool UpdateUser(UserModel user);
}