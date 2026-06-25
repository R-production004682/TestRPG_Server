namespace TestRPG.Server.Api.MasterData;

/// <summary>
/// EnemyRecord を EnemyResponse に変換するためのマッパー
/// </summary>
public static class EnemyResponseMapper
{
    public static EnemyResponse ToResponse(EnemyRecord record)
    {
        return new EnemyResponse
        {
            Id = record.Id,
            Name = record.Name,
            Lv = record.Lv,
            MaxHp = record.MaxHp,
            Atk = record.Atk,
            Def = record.Def,
            Agi = record.Agi,
            EvasionRate = record.EvasionRate,
            CriticalRate = record.CriticalRate,
            ExpReward = record.ExpReward,
            GoldReward = record.GoldReward,
            EnemyType = record.EnemyType,
            EscapeType = record.EscapeType
        };
    }
}