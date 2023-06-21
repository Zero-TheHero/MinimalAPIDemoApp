using DataAccess.Models;
using Newtonsoft.Json;
using RestSharp;

namespace ConsoleRestSharp;
public class ApiClient 
{
    
    private readonly RestClient _client;

    public ApiClient(string baseUri)
    {
        _client = new RestClient(baseUri);
    }
    public UserModel? GetUser(int id)
    {
        var request = new RestRequest("Users/" + id, Method.Get)
        {
            RequestFormat = DataFormat.Json
        };

        var response = _client.Execute(request);
        var user = new UserModel();
        if (response.IsSuccessful && (response.Content != null))
        {
            user = JsonConvert.DeserializeObject<UserModel>(response.Content.ToString());
         }
        return user;
    }

    public List<UserModel>? GetUsers()
    {
        var request = new RestRequest("Users", Method.Get)
        {
            RequestFormat = DataFormat.Json
        };

        var response = _client.Execute(request);

        var users = new List<UserModel>();
        if (response.IsSuccessful && (response.Content != null))
        {
            users = JsonConvert.DeserializeObject<List<UserModel>>(response.Content.ToString());
         }
        return users;
    }

    public bool InsertUser(UserModel user)
    {
        throw new NotImplementedException();

    }

    public bool UpdateUser(UserModel user)
    {
        throw new NotImplementedException();
    }
    public bool DeleteUser(int id)
    {
        throw new NotImplementedException();
    }
}
