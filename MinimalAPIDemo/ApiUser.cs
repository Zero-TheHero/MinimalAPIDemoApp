using CoreBusiness.Models;
using CoreBusiness.Repositories;

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

    private static async Task<IResult> GetAllUsers(IUserRepository data)
    {
        try
        {
            return Results.Ok(await data.GetAllUsers());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetUsersByName(string name, IUserRepository data)
    {
        try
        {
            var results = await data.GetUsersByName(name);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> GetUser(int id, IUserRepository data)
    {
        try
        {
            var results = await data.GetUser(id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> InsertUser(UserModel user, IUserRepository data)
    {
        try
        {
            await data.InsertUser(user);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateUser(UserModel user, IUserRepository data)
    {
        try
        {
            await data.UpdateUser(user);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteUser(int id, IUserRepository data)
    {
        try
        {
            await data.DeleteUser(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
