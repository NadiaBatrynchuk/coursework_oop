namespace Accounts;

public abstract class BasicAccount
{
    public string UserName = "";
    public string UserPassword = "";
    public int UserScores = 0;
    public int WinCount = 0;
    public int LoseCount = 0;
    public int DrawCount = 0;
    public AccountType Type;

    public abstract void WinGame();
    public abstract void LoseGame();
    public abstract void DrawGame();
}

public enum AccountType
{
    Standard,
    Bonus
}