using Microsoft.AspNetCore.Mvc;
using TestRPG.Server.Api.Controllers;
using Xunit;

namespace TestRPG.Server.Api.Tests.Controllers;

public sealed class HealthControllerTests
{
    /// <summary>
    /// 内容 : HealthControllerのGetメソッドが正常に動作するかをテストする
    /// 期待挙動 : GetメソッドがOkObjectResultを返し、HealthResponseのStatusが"ok"
    /// </summary>
    [Fact]
    public void Get_ReturnsOkResult_WithHealthResponse()
    {
        // Arrange
        var controller = new HealthController();

        // Act
        var result = controller.Get();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var healthResponse = Assert.IsType<HealthResponse>(okResult.Value);

        Assert.Equal("ok", healthResponse.Status);
    }
}