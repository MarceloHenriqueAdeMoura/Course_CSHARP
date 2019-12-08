using System;
using System.Collections.Generic;
using System.Globalization;

namespace OO17
{
    abstract class Pessoa
    {
        public string Name { get; set; }
        public double AnualIncome { get; set; }

        public Pessoa(){}

        public Pessoa(string name, double anualIncome){
            Name = name;
            AnualIncome = anualIncome;
        }

 

        public override string ToString(){
            return Name + ": $" + Imcome().ToString("F2", CultureInfo.InvariantCulture); 
        }

    }

    class PessoaFisica : Pessoa
    {
        public double GastosSaude { get; set; }

        public PessoaFisica(){}

        public PessoaFisica(string name, double anualIncome, double gastosSaude) : base(name, anualIncome){
            GastosSaude = gastosSaude;
        }

        public override double Imcome(){
            double value;
            if(AnualIncome < 20000){
                value = AnualIncome * 0.15;
            }else{
                value = AnualIncome * 0.25;
            }

            return value - (GastosSaude * 0.50);
        }
    }

    class PessoaJuridica : Pessoa
    {
        public int NumberOfemployees { get; set; }

        public PessoaJuridica(){}

        public PessoaJuridica(string name, double anualIncome, int numberOfemployees) : base(name, anualIncome){
            NumberOfemployees = numberOfemployees;
        }

        public override double Imcome(){
            double value;
            if(NumberOfemployees > 10){
                value = AnualIncome * 0.14;
            }else{
                value = AnualIncome * 0.16;
            }
            return value;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Pessoa> pessoas = new List<Pessoa>();

            Console.Write("Enter the number of tax payers: ");
            int n = int.Parse(Console.ReadLine());

            for(int i=0; i<n; i++){
                Console.WriteLine("Tax payer #" + (i+1) + " data:");
                Console.Write("Individual or Company (i/c)? ");
                char op = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Anual income: ");
                double anualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                switch (op)
                {
                    case 'i':
                        Console.Write("Health expenditures: ");
                        double gastosSaude = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                        pessoas.Add(new PessoaFisica(name, anualIncome, gastosSaude));
                        break;
                    case 'c':
                        Console.Write("Number of employees: ");
                        int employeeNumber = int.Parse(Console.ReadLine());
                        pessoas.Add(new PessoaJuridica(name, anualIncome, employeeNumber));
                        break;
                    default:
                        Console.WriteLine("Opção Invalida!");
                        break;
                }
            }

            Console.WriteLine("\nTAXES PAID: ");
            double soma = 0;
            foreach(Pessoa obj in pessoas){
                Console.WriteLine(obj.ToString());
                soma = soma + obj.Imcome();
            }           
            Console.WriteLine("\nTOTAL TAXES: " + soma.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}