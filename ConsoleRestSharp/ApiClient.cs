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
        if (response.IsSuccessful && (response.Content != null))
        {
            var user = JsonConvert.DeserializeObject<UserModel>(response.Content.ToString());
            return user;
         }
        return null;
    }

    public List<UserModel>? GetUsers()
    {
        var request = new RestRequest("Users", Method.Get)
        {
            RequestFormat = DataFormat.Json
        };
        var response = _client.Execute(request);
        if (response.IsSuccessful && (response.Content != null))
        {
            var users = JsonConvert.DeserializeObject<List<UserModel>>(response.Content.ToString());
            return users;
         }
        return null;
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
