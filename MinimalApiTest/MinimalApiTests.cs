using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace MinimalApiDemo.Test;

public class MinimalApiTests
{
    [Fact]
    public async void IsApiWorking()
    {
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        var response = await client.GetAsync("/Api/GetTests");
        var data = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}