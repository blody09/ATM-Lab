using System;
using System.Collections.Generic;
using System.Text;

namespace lab10_ATM
{
    class ATM
    {
        //fields
        private List<Account> userAccounts;

        //properties
        public List<Account> UserAccounts { get; set; }

        //constructors
        public ATM()
        {

        }

        public ATM(List<Account> accounts)
        {

        }

       
        public static void RegisterAccount(List<Account> listOfAccounts)
        {
            var newAccount = new Account();
         
            newAccount.Name = GetUserInput("Please enter the new user's name: ");
            newAccount.Password = GetUserInput("Please enter a new password: ");

            listOfAccounts.Add(newAccount);

            GetUserInput("\nAccount created. Press enter to return to main menu.");

            Program.ReturnToMainMenu(listOfAccounts);
        }

        //#2 - Login. Takes username and password.
       
        public static void UserLogin(List<Account> accountList)
        {
            string maybeUsername = GetUserInput("Enter Username: ");
            string maybePassword = GetUserInput("Enter Password: ");

            for (int i = 0; i < accountList.Count; i++)
            {
                if (maybeUsername == accountList[i].Name && maybePassword == accountList[i].Password)
                {
                    //good stuff. Go to Login page
                    //like... DisplayLoginPage()
                    DisplayLoginPage(accountList[i]);
                    break;
                }
            }
            Program.ReturnToMainMenu(accountList);

            
        }

        
        //#3. Logout - Set the current account to null
        public static void UserLogout(Account currentAccount)
        {
            //do stuff
            currentAccount = null;
        }

        public static void DisplayLoginPage(Account loggedInAccount)
        {
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Logout");



            bool tryAgain = true;
            while (tryAgain)
            {
                string mainMenuInput = Console.ReadLine().ToLower();
                tryAgain = false;
                switch (mainMenuInput)
                {
                    case "1":
                    case "check balance":
                        Console.WriteLine($"Current Balance: ${CheckAccountBalance(loggedInAccount)}");
                        break;

                    case "2":
                    case "deposit":
                        DepositToAccount(loggedInAccount);
                        break;

                    case "3":
                    case "withdraw":
                        WithdrawFromAccount(loggedInAccount);
                        break;

                    case "4":
                    case "Logout":
                        UserLogout(loggedInAccount);
                        Console.WriteLine("Goodbye!");
                        Environment.Exit(0);
                        break;

                    default:
                        tryAgain = true;
                        Console.WriteLine("Please make a valid selection");
                        break;
                }
            }
        }

        //#4. CheckBalance - Prints the current Account info
        public static double CheckAccountBalance(Account currentAccount)
        {
            return currentAccount.Balance;
        }

        //#5. Deposit - Takes a double and adds it to the current AccountBalance
        public static double DepositToAccount(Account currentAccount)
        {
            //get input
            double newBalance = currentAccount.Balance + GetUserNumber("How much are you depositing today?");
            Console.WriteLine($"New Balance: {newBalance}");
            return newBalance;

        }

        //#6. Withdraw - Takes a double and subtracts from AccountBalance
       
        public static double WithdrawFromAccount(Account currentAccount)
        {
            double balance = currentAccount.Balance; //redundant
            bool tryAgain = true;
            while (tryAgain)
            {
                double withdrawAmt = GetUserNumber("How much are you withdrawing today? ");
                if (balance > withdrawAmt)
                {
                    balance -= withdrawAmt;
                    Console.WriteLine($"New Balance: {balance}"); //could send to method
                    tryAgain = false;
                }
                else
                {
                    Console.WriteLine("Balance too low, or something. Try again.");
                }
            }
            return balance;
        }


        public static string GetUserInput(string message)
        {
            Console.Write(message);
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



    }
}
