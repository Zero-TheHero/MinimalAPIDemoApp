using DataAccess.Models;
using Newtonsoft.Json;
using RestSharp;

var client = new RestClient("https://localhost:5001");
var request = new RestRequest("Users", Method.Get)
{
    RequestFormat = DataFormat.Json
};
var response = client.Execute(request);

if (response.Content != null)
{
    var users = JsonConvert.DeserializeObject<List<UserModel>>(response.Content.ToString());

    if (users != null)
    foreach (var user in users)
    {
        Console.WriteLine("{0} {1} {2}", user.Id, user.FirstName, user.LastName);
    }
}


Console.ReadLine();


