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
    public static void ConfigureApiTestData(this WebApplication app)
    {
        var urlFragment = "/Api/Test";

        app.MapGet(urlFragment, GetTestData);
        app.MapGet(urlFragment + "/{id}", GetTestDataById);
        app.MapPost(urlFragment, InsertTestData);
        app.MapPut(urlFragment, UpdateTestData);
        app.MapDelete(urlFragment + "/{id}", DeleteTestData);
        app.Logger.LogInformation("Configure {urlFragment} Endpoints", urlFragment);
    }

    private static IResult GetTestData() 
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

    private static IResult GetTestDataById(int id) 
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
 
    private static IResult InsertTestData(UserModel model)
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
   
    private static IResult UpdateTestData(UserModel model) 
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
   
    private static IResult DeleteTestData(int id)
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
