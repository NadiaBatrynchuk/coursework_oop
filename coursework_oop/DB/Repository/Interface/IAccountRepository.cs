using DB.Entity;

namespace DB.Repository
{
    public interface IAccountRepository
    {
        public void Create(AccountEntity Account);
        public IEnumerable<AccountEntity> Read();
        public AccountEntity? ReadOne(string UserName);
        public void Update(AccountEntity Account);
        public void Delete(string UserName);
    }
}
