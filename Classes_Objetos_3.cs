using System;

namespace OO3
{
    class Retangulo
    {
        public double Largura { get; set; }
        public double Altura { get; set; }

        public double Area()
        {
            return Largura * Altura;
        }

        public double Perimetro()
        {
            return (2 * Largura) + (2 * Altura);
        }

        public double Diagonal()
        {
            double diagonal = Math.Pow(Largura,2) + Math.Pow(Altura,2);
            return Math.Sqrt(diagonal);
        }

        public override string ToString(){
            return "Area: " + Area() + "\nPerimetro: " + Perimetro() + "\nDiagonal: " + Diagonal();
        }
    }
    class Funcionario
    {
        public string Name { get; set; }
        public double SalarioBruto { get; set; }
        public double Imposto { get; set; }

        public double SalarioLiquido()
        {
            return SalarioBruto - Imposto;
        }

        public void AumentarSalario(double percent)
        {
            double porcentagem = percent / 100;
            SalarioBruto = (SalarioBruto * porcentagem) + SalarioBruto;                     
        }

        public override string ToString()
        {
            return "Funcionario: " + Name + ", $" + SalarioLiquido();
        }
    }
     class Aluno
    {
        public string Name { get; set; }
        public double NotaPrimeiroTrimestre { get; set; }
        public double NotaSegundoTrimestre { get; set; }
        public double NotaTerceiroTrimestre { get; set; }
     
        public double NotaTotal()
        {
            return NotaPrimeiroTrimestre + NotaSegundoTrimestre + NotaTerceiroTrimestre;
        }

        public double MinAprovacao()
        {
            return 60 - NotaTotal(); 
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Retangulo retangulo = new Retangulo();

            Console.WriteLine("Entre com a largura e altura do retangulo: ");

            retangulo.Largura = double.Parse(Console.ReadLine());
            retangulo.Altura = double.Parse(Console.ReadLine());            

            Console.WriteLine(retangulo);

            //----------------------------------------------------------------

            Funcionario funcionario = new Funcionario();

            Console.Write("Nome: ");
            funcionario.Name = Console.ReadLine();
            Console.Write("Salario bruto: ");
            funcionario.SalarioBruto = double.Parse(Console.ReadLine());
            Console.Write("Imposto: ");
            funcionario.Imposto = double.Parse(Console.ReadLine());

            Console.WriteLine(funcionario);

            Console.Write("Digite a procentagem para aumentar o salario: ");
            double percent = double.Parse(Console.ReadLine());
            funcionario.AumentarSalario(percent);

            Console.WriteLine("Dados atualizados: " + funcionario);

            //-------------------------------------------------------

            Aluno aluno = new Aluno();

            Console.Write("Nome do aluno: ");
            aluno.Name = Console.ReadLine();            
            Console.WriteLine("Digite as tres notas do aluno: ");
            aluno.NotaPrimeiroTrimestre = double.Parse(Console.ReadLine());            
            aluno.NotaSegundoTrimestre = double.Parse(Console.ReadLine());
            aluno.NotaTerceiroTrimestre = double.Parse(Console.ReadLine());
            

            Console.WriteLine("Nota Final: " + aluno.NotaTotal());

            if(aluno.NotaTotal() < 60)
            {
                Console.WriteLine("Reprovado\nFaltam: " + aluno.MinAprovacao() + " pontos");
            }else
            {
                Console.WriteLine("Aprovado");
            }
        }
    }
}