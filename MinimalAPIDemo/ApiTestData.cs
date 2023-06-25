﻿namespace MinimalAPIDemo;

public static class ApiTestData
{
    public static void ConfigureApiTestData(this WebApplication app)
    {
        List<UserModel> users = new()
        {
            new() {Id = 1, FirstName = "TimTest", LastName = "Corey"},
            new() {Id = 2, FirstName = "SueTest", LastName = "Storm"},
            new() {Id = 3, FirstName = "JohnTest", LastName = "Smith"},
            new() {Id = 4, FirstName = "MaryTest", LastName = "Jones"}

        };

        var urlFragment = "/Api/TestData";
        app.MapGet(urlFragment, () => 
        { 
            return Results.Ok(users);
        });
        //app.MapGet(urlFragment + "{id}", GetUser);
        //app.MapPost(urlFragment, InsertUser);
        //app.MapPut(urlFragment, UpdateUser);
        //app.MapDelete(urlFragment, DeleteUser);
        app.Logger.LogInformation("Configure {urlFragment} Endpoints", urlFragment);
    }

    //private static async Task<IResult> GetUsers(IUserData data)
    //{
    //    try
    //    {
    //        return Results.Ok(await data.GetUsers());
    //    }
    //    catch (Exception ex)
    //    {
    //        return Results.Problem(ex.Message);
    //    }
    //}

    //private static async Task<IResult> GetUser(int id, IUserData data)
    //{
    //    try
    //    {
    //        var results = await data.GetUser(id);
    //        if (results == null) return Results.NotFound();
    //        return Results.Ok(results);
    //    }
    //    catch (Exception ex)
    //    {
    //        return Results.Problem(ex.Message);
    //    }
    //}

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
