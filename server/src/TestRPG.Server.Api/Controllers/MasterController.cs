using Microsoft.AspNetCore.Mvc;
using TestRPG.Server.Api.MasterData;

namespace TestRPG.Server.Api.Controllers;

/// <summary>
/// api/master のルートに対するコントローラー
/// </summary>
[ApiController]
[Route("api/master")]
public sealed class MasterController : ControllerBase
{
    public readonly IGetEnemiesQueryHandler getEnemiesQueryHandler;

    public MasterController(IGetEnemiesQueryHandler getEnemiesQueryHandler)
    {
        this.getEnemiesQueryHandler = getEnemiesQueryHandler;
    }

    /// <summary>
    /// api/master/enemies に GET リクエストを投げる。
    /// 敵データの一覧を取得
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("enemies")]
    public async Task<ActionResult<IReadOnlyList<EnemyResponse>>> GetEnemies(CancellationToken cancellationToken)
    {
        var enemies = await getEnemiesQueryHandler.HandleAsync(cancellationToken);
        return Ok(enemies);
    }
}