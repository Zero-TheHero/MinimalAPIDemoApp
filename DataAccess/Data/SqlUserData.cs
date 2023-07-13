using DataAccess.DbAccess;
using DataAccess.Models;

namespace DataAccess.Data;

public class SqlUserData : IUserData
{
    private readonly ISqlDataAccess _db;

    public SqlUserData(ISqlDataAccess db) 
    { 
        _db = db;
    }

    public async Task<IEnumerable<UserModel>> GetUsers() => await _db.LoadData<UserModel, dynamic>("dbo.spUser_GetAll", new { });

    public async Task<UserModel?> GetUser(int id) => (await _db.LoadData<UserModel, dynamic>("dbo.spUser_Get", new { Id = id })).FirstOrDefault();
 
    public Task InsertUser(UserModel user) => _db.SaveData("dbo.spUser_Insert", new { user.FirstName, user.LastName });

    public Task UpdateUser(UserModel user) => _db.SaveData("dbo.spUser_Update", user);

    public Task DeleteUser(int id) => _db.SaveData("dbo.spUser_Delete", new { Id = id });
}
