using System;

namespace OO14
{
    class Account
    {
        public int Number { get; private set; }
        public string Holder { get; private set; }
        public double Balance { get; protected set; }

        public Account(){}

        public Account(int number, string holder, double balance)
        {
            Number = number;
            Holder = holder;
            Balance = balance;
        }

        public virtual void Withdraw(double amount)
        {
            Balance -= amount + 5;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }
    }

    class BusinessAccount : Account
    {
        public double LoanLimit { get; set; }

        public BusinessAccount(){}

        public BusinessAccount(int number, string holder, double balance, double loanLimit) : base(number, holder, balance)
        {
            LoanLimit = loanLimit;
        }

        public void Loan(double amount)
        {
            if(amount <= LoanLimit)
                Balance += amount;
        }
    }

    class SavingsAccount : Account
    {
        public double InterestRate { get; set; }

        public SavingsAccount(){}

        public SavingsAccount(int number, string holder, double balance, double interestRate) : base(number, holder, balance)
        {
            InterestRate = interestRate;
        }

        public void UpdateBalance()
        {
            Balance += Balance * InterestRate;
        }

        public sealed override void Withdraw(double amount)
        {
            //Balance -= amount;
            base.Withdraw(amount);
            Balance -= 2;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Account account1 = new Account(0101, "Bob", 500);
            Account account2 = new SavingsAccount(2222, "Maria", 500, 0.1);

            account1.Withdraw(10);
            account2.Withdraw(10);

            Console.WriteLine(account1.Balance);
            Console.WriteLine(account2.Balance);
        }
    }
}