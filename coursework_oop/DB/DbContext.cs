using DB.Entity;

namespace DB
{
    public class DbContext
    {
        public List<AccountEntity> Accounts;
        public List<GameStatsEntity> Games;

        public DbContext()
        {
            Accounts = new();
            Games = new();
        }
    }
}
