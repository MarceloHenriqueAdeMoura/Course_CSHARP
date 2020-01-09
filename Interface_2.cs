using System;
using System.Globalization;
using System.Collections.Generic;

namespace Interface_2
{
    class Contract
    {
        public int Number  {get; set; }
        public DateTime Date { get; set; }
        public double TotalValue { get; set; }
        public List<Installment> Installments { get; set; }

        public Contract()
        {            
        }

        public Contract(int number, DateTime date, double totalValue)
        {
            Number = number;
            Date = date;
            TotalValue = totalValue;  
            Installments = new List<Installment>();          
        }

        public void AddInstallment(Installment installment)
        {
            Installments.Add(installment);
        }
    }

    class Installment
    {
        public DateTime DueDate { get; set; }
        public double Amount { get; set; }

        public Installment()
        {           
        }

        public Installment(DateTime dueDate, double amount)
        {       
            DueDate = dueDate;
            Amount = amount;     
        }

        public override string ToString()
        {
            return DueDate.ToString("dd/MM/yyyy") + " - " + Amount.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
    interface IOnlinePaymentService
    {
        double PaymentFee(double amount);
        double Interest(double amount, int months);
    }

    class PaypalService : IOnlinePaymentService 
    {
        private const double FeePercentage = 0.02;
        private const double MonthlyInterest = 0.01;

        public double Interest(double amount, int months) 
        {
            return amount * MonthlyInterest * months;
        }

        public double PaymentFee(double amount) 
        {
            return amount * FeePercentage;
        }
    }

    class ContractService 
    {
        private IOnlinePaymentService _onlinePaymentService;

        public ContractService(IOnlinePaymentService onlinePaymentService) 
        {
            _onlinePaymentService = onlinePaymentService;
        }

        public void ProcessContract(Contract contract, int months) 
        {
            double basicQuota = contract.TotalValue / months;
            for (int i = 1; i <= months; i++) 
            {
                DateTime date = contract.Date.AddMonths(i);
                double updatedQuota = basicQuota + _onlinePaymentService.Interest(basicQuota, i);
                double fullQuota =  updatedQuota + _onlinePaymentService.PaymentFee(updatedQuota);
                contract.AddInstallment(new Installment(date, fullQuota));
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter contract data");
            Console.Write("Number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Date (dd/MM/yyyy): ");
            DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Console.Write("Contract value: ");
            double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter number of installments: ");
            int months = int.Parse(Console.ReadLine());

            Contract contract = new Contract(number, date, value);

            ContractService contractService = new ContractService(new PaypalService());
            contractService.ProcessContract(contract, months);

            Console.WriteLine("Installments:");
            foreach (Installment installment in contract.Installments) {
                Console.WriteLine(installment);
            }
        }
    }
}