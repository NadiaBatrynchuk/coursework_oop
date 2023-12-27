using Accounts;
using DB.Entity;
using DB.Repository;

namespace DB.Service
{
    public class AccountService : IAccountService
    {
        private IAccountRepository accountRepository;

        public AccountService(DbContext Context)
        {
            accountRepository = new AccountRepository(Context);
        }

        public void CreateAccount(BasicAccount Account)
        {
            AccountEntity player = new()
            {
                UserName = Account.UserName,
                UserPassword = Account.UserPassword,
                Type = Account.Type,
                UserScores = Account.UserScores,
                WinCount = Account.WinCount,
                LoseCount = Account.LoseCount,
                DrawCount = Account.DrawCount
            };
            accountRepository.Create(player);
        }

        public void DeleteAccountByUserName(string UserName)
        {
            accountRepository.Delete(UserName);
        }

        public void UpdatePlayer(BasicAccount Account)
        {
            AccountEntity account = new()
            {
                UserName = Account.UserName,
                UserPassword = Account.UserPassword,
                Type = Account.Type,
                UserScores = Account.UserScores,
                WinCount = Account.WinCount,
                LoseCount = Account.LoseCount,
                DrawCount = Account.DrawCount
            };
            accountRepository.Update(account);
        }

        public List<BasicAccount> ReadAccounts()
        {
            return accountRepository.Read().Select(account => Convert(account)).ToList();
        }

        public BasicAccount? ReadAccountByUserName(string? UserName)
        {
            var accountEntity = accountRepository.Read().FirstOrDefault(account => account.UserName == UserName);
            if (accountEntity != null)
                return Convert(accountEntity);
            return null;
        }

        private BasicAccount Convert(AccountEntity Account)
        {
            var factory = new AccountFactory();
            var account = factory.CreateAccount(Account.Type, Account.UserName, Account.UserPassword);
            account.UserScores = Account.UserScores;
            account.WinCount = Account.WinCount;
            account.LoseCount = Account.LoseCount;
            account.DrawCount = Account.DrawCount;
            return account;
        }
    }
}
