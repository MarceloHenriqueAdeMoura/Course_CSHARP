using System;
using System.Globalization;

namespace OO4
{
    class Calculadora
    {
        public static double Pi = 3.14;
        public static double Circunferencia(double raio)
        {
            return 2.0 * Pi * raio;
        }
        public static double Volume(double raio)
        {
            return 4.0 / 3.0 * Pi * Math.Pow(raio,3);
        }
    }

    class ConversorDeMoeda
    {
        public static double IOF = 0.06;
        public static double Dolar(double cotacao, double valor)
        {
            double imposto = valor * IOF;
            return valor = (valor + imposto) * dolar;            
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            //Calculadora calculadora = new Calculadora();

            Console.Write("Entre com o valor do raio: ");
            double raio = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);           
            
            double circ = Calculadora.Circunferencia(raio);
            double vol = Calculadora.Volume(raio);

            Console.WriteLine("Circunferencia: " + circ.ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine("Volume: " + vol.ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine("Valor de PI: " + Calculadora.Pi.ToString("F2", CultureInfo.InvariantCulture));

            //---------------------------------------------------------------------------------------

            Console.Write("Digite a cotação do dolar: ");
            double dol = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Quantidade de dolares a ser comprado: ");
            double quant = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            double conversor = ConversorDeMoeda.Dolar(dol, quant);

            Console.WriteLine("Valor a ser pago em reais: " + conversor.ToString("F2", CultureInfo.InvariantCulture));
        }        
    }
}