using DataAccess.Models;
using Newtonsoft.Json;
using RestSharp;

var client = new RestClient("https://localhost:5001");
var request = new RestRequest("Users", Method.Get)
{
    RequestFormat = DataFormat.Json
};

var response = client.Execute(request);

if (response.IsSuccessful && (response.Content != null) )
{
    var users = JsonConvert.DeserializeObject<List<UserModel>>(response.Content.ToString());
    if (users != null)
    {
        Console.WriteLine("List: ");
        foreach (var user in users)
        {
            Console.WriteLine("{0} {1} {2}", user.Id, user.FirstName, user.LastName);
        }
    }
}

request = new RestRequest("Users/3", Method.Get)
{
    RequestFormat = DataFormat.Json
};

response = client.Execute(request);

if (response.IsSuccessful && (response.Content != null))
{
    var user = JsonConvert.DeserializeObject<UserModel>(response.Content.ToString());
    if (user != null)
    {
        Console.WriteLine("Single: ");
        Console.WriteLine("{0} {1} {2}", user.Id, user.FirstName, user.LastName);
    }
}

Console.ReadLine();


