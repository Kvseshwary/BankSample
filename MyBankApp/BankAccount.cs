using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace MyBankApp
{
    /// <summary>
    /// First declare the properties
    /// Then constuctors,
    /// Initialize the constructors using this
    /// This is basically form fields in UI 
    /// </summary>
    class BankAccount
    {
        /// <summary>
        /// Properties are used to enforce rules 
        /// </summary>
        public string Number { get; set; }
        public string  Owner { get; set; }

        public List<Transaction> allTransaction = new List<Transaction>();

        //Running balance all time and rules for balance
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransaction)
                {
                    balance += item.Amount;
                }

                return balance;
            }
        }


        private static int accountNumberSeed = 1234567890;

        /// <summary>
        /// We add constructors because we can assign a new value to the variable
        /// var account = new BankAccount("kendra", 10000);

        /// </summary>
        /// <param name="name"></param>
        /// <param name="initialBalance"></param>
        /// 

        //To communicate between classes a bank accouunt will have lots of transactions
        

        public BankAccount(string name,decimal initialBalance,string note)
        {
            this.Owner = name;
            this.Number = accountNumberSeed.ToString();
            makeDeposit(initialBalance, DateTime.Now, note);
            accountNumberSeed++;
        }

        /// <summary>
        /// Methods are called verbs
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="date"></param>
        /// <param name="note"></param>
        public void makeDeposit(decimal amount,DateTime date,string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            
          // Constructor in Transaction class is used to create an object..
          // Assign that entire object to a Public generic list..
            var deposit = new Transaction(amount, date, note);
            allTransaction.Add(deposit);
        }

        public void makeWithdrawal(decimal amount,DateTime date,string note)
        {
            if(amount<=0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal should not be negative");
            }

            if(Balance-amount<=0)
            {
                throw new InvalidOperationException("No sufficient funds for withdrawal");

            }

            var withdrawal = new Transaction(-amount, date, note);
            allTransaction.Add(withdrawal);

        }

        // Transaction History

        public string GetTransactionHistory()
        {
            var str = new StringBuilder();
            //HEADER
            str.Append("Amount\t\tDate\t\tNote\n");
            foreach(var item in allTransaction)
            {
                //ROWS
                str.AppendLine($"{item.Amount}\t\t{item.Date.ToShortDateString()}    \t{item.Notes}");
            }

            return str.ToString();
        }

    }
}
