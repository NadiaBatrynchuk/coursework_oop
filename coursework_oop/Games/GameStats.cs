namespace Games;

public class GameStats
{

    public readonly int GameID;
    public readonly string GameType;
    public readonly string PlayerOneName;
    public readonly string PlayerTwoName;
    public readonly string Result;

    public GameStats(int GameID, string GameType, string PlayerOneName, string PlayerTwoName, string Result)
    {
        this.GameID = GameID;
        this.GameType = GameType;
        this.PlayerOneName = PlayerOneName;
        this.PlayerTwoName = PlayerTwoName;
        this.Result = Result;
    }
}