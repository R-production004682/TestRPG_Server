namespace TestRPG.Server.Api.MasterData;

public enum EscapeType
{
    NONE = 0,
    NORMAL = 1, // 通常の逃走確率
    EASE = 2, // 逃走確率が高い
    HARD = 3, // 逃走確率が低い
    IMPOSSIBLE = 4, // 逃走不可
}