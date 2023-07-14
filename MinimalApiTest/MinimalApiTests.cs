using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;

namespace MinimalApiDemo.Test;
public class MinimalApiTests : IDisposable
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly HttpClient _client;

    public MinimalApiTests()
    {
        _factory = new WebApplicationFactory<Program>();
        _client = _factory.CreateClient();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _client.Dispose();
            _factory.Dispose();
        }
    }
    
    [Fact]
    public async void GetAllUsers()
    {
        var response = await _client.GetAsync("/Api/GetAllUsers");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    [Fact]
    public async void GetUser()
    {
        var response = await _client.GetAsync("/Api/GetUser/3");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async void GetUsersByName()
    {
        var response = await _client.GetAsync("/Api/GetUsersByName/Storm");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async void DeleteUser()
    {
        var response = await _client.DeleteAsync("/Api/DeleteUser/4");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async void InserUser()
    {
        var content = new StringContent(JsonConvert.SerializeObject(new { id = 5, firstname = "Peter", LastName = "Wong" }));
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        var response = await _client.PostAsync("/Api/InsertUser", content);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async void UpdateUser()
    {
        var content = new StringContent(JsonConvert.SerializeObject(new { id = 1, firstname = "Lisa", LastName = "Wong" }));
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        var response = await _client.PutAsync("/Api/UpdateUser", content);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
