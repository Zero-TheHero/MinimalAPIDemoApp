namespace MinimalAPIDemo;

public static class ApiTest
{
    private static readonly List<UserModel> _users = new()
    {
        new() {Id = 1, FirstName = "TimTest", LastName = "Corey"},
        new() {Id = 2, FirstName = "SueTest", LastName = "Storm"},
        new() {Id = 3, FirstName = "JohnTest", LastName = "Smith"},
        new() {Id = 4, FirstName = "MaryTest", LastName = "Jones"}
    };

    public static void ConfigureApiTest(this WebApplication app)
    {
        app.MapGet("/Api/GetTests" , GetTests);
        app.MapGet("/Api/GetTest/{id}", GetTest);
        app.MapPost("/Api/InsertTest", InsertTest);
        app.MapPut("/Api/UpdateTest", UpdateTest);
        app.MapDelete("/Api/DeleteTest/{id}", DeleteTest);
        app.Logger.LogInformation("Configure ApiTest Endpoints");
    }

    private static IResult GetTests() 
    {
        try
        {
            return Results.Ok(_users);
        }
        catch (Exception ex)
        {

            return Results.Problem(ex.Message);
        }     
    }

    private static IResult GetTest(int id) 
    {
        try
        {
            return Results.Ok(_users.Single(x => x.Id == id));
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }     
    }
 
    private static IResult InsertTest(UserModel model)
    {
        try
        {
            _users.Add(model);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
   
    private static IResult UpdateTest(UserModel model) 
    {
        try
        {
            var user = _users.Find(x => x.Id == model.Id);
            if (user != null) 
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                return Results.Ok();
            }
            return Results.NotFound();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
   
    private static IResult DeleteTest(int id)
    {
        try
        {
            _users.Remove(_users.Single(x => x.Id == id));
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

}
