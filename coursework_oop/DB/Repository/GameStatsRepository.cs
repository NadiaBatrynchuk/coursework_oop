using DB.Entity;

namespace DB.Repository
{
    public class GameStatsRepository : IGameStatsRepository
    {
        private DbContext Context;

        public GameStatsRepository(DbContext Context)
        {
            this.Context = Context;
        }

        public void Create(GameStatsEntity Game)
        {
            Context.Games.Add(Game);
        }

        public IEnumerable<GameStatsEntity> Read()
        {
            return Context.Games;
        }

        public GameStatsEntity? ReadOne(int GameID)
        {
            return Context.Games.FirstOrDefault(x => x.GameID == GameID);
        }

        public void Delete(int GameID)
        {
            var Game = Context.Games.FirstOrDefault(x => x.GameID == GameID);
            if(Game != null)
                Context.Games.Remove(Game);
        }

    }
}
