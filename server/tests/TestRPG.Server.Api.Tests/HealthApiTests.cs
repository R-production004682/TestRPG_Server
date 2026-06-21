using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace TesstRPG.Server.Api.Tests;

public sealed class HealthApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient httpClient;

    public HealthApiTests(WebApplicationFactory<Program> factory)
    {
        httpClient = factory.CreateClient();
    }

    [Fact]
    public async Task GetHealth_ReturnsOKResponse()
    {
        // Act
        var response = await httpClient.GetAsync("/api/health");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var body = await response.Content.ReadFromJsonAsync<HealthResponseDto>();
        Assert.NotNull(body);
        Assert.Equal("ok", body!.Status);
    }

    private sealed record HealthResponseDto(string Status);
}