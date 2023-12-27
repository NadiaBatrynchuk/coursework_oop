using Games;

namespace DB.Service
{
    public interface IGameStatsService
    {
        public void CreateGame(GameStats GameStats);
        public List<GameStats>? ReadGames();
        public List<GameStats>? ReadGamesByPlayerName(string UserName);
    }
}