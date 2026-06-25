using MySqlConnector;

namespace TestRPG.Server.Api.MasterData;

public sealed class GetEnemiesQueryHandler : IGetEnemiesQueryHandler
{
    private readonly string connectionString;

    public GetEnemiesQueryHandler(IConfiguration configuration)
    {
        connectionString = configuration.GetConnectionString("GameDB")
            ?? throw new InvalidOperationException("GameDBの接続文字列が設定されていません。");
    }

    /// <summary>
    /// 非同期で敵データを取得する
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<IReadOnlyList<EnemyResponse>> HandleAsync(CancellationToken cancellationToken) 
    {
        const string sql = """
            select
                id, name, lv, max_hp, atk, def, agi, evasion_rate, critical_rate, exp_reward, gold_reward, enemy_type, escape_type
            from
                mst_enemy
            order by id;
            """;

        var enemies = new List<EnemyResponse>();

        await using var connection = new MySqlConnection(connectionString);
        await connection.OpenAsync(cancellationToken);

        await using var command = new MySqlCommand(sql, connection);
        await using var reader = await command.ExecuteReaderAsync(cancellationToken);

        while (await reader.ReadAsync(cancellationToken))
        {
            var record = new EnemyRecord
            {
                Id = reader.GetInt32("id"),
                Name = reader.GetString("name"),
                Lv = reader.GetInt32("lv"),
                MaxHp = reader.GetInt32("max_hp"),
                Atk = reader.GetInt32("atk"),
                Def = reader.GetInt32("def"),
                Agi = reader.GetInt32("agi"),
                EvasionRate = reader.GetInt32("evasion_rate"),
                CriticalRate = reader.GetInt32("critical_rate"),
                ExpReward = reader.GetInt32("exp_reward"),
                GoldReward = reader.GetInt32("gold_reward"),
                EnemyType = (EnemyType)reader.GetInt32("enemy_type"),
                EscapeType = (EscapeType)reader.GetInt32("escape_type")
            };

            enemies.Add(EnemyResponseMapper.ToResponse(record));
        }

        return enemies;
    }
}