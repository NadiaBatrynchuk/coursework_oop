namespace Accounts;

class StandardAccount : BasicAccount
{
    private int Scores
    {
        get { return UserScores; }
        set { UserScores = value < 0? 0 : value; }
    }

    public StandardAccount (string UserName, string UserPassword)
    {
        this.UserName = UserName;
        this.UserPassword = UserPassword;
        this.Type = AccountType.Standard;
    }

    public override void WinGame()
    {
        Scores += 10;
        WinCount++;
    }
    public override void LoseGame()
    {
        Scores -= 10;
        LoseCount++;
    }

    public override void DrawGame()
    {
        DrawCount++;
    }
}
