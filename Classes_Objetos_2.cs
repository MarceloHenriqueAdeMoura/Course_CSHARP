using System;
using System.Globalization;
namespace OO
{
    class Triangulo{
        public double A { get; set;}
        public double B { get; set;}
        public double C { get; set;}

        public Triangulo(){

        }

        public Triangulo(double A, double B, double C){
            this.A = A;
            this.B = B;
            this.C = C;
        }

        public double Area()
        {
            double p = (A + B + C) / 2.0;
            double raiz = Math.Sqrt(p*(p-A)*(p-B)*(p-C));
            return raiz;
        }
    }

    class Pessoa
    {
        public string Name { get; set; }
        public int Idade {get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Triangulo x,y;
            double p, areaX;
            x = new Triangulo();
            y = new Triangulo();

            Console.WriteLine("Entre com as medidas do triangulo X:");
            x.A = double.Parse(Console.ReadLine());
            x.B = double.Parse(Console.ReadLine());
            x.C = double.Parse(Console.ReadLine());

            areaX = x.Area();           

            Console.WriteLine("Area do triangulo X: " + areaX.ToString("F4", CultureInfo.InvariantCulture));

            /*--------------------------------------------------------------------------------------- */

            Pessoa pessoa1, pessoa2;
            pessoa1 = new Pessoa();
            pessoa2 = new Pessoa();

            Console.WriteLine("Dados da primeira pessoa:");

            Console.Write("Nome: ");
            pessoa1.Name = Console.ReadLine();
            Console.Write("Idade: ");
            pessoa1.Idade = int.Parse(Console.ReadLine());

            Console.WriteLine("Dados da segunda pessoa:");
            Console.Write("Nome: ");
            pessoa2.Name = Console.ReadLine();
            Console.Write("Idade: ");
            pessoa2.Idade = int.Parse(Console.ReadLine());

            if(pessoa1.Idade > pessoa2.Idade){
                Console.WriteLine("Pessoa mais velha: " + pessoa1.Name);
            }else{
                Console.WriteLine("Pessoa mais velha: " + pessoa2.Name);
            }
        }
    }
}