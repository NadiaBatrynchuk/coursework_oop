using Accounts;
using DB.Service;

namespace Games
{
    class ClassicGame : BasicGame
    {
        private char[,] gridMatrix = new char[3, 3]; // матриця, що визначає ґрати або ігрове поле

        public ClassicGame()
        {
            Type = GameType.Classic;
            gameLife = true;
            playerTurn = new Random().Next(2) == 1 ? 'X':'O';
            ClearMatrix();
            cX = 0; cY = 0;
        }

        private void ClearMatrix()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    gridMatrix[i,j] = ' ';
        }

        protected override bool WinChecker(char shape)
        {
            int winCounter = 0;
            for (int i = 0; i < 3; i++)
                if (gridMatrix[cY,i] == shape)
                    winCounter++;
            if (winCounter == 3)
                return true;
            else winCounter = 0;

            for (int i = 0; i < 3; i++)
                if (gridMatrix[i, cX] == shape)
                    winCounter++;
            if (winCounter == 3)
                return true;
            else winCounter = 0;

            for (int i = 0; i < 3; i++)
                if (gridMatrix[i, i] == shape)
                    winCounter++;
            if (winCounter == 3)
                return true;
            else winCounter = 0;

            for (int i = 0; i < 3; i++)
                if (gridMatrix[i, 2-i] == shape)
                    winCounter++;
            if (winCounter == 3)
                return true;

            return false;
        }

        protected override bool DrawChecker()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if(gridMatrix[i,j] == ' ')
                        return false;
            return true;
        }

        public override void MakeChoice()
        {
            var key = Console.ReadKey().Key;
            switch(key)
            {
                case ConsoleKey.Enter:
                    if(gridMatrix[cY, cX] == ' ')
                    {
                        gridMatrix[cY, cX] = playerTurn;
                        choiceMade = true;
                    }
                    break;
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    cY--;
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    cY++;
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    cX--;
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    cX++;
                    break;
            }
        }

        public override void GameLogic(BasicAccount Player1, BasicAccount Player2, GameStatsService Stats, AccountService Accounts)
        {
            if (cX > 2)
                cX = 2;
            else if (cX < 0)
                cX = 0;

            if (cY > 2)
                cY = 2;
            else if (cY < 0)
                cY = 0;

            if (choiceMade)
            {
                if (WinChecker(playerTurn))
                {
                    if (playerTurn == 'X')
                    {
                        Player1.WinGame();
                        Player2.LoseGame();
                        Stats.CreateGame(new GameStats(
                            gameID, 
                            Type.ToString(), 
                            Player1.UserName, 
                            Player2.UserName, 
                            $"{Player1.UserName} WIN"));
                        gameID++;
                    }
                    else
                    {
                        Player1.LoseGame();
                        Player2.WinGame();
                        Stats.CreateGame(new GameStats(
                            gameID, 
                            Type.ToString(), 
                            Player1.UserName, 
                            Player2.UserName, 
                            $"{Player2.UserName} WIN"));
                        gameID++;
                    }
                    Accounts.UpdatePlayer(Player1);
                    Accounts.UpdatePlayer(Player2);
                    gameLife = false;
                }
                else if (DrawChecker())
                {
                    Player1.DrawGame();
                    Player2.DrawGame();
                    Stats.CreateGame(new GameStats(
                        gameID, 
                        Type.ToString(), 
                        Player1.UserName, 
                        Player2.UserName, "DRAW"));
                    Accounts.UpdatePlayer(Player1);
                    Accounts.UpdatePlayer(Player2);
                    gameID++;
                    drawResult = true;
                    gameLife = false;
                }
                else
                {
                    playerTurn = (playerTurn == 'X') ? 'O' : 'X';
                    choiceMade = false;
                }
            }
        }

        public override void PrintGame(BasicAccount Player1, BasicAccount Player2)
        {
            var defaultForegroundColor = Console.ForegroundColor;
            var defaultBackgroundColor = Console.BackgroundColor;

            if(!gameLife)
                Console.Clear();

            ColoredForegroundPrint(Player1.UserName, ConsoleColor.Red, defaultForegroundColor);
            Console.Write(" VS ");
            ColoredForegroundPrint(Player2.UserName, ConsoleColor.Blue, defaultForegroundColor);
            Console.WriteLine();

            Console.WriteLine("#####");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (j == 0) Console.Write('|');

                    if (i == cY && j == cX)
                        Console.BackgroundColor = ConsoleColor.Magenta;

                    if (gridMatrix[i,j] == 'X')
                    {
                        ColoredForegroundPrint("X", ConsoleColor.Red, defaultForegroundColor);
                    }
                    else if (gridMatrix[i, j] == 'O')
                    {
                        ColoredForegroundPrint("O", ConsoleColor.Blue, defaultForegroundColor);
                    }
                    else
                        Console.Write(' ');

                    if (Console.BackgroundColor != defaultBackgroundColor)
                        Console.BackgroundColor = defaultBackgroundColor;

                    if (j == 2) Console.Write('|');
                }
                Console.WriteLine();
            }
            Console.WriteLine("#####");

            if(gameLife)
            {
                if (playerTurn == 'X')
                    ColoredForegroundPrint("X", ConsoleColor.Red, defaultForegroundColor);
                else
                    ColoredForegroundPrint("O", ConsoleColor.Blue, defaultForegroundColor);
                Console.WriteLine(" turn...");
            }
            else
            {
                if (drawResult)
                    Console.WriteLine("DRAW!");
                else
                    Console.WriteLine($"'{playerTurn}' WINNER!");
            }
        }

        private void ColoredForegroundPrint(string Text, ConsoleColor Color, ConsoleColor DefaultColor)
        {
            Console.ForegroundColor = Color;
            Console.Write(Text);
            Console.ForegroundColor = DefaultColor;
        }

    }
}
