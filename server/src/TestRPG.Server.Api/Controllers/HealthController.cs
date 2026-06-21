using Microsoft.AspNetCore.Mvc;

namespace TestRPG.Server.Api.Controllers;

[ApiController]
[Route("api/health")]
public sealed class HealthController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType<HealthResponse>(StatusCodes.Status200OK)]
    public ActionResult<HealthResponse> Get()
    {
        return Ok(new HealthResponse("ok"));
    }
}

public sealed record HealthResponse(string Status);


/*
  [ApiController] : API向けControllerとして動作させる
  [Route("api/health")] : APIのURLを /api/health にする
  [HttpGet] : HTTP GETリクエストを受け付ける
  [ProducesResponseType] : Swaggerへレスポンス型とステータスコードを伝える

   HealthResponse を定義することで、レスポンス形式が明確になり、SwaggerにもJSON構造が表示される
 */