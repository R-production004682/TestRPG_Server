namespace TestRPG.Server.Api.MasterData;

/// <summary>
/// DB 取得用のEnemyRecord の作成
/// </summary>
public sealed class EnemyRecord
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public int Lv { get; init; }
    public int MaxHp { get; init; }
    public int Atk { get; init; }
    public int Def { get; init; }
    public int Agi { get; init; }
    public int EvasionRate { get; init; }
    public int CriticalRate { get; init; }
    public int ExpReward { get; init; }
    public int GoldReward { get; init; }
    public EnemyType EnemyType { get; init; }
    public EscapeType EscapeType { get; init; }
}