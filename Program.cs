using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

using CsvHelper;

namespace FirstBankOfSuncoast
{
    enum AccountType
    {
        Checking, Savings
    }

    class Program
    {
        static string PromptForString(string prompt)
        {
            Console.Write(prompt);
            var userInput = Console.ReadLine();

            return userInput.ToUpper();
        }

        static int PromptForInteger(string prompt)
        {
            Console.Write(prompt);
            int userInput;
            var isThisGoodInput = Int32.TryParse(Console.ReadLine(), out userInput);

            if (isThisGoodInput)
            {
                return userInput;
            }
            else
            {
                Console.WriteLine("Sorry, that isn't a valid input, I'm using 0 as your answer.");
                return 0;
            }
        }

        static void Main(string[] args)
        {

            var transactions = new List<Transaction>();

            var fileWriter = new StreamWriter("Transactions.csv");
            var csvWriter = new CsvWriter(fileWriter, CultureInfo.InvariantCulture);
            csvWriter.WriteRecords(transactions);



            var keepGoing = true;
            while (keepGoing)
            {

                var userAnswer = PromptForString("Which account do you want? \n(C)hecking \n(S)avings \n(V)iew balance \n(Q)uit ");

                // to (V)iew
                switch (userAnswer)
                {
                    case "Q":
                        keepGoing = false;
                        break;
                    case "C":
                        CheckingMenu();
                        break;

                    case "S":
                        SavingsMenu();
                        break;

                    default:
                        Console.WriteLine("☠️ ☠️ ☠️ ☠️ ☠️ NOPE! ☠️ ☠️ ☠️ ☠️ ☠️");
                        break;
                }

            }

            fileWriter.Close();
        }

        public static void CheckingMenu()
        {
            var checkingAnswer = PromptForString("What would you like to do? (V)iew balance (D)eposit (W)ithdraw \n");
            switch (checkingAnswer)
            {
                case "V":
                    ShowBalance(AccountType.Checking);
                    break;
                case "D":
                    DepositFunds(AccountType.Checking);
                    break;
                case "W":
                    WithdrawFunds(AccountType.Checking);
                    break;
                default:
                    Console.WriteLine($"Wrong answer! Back to the main menu with you. 🥾💥 ");
                    break;
            }
        }

        public static void WithdrawFunds(AccountType accountType)
        {
            switch (accountType)
            {
                case AccountType.Checking:
                    break;
                case AccountType.Savings:
                    break;
            }
        }

        public static void DepositFunds(AccountType accountType)
        {
            switch (accountType)
            {
                case AccountType.Checking:
                    break;
                case AccountType.Savings:
                    break;
            }
        }

        public static void ShowBalance(AccountType accountType)
        {
            switch (accountType)
            {
                case AccountType.Checking:

                    break;
                case AccountType.Savings:
                    break;
            }
        }

        public static void SavingsMenu()
        {
            var savingsAnswer = PromptForString("What would you like to do? (V)iew balance (D)eposit (W)ithdraw \n");
            switch (savingsAnswer)
            {
                case "V":
                    ShowBalance(AccountType.Savings);
                    break;
                case "D":
                    DepositFunds(AccountType.Savings);
                    break;
                case "W":
                    WithdrawFunds(AccountType.Savings);
                    break;
                default:
                    Console.WriteLine($"Wrong answer! Back to the main menu with you. 🥾💥 ");
                    break;
            }
        }
    }
}
