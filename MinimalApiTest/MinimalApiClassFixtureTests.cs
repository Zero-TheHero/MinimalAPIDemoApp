using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;

namespace MinimalApiDemo.Test;

public class MinimalApiClassFixtureTests : IClassFixture<WebApplicationFactory<Program>>, IDisposable
{
    private readonly HttpClient _client;
    private HttpResponseMessage? _response;

    public MinimalApiClassFixtureTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async void GetAllUsers()
    {
        _response = await _client.GetAsync("/Api/GetAllUsers");
        //var data = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.OK, _response.StatusCode);
     }

    [Fact]
    public async void GetUsersByName()
    {
        var response = await _client.GetAsync("/Api/GetUsersByName/Storm");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async void GetUser()
    {
        _response = await _client.GetAsync("/Api/GetUser/1");
        Assert.Equal(HttpStatusCode.OK, _response.StatusCode);
    }

    [Fact]
    public async void DeleteUser()
    {
        _response = await _client.DeleteAsync("/Api/DeleteUser/4");
        Assert.Equal(HttpStatusCode.OK, _response.StatusCode);
    }

    [Fact]
    public async void InsertUser()
    {
        var content = new StringContent(JsonConvert.SerializeObject(new { id = 5, firstname = "Peter", LastName = "Wong" }));
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        _response = await _client.PostAsync("/Api/InsertUser", content);
        Assert.Equal(HttpStatusCode.OK, _response.StatusCode);
    }

    [Fact]
    public async void UpdateUser()
    {
        var content = new StringContent(JsonConvert.SerializeObject(new { id = 1, firstname = "Lisa", LastName = "Wong" }));
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        _response = await _client.PutAsync("/Api/UpdateUser", content);
        Assert.Equal(HttpStatusCode.OK, _response.StatusCode);
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
        }
    }
}