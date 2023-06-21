using ConsoleRestSharp;

var appClent = new ApiClient("https://localhost:5001");

var users = appClent.GetUsers();
if (users != null)
{
    Console.WriteLine("List: ");
    foreach (var u in users)
    {
        Console.WriteLine("{0} {1} {2}", u.Id, u.FirstName, u.LastName);
    }
}

var user = appClent.GetUser(3);
if (user != null)
{
    Console.WriteLine("Single: ");
    Console.WriteLine("{0} {1} {2}", user.Id, user.FirstName, user.LastName);
}
Console.ReadLine();


