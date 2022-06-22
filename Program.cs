using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace FirstBankOfSuncoast
{
    enum AccountType
    {
        Checking, Savings
    }
    enum TransactionType
    {
        Debit, Credit
    }
    class Program
    {
        static string PromptForString(string prompt)
        {
            Console.Write(prompt);
            Console.Write("\n> ");
            return Console.ReadLine();

        }
        static string PromptForMenuString(string prompt)
        {
            Console.Write(prompt);
            Console.Write("\n> ");
            var userInput = Console.ReadLine();

            return userInput.ToUpper();
        }


        static int PromptForInteger(string prompt)
        {
            Console.Write(prompt);
            Console.Write("\n> ");
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
        public static List<Transaction> Transactions = new List<Transaction>();

        static void Main(string[] args)
        {
            Introduction();

            var fileReader = new StreamReader("Transactions.csv");
            var csvReader = new CsvReader(fileReader, CultureInfo.InvariantCulture);
            Transactions = csvReader.GetRecords<Transaction>().ToList();
            fileReader.Close();

            var keepGoing = true;
            while (keepGoing)
            {

                var userAnswer = PromptForMenuString("Which account do you want? \n(C)hecking \n(S)avings \n(V)iew balance \n(Q)uit\n> ");

                // to (V)iew
                switch (userAnswer)
                {
                    case "Q":
                        keepGoing = false;
                        var fileWriter = new StreamWriter("Transactions.csv");
                        var csvWriter = new CsvWriter(fileWriter, CultureInfo.InvariantCulture);
                        csvWriter.WriteRecords(Transactions);
                        fileWriter.Close();
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

        }

        private static void Introduction()
        {
            Console.WriteLine("\n\nWelcome to First Suncoast Bank. \n\n");
        }

        public static void CheckingMenu()
        {
            var checkingAnswer = PromptForMenuString("What would you like to do? (V)iew balance (D)eposit (W)ithdraw \n");
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
                    DepositPrompts();
                    break;
                case AccountType.Savings:
                    DepositPrompts();
                    break;
            }
        }

        private static void DepositPrompts()
        {
            var newTransaction = new Transaction();
            var depositAmount = PromptForInteger("How much would you like to deposit? ");
            newTransaction.Memo = PromptForString("Please enter a memo for this transaction, and Than you");
            newTransaction.Date = DateTime.Now;
            newTransaction.Amount = depositAmount;
            newTransaction.Type = TransactionType.Credit;
            Transactions.Add(newTransaction);
        }

        public static void ShowBalance(AccountType accountType)
        {
            switch (accountType)
            {
                case AccountType.Checking:
                    foreach (var transaction in Transactions.Where(transaction => transaction.Account == AccountType.Checking))
                    {
                        Console.WriteLine($"{transaction.Date} | {transaction.Memo}\t\t ${transaction.Amount} ");
                    }
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
