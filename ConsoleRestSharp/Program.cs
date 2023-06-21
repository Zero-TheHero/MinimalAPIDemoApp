using ConsoleRestSharp;

var users = ApiClient.GetUsers();
if (users != null)
{
    Console.WriteLine("List: ");
    foreach (var u in users)
    {
        Console.WriteLine("{0} {1} {2}", u.Id, u.FirstName, u.LastName);
    }
}

var user = ApiClient.GetUser(3);
if (user != null)
{
    Console.WriteLine("Single: ");
    Console.WriteLine("{0} {1} {2}", user.Id, user.FirstName, user.LastName);
}
Console.ReadLine();


