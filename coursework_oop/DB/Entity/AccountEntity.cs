using Accounts;

namespace DB.Entity
{
    public class AccountEntity
    {
        public string UserName = "";
        public string UserPassword = "";
        public AccountType Type;
        public int UserScores = 0;
        public int WinCount = 0;
        public int LoseCount = 0;
        public int DrawCount = 0;
    }
}
