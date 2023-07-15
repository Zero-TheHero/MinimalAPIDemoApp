using CoreBusiness.DbAccess;
using CoreBusiness.Models;
using CoreBusiness.Repositories;

namespace Plugins.SqlRepository;

public class UserRepository : IUserRepository
{
    private readonly ISqlDataAccess _db;

    public UserRepository(ISqlDataAccess db) 
    { 
        _db = db;
    }

    public async Task<IEnumerable<UserModel>> GetAllUsers() => await _db.LoadData<UserModel, dynamic>("dbo.spUser_GetAll", new { });

    public async Task<IEnumerable<UserModel>> GetUsersByName(string? name) => await _db.LoadData<UserModel, dynamic>("dbo.spUser_GetUsersByName", new { Name = name} );
 
    public async Task<UserModel?> GetUser(int id) => (await _db.LoadData<UserModel, dynamic>("dbo.spUser_Get", new { Id = id })).FirstOrDefault();
 
    public Task InsertUser(UserModel user) => _db.SaveData("dbo.spUser_Insert", new { user.FirstName, user.LastName });

    public Task UpdateUser(UserModel user) => _db.SaveData("dbo.spUser_Update", user);

    public Task DeleteUser(int id) => _db.SaveData("dbo.spUser_Delete", new { Id = id });

 
}
