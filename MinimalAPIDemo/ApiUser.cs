namespace MinimalAPIDemo;

public static class ApiUser
{
    public static void ConfigureApiUser(this WebApplication app)
    {
        app.MapGet("/Api/GetAllUsers", GetAllUsers);
        app.MapGet("/Api/GetUsersByName/{name}", GetUsersByName);
        app.MapGet("/Api/GetUser/{id}", GetUser);
        app.MapPost("/Api/InsertUser", InsertUser);
        app.MapPut("/Api/UpdateUser", UpdateUser);
        app.MapDelete("/Api/DeleteUser/{id}", DeleteUser);
        app.Logger.LogInformation("Configure ApiUser Endpoints");
    }

    private static async Task<IResult> GetAllUsers(IUserRepository userRepository)
    {
        try
        {
            return Results.Ok(await userRepository.GetAllUsers());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetUsersByName(string name, IUserRepository userRepository)
    {
        try
        {
            var results = await userRepository.GetUsersByName(name);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetUser(int id, IUserRepository userRepository)
    {
        try
        {
            var results = await userRepository.GetUser(id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> InsertUser(UserModel user, IUserRepository userRepository)
    {
        try
        {
            await userRepository.InsertUser(user);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateUser(UserModel user, IUserRepository userRepository)
    {
        try
        {
            await userRepository.UpdateUser(user);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteUser(int id, IUserRepository userRepository)
    {
        try
        {
            await userRepository.DeleteUser(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
