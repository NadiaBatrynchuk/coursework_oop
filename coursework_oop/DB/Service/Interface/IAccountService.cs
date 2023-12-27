using Accounts;

namespace DB.Service
{
    public interface IAccountService
    {
        public void CreateAccount(BasicAccount Account);
        public void DeleteAccountByUserName(string UserName);
        public void UpdatePlayer(BasicAccount Account);
        public List<BasicAccount>? ReadAccounts(); //отримуємо всі акаунти що я в базі даних
        public BasicAccount? ReadAccountByUserName(string? UserName); //отримати аканут за ім'ям користувача
    }
}
