using Accounts;
using DB.Service;

namespace Games
{
    public abstract class BasicGame
    {
        protected bool gameLife = false; 
        protected bool drawResult = false;
        protected bool choiceMade = false; 
        protected char playerTurn = 'X'; 
        protected int cX = 0, cY = 0; // змінні, що визначають положення курсора
        public GameType Type;

        protected static int gameID = 0;

        protected abstract bool WinChecker(char shape);
        protected abstract bool DrawChecker();
        public abstract void MakeChoice();
        public abstract void GameLogic(BasicAccount Player1, BasicAccount Player2, GameStatsService Stats, AccountService Accounts);
        public abstract void PrintGame(BasicAccount Player1, BasicAccount Player2);

        public void PlayGame(BasicAccount Player1, BasicAccount Player2, GameStatsService Stats, AccountService Accounts)
        {
            /*Console.WriteLine("Controls: ");
            Console.WriteLine("WASD    - Move");
            Console.WriteLine("Arrows  - Move");
            Console.WriteLine("Enter   - Make choice\n");*/

            Console.CursorVisible = false;
            while (gameLife)
            {
                PrintGame(Player1, Player2);
                MakeChoice();
                GameLogic(Player1, Player2, Stats, Accounts);
                Console.SetCursorPosition(0, 0);
            }
            PrintGame(Player1, Player2);
            Console.CursorVisible = true;
        }
    }

    public enum GameType
    {
        Classic,
        Fast
    }
}

