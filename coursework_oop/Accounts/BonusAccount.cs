namespace Accounts;

class BonusAccount : BasicAccount
{
    private int WinSeria;
    private int Scores
    {
        get { return UserScores; }
        set { UserScores = value < 0? 0 : value; }
    }

    public BonusAccount(string UserName, string UserPassword)
    {
        this.UserName = UserName;
        this.UserPassword = UserPassword;
        this.Type = AccountType.Bonus;
        this.WinSeria = 0;
    }

    public override void WinGame()
    {
        WinSeria++;
        Scores += WinSeria*10;
        WinCount++;
    }
    public override void LoseGame()
    {
        Scores -= WinSeria*5;
        WinSeria = 0;
        LoseCount++;
    }

    public override void DrawGame()
    {
        WinSeria = 0;
        DrawCount++;
    }
}
