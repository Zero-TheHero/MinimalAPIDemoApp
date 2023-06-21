using DataAccess.Models;
using Newtonsoft.Json;
using RestSharp;

namespace ConsoleRestSharp;
public static class ApiClient 
{
    public static bool DeleteUser(int id)
    {
        throw new NotImplementedException();
    }

    public static UserModel? GetUser(int id)
    {
        var client = new RestClient("https://localhost:5001");
        var request = new RestRequest("Users/" + id, Method.Get)
        {
            RequestFormat = DataFormat.Json
        };

        var response = client.Execute(request);
        var user = new UserModel();
        if (response.IsSuccessful && (response.Content != null))
        {
            user = JsonConvert.DeserializeObject<UserModel>(response.Content.ToString());
         }
        return user;
    }

    public static List<UserModel>? GetUsers()
    {
        var client = new RestClient("https://localhost:5001");
        var request = new RestRequest("Users", Method.Get)
        {
            RequestFormat = DataFormat.Json
        };

        var response = client.Execute(request);

        var users = new List<UserModel>();
        if (response.IsSuccessful && (response.Content != null))
        {
            users = JsonConvert.DeserializeObject<List<UserModel>>(response.Content.ToString());
         }
        return users;
    }

    public static bool InsertUser(UserModel user)
    {
        throw new NotImplementedException();

    }

    public static bool UpdateUser(UserModel user)
    {
        throw new NotImplementedException();
    }
}
