using DB;
using DB.Service;
using TicTac;

class Program
{
    static void Main()
    {
        DbContext context = new();
        AccountService accountService = new(context);
        GameStatsService gameStatsService = new(context);
        try
        {
            Menu menu = new(accountService, gameStatsService);
        }
        catch (Exception exception)
        {
            Console.WriteLine("Error: " + exception.Message);
        }
    }
}