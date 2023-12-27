using DB.Entity;

namespace DB.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private DbContext Context;

        public AccountRepository (DbContext Context)
        {
            this.Context = Context;
        }

        public void Create(AccountEntity Account)
        {
            Context.Accounts.Add(Account);
        }

        public IEnumerable<AccountEntity> Read()
        {
            return Context.Accounts;
        }

        public AccountEntity? ReadOne(string UserName)
        {
            return Context.Accounts.FirstOrDefault(x => x.UserName == UserName);
        }

        public void Update(AccountEntity Account)
        {
            var account = Context.Accounts.FirstOrDefault(x => x.UserName == Account.UserName);
            if (account != null)
            {
                account.UserScores = Account.UserScores;
                account.WinCount = Account.WinCount;
                account.LoseCount = Account.LoseCount;
                account.DrawCount = Account.DrawCount;
            }
        }

        public void Delete(string UserName)
        {
            var account = Context.Accounts.FirstOrDefault(x => x.UserName == UserName);
            if (account != null)
                Context.Accounts.Remove(account);
        }
    }
}
