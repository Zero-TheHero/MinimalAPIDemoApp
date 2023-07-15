using MinimalAPIRestClient;
using Core.Business.Models;

var appClient = new ApiClient("https://localhost:5001");

var users = appClient.GetUsers();
if (users != null)
{
    Console.WriteLine("GetUsers");
    foreach (var u in users)
    {
        Console.WriteLine("{0} {1} {2}", u.Id, u.FirstName, u.LastName);
    }
}

var user = appClient.GetUser(3);
if (user != null)
{
    Console.WriteLine("GetUser {0} {1} {2}", user.Id, user.FirstName, user.LastName);
    var deleted = appClient.DeleteUser(3);
    if (deleted)
    {
        Console.WriteLine("DeleteUser {0} {1} {2}", user.Id, user.FirstName, user.LastName);
    }
}
users = appClient.GetUsers();
if (users != null)
{
    Console.WriteLine("New List: ");
    foreach (var u in users)
    {
        Console.WriteLine("{0} {1} {2}", u.Id, u.FirstName, u.LastName);
    }
}

var inserted = appClient.InsertUser(new UserModel { Id = 3, FirstName = "Peter", LastName = "Wong" });
if (inserted)
{
    users = appClient.GetUsers();
    if (users != null)
    {
        Console.WriteLine("After Insert: ");
        foreach (var u in users)
        {
            Console.WriteLine("{0} {1} {2}", u.Id, u.FirstName, u.LastName);
        }
    }
}

var updated = appClient.UpdateUser(new UserModel { Id = 3, FirstName = "John", LastName = "Smith" });
if (updated)
{
    users = appClient.GetUsers();
    if (users != null)
    {
        Console.WriteLine("After Update: ");
        foreach (var u in users)
        {
            Console.WriteLine("{0} {1} {2}", u.Id, u.FirstName, u.LastName);
        }
    }
}
Console.ReadLine();


