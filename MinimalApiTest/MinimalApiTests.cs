using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace MinimalApiDemo.Test;

public class MinimalApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;
    private HttpResponseMessage? _response;

    public MinimalApiTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async void GetUsers()
    {
        //await using var application = new WebApplicationFactory<Program>();
        //using var client = application.CreateClient();
        _response = await _client.GetAsync("/Api/GetTests");
        //var data = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.OK, _response.StatusCode);
        
    }

    [Fact]
    public async void GetUser()
    {
        _response = await _client.GetAsync("/Api/GetTest/1");
        Assert.Equal(HttpStatusCode.OK, _response.StatusCode);
    }

    [Fact]
    public async void DeleteUser()
    {
        _response = await _client.DeleteAsync("/Api/DeleteTest/2");
        Assert.Equal(HttpStatusCode.OK, _response.StatusCode);
    }
}