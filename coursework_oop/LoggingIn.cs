using Accounts;
using DB.Service;

namespace TicTac
{
    public class LoggingIn
    {
        public static BasicAccount? SignIn(AccountService accountService, BasicAccount? anotherPlayer)
        {
            string? userName;
            string? password;

            Console.Clear();
            Console.WriteLine("--- Login ---");

            Console.Write("UserName: ");
            userName = Console.ReadLine();
            Console.Write("Password: ");
            password = Console.ReadLine();

            var account = accountService.ReadAccountByUserName(userName);
            if (account != null)
            {
                if(anotherPlayer != null)
                {
                    if(account.UserName == anotherPlayer.UserName)
                    {
                        Console.WriteLine("This user already logged");
                        return null;
                    }
                }

                if(account.UserPassword == password)
                {
                    return account;
                }
                else
                {
                    Console.WriteLine("Wrong password, try again.");
                }
            }
            else
            {
                Console.WriteLine("User not found.");
            }
            return null;
        }

        public static void SignUp(AccountService accountService)
        {
            string? userName;
            string? password;

            Console.Clear();
            Console.WriteLine("--- Registration ---");

            Console.Write("UserName: ");
            userName = Console.ReadLine();
            Console.Write("Password: ");
            password = Console.ReadLine();
            AccountType accountType = AccountType.Standard;

            if(userName != null && userName != "" && password != null && password != "")
            {
                if (accountService.ReadAccountByUserName(userName) == null)
                {
                    var account = new AccountFactory().CreateAccount(accountType, userName, password);
                    accountService.CreateAccount(account);
                }
                else
                {
                    Console.WriteLine("Player already exist.");
                }
            }
            else
            {
                Console.WriteLine("Wrong input data.");
            }
        }
    }
}
