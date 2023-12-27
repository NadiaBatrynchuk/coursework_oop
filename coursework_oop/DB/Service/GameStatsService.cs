using Games;
using DB.Entity;
using DB.Repository;

namespace DB.Service
{
    public class GameStatsService : IGameStatsService
    {
        private IGameStatsRepository gameStatsRepository;

        public GameStatsService(DbContext Context)
        {
            gameStatsRepository = new GameStatsRepository(Context);
        }

        public void CreateGame(GameStats GameStats)
        {
            GameStatsEntity gameStatsEntity = new()
            {
                GameID = GameStats.GameID,
                GameType = GameStats.GameType,
                PlayerOneName = GameStats.PlayerOneName,
                PlayerTwoName = GameStats.PlayerTwoName,
                Result = GameStats.Result
            };
            gameStatsRepository.Create(gameStatsEntity);
        }

        public List<GameStats> ReadGames()
        {
            return gameStatsRepository.Read().Select(game => Convert(game)).ToList();
        }

        public List<GameStats>? ReadGamesByPlayerName(string UserName)
        {
            var gameStatsEntities = gameStatsRepository.Read().Where(game => game.PlayerOneName == UserName || game.PlayerTwoName == UserName).ToList();
            if(gameStatsEntities != null)
                return gameStatsEntities.Select(game => Convert(game)).ToList();
            return null;
        }

        public GameStats Convert(GameStatsEntity GameStats)
        {
            return new GameStats(GameStats.GameID, GameStats.GameType, GameStats.PlayerOneName, GameStats.PlayerTwoName, GameStats.Result);
        }
    }
}