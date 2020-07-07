using System;

namespace MyBankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("kendra", 10000,"InitialBalance");

            Console.WriteLine($"Account Number {account.Number}  was created for  {account.Owner} with the balance  {account.Balance}");

            account.makeWithdrawal(120, DateTime.Now, "Hammock");
            Console.WriteLine(account.Balance);

            account.makeDeposit(300, DateTime.Now, "Added Money");
            Console.WriteLine(account.Balance);


            /*

            //Testing for negative balance

            try
            {
                var bal = new BankAccount("Invalid", -55, "Invalid Balance");
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exception caught when creating a negative balance");
                Console.WriteLine(e.ToString());
            }

            //Testing for overdraft

            try
            {
                account.makeWithdrawal(75000, DateTime.Now, "Overdraft Done");
                Console.WriteLine(account.Balance);
            }
            catch(InvalidOperationException e)
            {
                Console.WriteLine("Invalid Operation");
                Console.WriteLine(e.ToString());
            }*/

            
            account.makeWithdrawal(300,DateTime.Now, "Xbox Game");
            Console.WriteLine(account.Balance);

            Console.WriteLine($"Account Number {account.Number} Balance {account.Balance}");
            Console.WriteLine(account.GetTransactionHistory());
            Console.ReadLine();
        }
    }
}
