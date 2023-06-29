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
    public async void GetTests()
    {
        _response = await _client.GetAsync("/Api/GetTests");
        //var data = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.OK, _response.StatusCode);
     }

    [Fact]
    public async void GetTest()
    {
        _response = await _client.GetAsync("/Api/GetTest/1");
        Assert.Equal(HttpStatusCode.OK, _response.StatusCode);
    }

    [Fact]
    public async void DeleteTest()
    {
        _response = await _client.DeleteAsync("/Api/DeleteTest/2");
        Assert.Equal(HttpStatusCode.OK, _response.StatusCode);
    }

    [Fact]
    public async void InserTest()
    {
        var content = new StringContent(JsonConvert.SerializeObject(new { id = 5, firstname = "Peter", LastName = "Wong" }));
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        _response = await _client.PostAsync("/Api/InsertTest", content);
        Assert.Equal(HttpStatusCode.OK, _response.StatusCode);
    }

    [Fact]
    public async void Updatetest()
    {
        var content = new StringContent(JsonConvert.SerializeObject(new { id = 1, firstname = "Lisa", LastName = "Wong" }));
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        _response = await _client.PutAsync("/Api/UpdateTest", content);
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