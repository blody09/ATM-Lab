using System;
using System.Collections.Generic;

namespace lab10_ATM
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Account> accountList = new List<Account>();
            Account testAccount1 = new Account("user", "password", 1000.00);
            Account testAccount2 = new Account("user1", "password1");
            accountList.Add(testAccount1);
            accountList.Add(testAccount2);


            ATM myATM = new ATM();
            ReturnToMainMenu(accountList);

        }

        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
        public static double GetUserNumber(string message)
        {
            string input = "*";
            double number;
            while (!double.TryParse(input, out number))
            {
                input = GetUserInput(message);
            }

            return number;
        }
        public static bool AskUserToContinue(string message, string yes, string no)
        {
            string input = "";
            while (input != yes && input != no)
            {
                input = GetUserInput(message).ToLower();
            }
            if (input == yes)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static void ExitProgram()
        {
            Environment.Exit(0);
        }

        public static void ReturnToMainMenu(List<Account> accountList)
        {
            ListMainMenu();
            bool tryAgain = true;
            while (tryAgain)
            {
                string mainMenuInput = Console.ReadLine().ToLower();
                tryAgain = false;
                switch (mainMenuInput)
                {
                    case "1":
                    case "register new account":
                        ATM.RegisterAccount(accountList);
                        break;

                    case "2":
                    case "login":
                        ATM.UserLogin(accountList);
                        break;

                    case "3":
                    case "exit":
                        //ExitProgram();
                        break;

                    default:
                        tryAgain = true;
                        Console.WriteLine("Please make a valid selection");
                        break;
                }
            }
        }

        public static void ListMainMenu()
        {
            Console.WriteLine("\t=====================");
            Console.WriteLine("\tWelcome to the ATM");
            Console.WriteLine("\t=====================\n");

            Console.WriteLine("1. Register new account   2. Login   3. Exit");
        }
    }
}
