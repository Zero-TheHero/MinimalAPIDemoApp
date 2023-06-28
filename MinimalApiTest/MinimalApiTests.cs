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
    public async void GetTests()
    {
        var response = await _client.GetAsync("/Api/GetTests");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    [Fact]
    public async void GetTest()
    {
        var response = await _client.GetAsync("/Api/GetTest/1");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async void DeleteTest()
    {
        var response = await _client.DeleteAsync("/Api/DeleteTest/3");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async void InserTest()
    {
        var content = new StringContent(JsonConvert.SerializeObject(new { id = 5, firstname = "Peter", LastName = "Cassinelli" }));
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        var response = await _client.PostAsync("/Api/InsertTest", content);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async void Updatetest()
    {
        var content = new StringContent(JsonConvert.SerializeObject(new { id = 1, firstname = "Lisa", LastName = "Cassinelli" }));
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        var response = await _client.PutAsync("/Api/UpdateTest", content);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
