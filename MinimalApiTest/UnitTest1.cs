using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace MinimalApiTest;

public class UnitTest1
{
    [Fact]
    public async void Test1()
    {
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        var response = await client.GetAsync("/Api/GetTests");
        var data = await response.Content.ReadAsStringAsync();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}