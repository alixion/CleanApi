using System;
using System.Reflection;
using DbUp;

namespace CleanApi.DbMigrator
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No connection string supplied");
                Console.ResetColor();
                return 1;
            }


            var connectionString = args[0];
            var dropIfExists = args.Length > 0 || args[1] == "drop-if-exists";

            return RunDbUpdate(connectionString, dropIfExists);
        }
        
        private static int RunDbUpdate(string connectionString, bool dropIfExists)
        {
            if (dropIfExists)
            {
                EnsureDatabase.For.PostgresqlDatabase(connectionString);
            }
            var upgrader = DeployChanges.To
                .PostgresqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                .LogToConsole()
                .Build();

            var upgradeResult = upgrader.PerformUpgrade();
            if (!upgradeResult.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(upgradeResult.Error);
                Console.ResetColor();
                return -1;
            }
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success!");
            Console.ResetColor();
            return 0;
        }
    }
}