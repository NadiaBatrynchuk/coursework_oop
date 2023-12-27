using Games;
using Accounts;
using DB.Service;

namespace TicTac
{
    public class Menu
    {
        private BasicAccount? player1;
        private BasicAccount? player2;
        private BasicGame? game;
        private GameType gameType;

        private AccountService accountService;
        private GameStatsService gameStatsService;

        private bool loopLife;
        private Pages currentPage;

        public Menu(AccountService AccountService, GameStatsService GameStatsService)
        {
            accountService = AccountService;
            gameStatsService = GameStatsService;
            loopLife = true;
            currentPage = Pages.MainMenu;
            while(loopLife)
                NextPage();
        }

        private enum Pages
        {
            MainMenu,
            Authorization,
            PlayGame,
            GameStory,
            PlayersList,
            Player1Authorization,
            Player2Authorization
        }

        private void NextPage()
        {
            switch (currentPage)
            {
                case Pages.MainMenu:
                    MainMenu();
                    break;
                case Pages.Authorization:
                    Authorization();
                    break;
                case Pages.PlayGame:
                    PlayGame();
                    break;
                case Pages.GameStory:
                    GameStory();
                    break;
                case Pages.PlayersList:
                    PlayersList();
                    break;
                case Pages.Player1Authorization:
                    Player1Authorization();
                    break;
                case Pages.Player2Authorization:
                    Player2Authorization();
                    break;
            }   
        }

        private void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("--- Main Menu ---");
            if(player1 != null)
                Console.WriteLine($"{player1.UserName} [X]");
            if (player2 != null)
                Console.WriteLine($"{player2.UserName} [O]");
            Console.WriteLine("1. Authorization");
            Console.WriteLine("2. Play Game");
            Console.WriteLine("3. Game Story");
            Console.WriteLine("4. Players List");
            Console.WriteLine("5. Exit");

            while(true)
            {
                Console.Write("input>> ");
                var choice = Console.ReadLine();
                switch(choice)
                {
                    case "1":
                        currentPage = Pages.Authorization;
                        break;
                    case "2":
                        currentPage = Pages.PlayGame;
                        break;
                    case "3":
                        currentPage = Pages.GameStory;
                        break;
                    case "4":
                        currentPage = Pages.PlayersList;
                        break;
                    case "5":
                        loopLife = false;
                        break;
                    default:
                        choice = null;
                        break;
                }
                if (choice != null)
                    break;
            }
        }

        private void Authorization()
        {
            Console.Clear();
            Console.WriteLine("--- Authorization ---");
            Console.WriteLine("1. player1 [X]");
            Console.WriteLine("2. player2 [O]");
            Console.WriteLine("3. Back");

            while (true)
            {
                Console.Write("input>> ");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        currentPage = Pages.Player1Authorization;
                        break;
                    case "2":
                        currentPage = Pages.Player2Authorization;
                        break;
                    case "3":
                        currentPage = Pages.MainMenu;
                        break;
                    default:
                        choice = null;
                        break;
                }
                if (choice != null)
                    break;
            }
        }

        private void PlayGame()
        {
            Console.Clear();
            Console.WriteLine("--- Play Game ---");
            Console.WriteLine("1. Classic");
            Console.WriteLine("2. Fast");
            Console.WriteLine("3. Back");

            while (true)
            {
                Console.Write("input>> ");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        gameType = GameType.Classic;
                        break;
                    case "2":
                        gameType = GameType.Fast;
                        break;
                    case "3":
                        currentPage = Pages.MainMenu;
                        return;
                    default:
                        choice = null;
                        break;
                }
                if (choice != null)
                    break;
            }
            if (player1 != null && player2 != null)
            {
                game = new GameFactory().CreateGame(gameType);
                Console.Clear();
                game.PlayGame(player1, player2, gameStatsService, accountService);
            }
            else
            {
                Console.WriteLine("Player(s) doesn't logged\n");
            }
            currentPage = Pages.MainMenu;

            Console.WriteLine("Press any button to continue...");
            Console.ReadKey();
        }

        private void GameStory()
        {
            Console.Clear();
            var allGames = gameStatsService.ReadGames();
            Printer.ShowAllGames(allGames);
            currentPage = Pages.MainMenu;
            Console.WriteLine("Press any button to continue...");
            Console.ReadKey();
        }

        private void PlayersList()
        {
            Console.Clear();
            var allPlayers = accountService.ReadAccounts();
            Printer.ShowAllPlayers(allPlayers);
            currentPage = Pages.MainMenu;
            Console.WriteLine("Press any button to continue...");
            Console.ReadKey();
        }

        private void Player1Authorization()
        {
            Console.Clear();
            Console.WriteLine("--- player1 ---");
            Console.WriteLine("1. SignIn");
            Console.WriteLine("2. SignUp");
            Console.WriteLine("3. Back");

            while (true)
            {
                Console.Write("input>> ");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        var playerTmp = LoggingIn.SignIn(accountService, player2);
                        if (playerTmp != null)
                            player1 = playerTmp;
                        break;
                    case "2":
                        LoggingIn.SignUp(accountService);
                        break;
                    case "3":
                        currentPage = Pages.Authorization;
                        return;
                    default:
                        choice = null;
                        break;
                }
                if (choice != null)
                    break;
            }
            currentPage = Pages.MainMenu;

            Console.WriteLine("Press any button to continue...");
            Console.ReadKey();
        }

        private void Player2Authorization()
        {
            Console.Clear();
            Console.WriteLine("--- player2 ---");
            Console.WriteLine("1. SignIn");
            Console.WriteLine("2. SignUp");
            Console.WriteLine("3. Back");

            while (true)
            {
                Console.Write("input>> ");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        var playerTmp = LoggingIn.SignIn(accountService, player1);
                        if (playerTmp != null)
                            player2 = playerTmp;
                        break;
                    case "2":
                        LoggingIn.SignUp(accountService);
                        break;
                    case "3":
                        currentPage = Pages.Authorization;
                        return;
                    default:
                        choice = null;
                        break;
                }
                if (choice != null)
                    break;
            }
            currentPage = Pages.MainMenu;

            Console.WriteLine("Press any button to continue...");
            Console.ReadKey();
        }
    }
}
