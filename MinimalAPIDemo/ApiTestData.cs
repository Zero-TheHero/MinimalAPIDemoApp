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
        app.MapGet(urlFragment + "{id}", GetTestDataById);
        //app.MapPost(urlFragment, InsertUser);
        //app.MapPut(urlFragment, UpdateUser);
        //app.MapDelete(urlFragment, DeleteUser);
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
 

    //private static async Task<IResult> InsertUser(UserModel user, IUserData data)
    //{
    //    try
    //    {
    //        await data.InsertUser(user);
    //        return Results.Ok();
    //    }
    //    catch (Exception ex)
    //    {
    //        return Results.Problem(ex.Message);
    //    }
    //}

    //private static async Task<IResult> UpdateUser(UserModel user, IUserData data)
    //{
    //    try
    //    {
    //        await data.UpdateUser(user);
    //        return Results.Ok();
    //    }
    //    catch (Exception ex)
    //    {
    //        return Results.Problem(ex.Message);
    //    }
    //}

    //private static async Task<IResult> DeleteUser(int id, IUserData data)
    //{
    //    try
    //    {
    //        await data.DeleteUser(id);
    //        return Results.Ok();
    //    }
    //    catch (Exception ex)
    //    {
    //        return Results.Problem(ex.Message);
    //    }
    //}
}
