using DB.Entity;

namespace DB.Repository
{
    public interface IGameStatsRepository
    {
        public void Create(GameStatsEntity Game);
        public IEnumerable<GameStatsEntity> Read();
        public GameStatsEntity? ReadOne(int GameID);
        public void Delete(int GameID);
    }
}
