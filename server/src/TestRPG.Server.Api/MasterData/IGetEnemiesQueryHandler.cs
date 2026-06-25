namespace TestRPG.Server.Api.MasterData;

public interface IGetEnemiesQueryHandler
{
    Task<IReadOnlyList<EnemyResponse>> HandleAsync(CancellationToken cancellationToken = default);
}