using System;
using System.Globalization;

namespace OO6
{
    class Account
    {
        public int Conta { get; private set; }
        public string Titular { get; set; }
        public double Saldo { get; private set; }

        public Account()
        {
            Saldo = 0;
        }
        public Account(int conta, string titular) : this()
        {
            Conta = conta;
            Titular = titular;
        }
        public Account(int conta, string titular, double saldo) : this(conta, titular)
        {
            Saldo = saldo;
        }


        public void Depositar(double valor)
        {
            Saldo += valor;
        }

        public void Sacar(double valor)
        {
            Saldo -= valor + 5;
        }

        public override string ToString()
        {
            return "Conta: " + Conta + ", Titular: " + Titular + ", Saldo: $" + Saldo.ToString("F2", CultureInfo.InvariantCulture);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Account account;

            Console.Write("Entre com o numero da conta: ");
            int numConta = int.Parse(Console.ReadLine());
            Console.Write("Entre com o titular da conta: ");
            string nomConta = Console.ReadLine();

            Console.WriteLine("Havera deposito inicial? [S/N]");
            char op = char.Parse(Console.ReadLine());

            if (op == 'S')
            {
                Console.Write("Entre com o valor de deposito inicial: ");
                double depIni = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                account = new Account(numConta, nomConta, depIni);
            }
            else
            {
                account = new Account(numConta, nomConta);
            }


            Console.WriteLine("Dados da conta: " + account);

            Console.Write("Entre com um valor para deposito: ");
            double valDep = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            account.Depositar(valDep);

            Console.WriteLine("Dados da conta atualizados: " + account);

            Console.Write("Entre com um valor para saque: ");
            double valSaq = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            account.Sacar(valSaq);

            Console.WriteLine("Dados da conta atualizados: " + account);


        }
    }
}