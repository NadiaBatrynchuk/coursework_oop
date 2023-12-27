using Games;
using Accounts;

namespace TicTac
{
    public class Printer
    {
        public static void ShowAllGames(List<GameStats> Games)
        {
            Console.WriteLine("--- All Games Stats ---");
            if (Games.Count != 0)
            {
                foreach (var game in Games)
                {
                    Console.WriteLine($"GameID: {game.GameID}");
                    Console.WriteLine($"GameType: {game.GameType}");
                    Console.WriteLine($"Player1: {game.PlayerOneName}");
                    Console.WriteLine($"Player2: {game.PlayerTwoName}");
                    Console.WriteLine($"Result: {game.Result}");
                    Console.WriteLine("-----------------------");
                }
            }
            else
            {
                Console.WriteLine("---      Empty      ---");
                Console.WriteLine("-----------------------");
            }
        }

        public static void ShowAllPlayers(List<BasicAccount> Players)
        {
            Console.WriteLine("--- All Players ---");
            if (Players.Count != 0)
            {
                foreach (var player in Players)
                {
                    Console.WriteLine($"Name: {player.UserName}");
                    Console.WriteLine($"Scores: {player.UserScores}");
                    Console.WriteLine($"AccountType: {player.Type}");
                    Console.WriteLine($"WinCount: {player.WinCount}");
                    Console.WriteLine($"LoseCount: {player.LoseCount}");
                    Console.WriteLine($"DrawCount: {player.DrawCount}");
                    Console.WriteLine("-------------------");
                }
            }
            else
            {
                Console.WriteLine("---    Empty    ---");
                Console.WriteLine("-------------------");
            }
        }

    }
}
