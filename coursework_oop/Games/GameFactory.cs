namespace Games;

public class GameFactory
{
    public BasicGame CreateGame(GameType Type)
    {
        switch (Type)
        {
            case GameType.Classic:
                return new ClassicGame();
            case GameType.Fast:
                return new FastGame();
            default: throw new ArgumentException("Unsupported game type");
        }
    }
}