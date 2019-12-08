using System;
using System.Globalization;

class Programa
{
    enum MesesAno { Janeiro, Fevereiro, Março, Abril, Maio, Junho, Julho, Agosto, Setembro, Outubro, Novembro, Dezembro };

    static double Soma(double x, double y)
    {
        return x + y;
    }
    static double Subtracao(double x, double y)
    {
        return x - y;
    }

    public static void Main(string[] args)
    {
        //-------------------------------------------------------While-------------------------------------------------------------
        Console.Write("Digite um numero: ");
        int num = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        
        while (num >= 0)
        {            
            Console.WriteLine(Math.Sqrt(num).ToString("F3", CultureInfo.InvariantCulture));
            Console.Write("Digite outro numero: ");
            num = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        
        }

        Console.WriteLine("Numero negativo");

        //-------------------------------------------------------Problema Sem OO--------------------------------------------------------
        double xA, xB, xC, yA, yB, yC, p, areaX, areaY;
        Console.WriteLine("Entre com as medidas do triangulo X: ");
        xA = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        xB = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        xC = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        Console.WriteLine("Entre com as medidas do triangulo Y: ");
        yA = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        yB = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        yC = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        p = (xA + xB + xC) / 2.0;
        areaX = Math.Sqrt(p * (p - xA) * (p - xB) * (p - xC));

        p = (yA + yB + yC) / 2.0;
        areaY = Math.Sqrt(p * (p - yA) * (p - yB) * (p - yC));

        Console.WriteLine("Area de X: " + areaX.ToString("F4", CultureInfo.InvariantCulture));
        Console.WriteLine("Area de Y: " + areaY.ToString("F4", CultureInfo.InvariantCulture));
        /*---------------------------------------------------------Vetor e Matriz---------------------------------------------------------*/
        int[] vetor = new int[4];
        int[,] matriz = new int[5, 3];

        for (int i = 0; i < 4; i++)
        {
            Console.Write("Digite o numero para a posição " + i + " do vetor numeros: ");
            vetor[i] = Convert.ToInt32(Console.ReadLine());
        }
        for (int i = 0; i < vetor.Length; i++)
        {
            Console.WriteLine("Valor: {0} na posição: {1} do vetor", vetor[i], i);
        }

        foreach (int obj in vetor)
        {
            Console.WriteLine(obj); //para cada int obj dentro do vetor faca... impressao de todos os obj dentro da colecao
        }

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.WriteLine("Digite o numero para a posição " + i + "," + j + " da matriz: ");
                matriz[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.WriteLine("Valor: {0} na posição {1},{2} da matriz", matriz[i, j], i, j);
            }
        }


    /*------------------------------------Switch-Case / Go-To--------------------------------------*/

    //label do goto
    incioPrograma:

        Console.WriteLine("Escolha o meio de transporte de BH até Vitória/ES");
        Console.WriteLine("Avião : [A] / Onibus: [O] / Trem: [T]");

        char meioTransporte = Convert.ToChar(Console.ReadLine());

        switch (meioTransporte)
        {
            case 'A':
                Console.WriteLine("Você escolheu viajar de [{0}] - Avião \nTempo de viajem: 40min", meioTransporte);
                break;
            case 'O':
                Console.WriteLine("Você escolheu viajar de [{0}] - Onibus \nTempo de viajem: 8h", meioTransporte);
                break;
            case 'T':
                Console.WriteLine("Você escolheu viajar de [{0}] - Trem \nTempo de viajem: 10h", meioTransporte);
                break;
            default:
                Console.WriteLine("Nenhuma opção escolhida");
                break;
        }

        Console.WriteLine("Deseja executar o programa novamente? [y/n]");
        char opcao = Convert.ToChar(Console.ReadLine());

        if (opcao == 'y')
        {
            //apontando para o label
            goto incioPrograma;
        }
        else
        {
            Console.WriteLine("Programa finalizado");
        }

        /*-------------------------------------------If-Else / Operacao Ternaria---------------------------------------*/
        int nota1, nota2, nota3, notaFinal;

        Console.Write("Digite a primeira nota do aluno: ");
        nota1 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Digite a segunda nota do aluno: ");
        nota2 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Digite a terceira nota do aluno: ");
        nota3 = int.Parse(Console.ReadLine());

        notaFinal = nota1 + nota2 + nota3;

            //condicao ? resultado_caso_for_verdadeiro : resultado_caso_for_falso
        string opTernaria = notaFinal < 60 ? "Aluno reprovado" : "Aluno aprovado";
        Console.WriteLine(opTernaria);

        if (notaFinal < 60)
        {
            Console.WriteLine("Aluno reprovado \nNota1: {0}, Nota2: {1}, Nota3: {2} \nNota Final: {3}", nota1, nota2, nota3, notaFinal);
        }
        else
        {
            Console.WriteLine("Aluno aprovado");
        }
        /*-------------------------------------------Cast / Enum-----------------------------------------------*/
        MesesAno maPessoa1 = MesesAno.Dezembro;
        MesesAno maPessoa2 = (MesesAno) 9;

        int maFulano = (int) MesesAno.Dezembro + 1;
        int maCiclano = (int) MesesAno.Outubro + 1;

        Console.WriteLine(maPessoa1 + ", " + maFulano);
        Console.WriteLine(maPessoa2 + ", " + maCiclano);
        /*---------------------------------------------Funcoes----------------------------------------------*/
        double number1, number2;

        Console.WriteLine("Entre com dois numeros para soma e subtração:");
        number1 = Convert.ToDouble(Console.ReadLine());
        number2 = Convert.ToDouble(Console.ReadLine());

        double soma = Soma(number1, number2);
        double sub = Subtracao(number1, number2);

        Console.WriteLine("O resultado da soma é:{0,10:c}" , soma); //{indice,Largura do espaço : money}
        Console.WriteLine("O resultado da subtração é:{0,10:c}" , sub);
        /*--------------------------------------Indices/Conversoes------------------------------------------*/

        Console.WriteLine("Hello World");

        int num1, num2, result;

        Console.Write("Digite o primeiro numero: ");
        num1 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Digite o segundo numero: ");
        num2 = Convert.ToInt32(Console.ReadLine());

        result = num1 + num2;

        Console.WriteLine("O resultado é: " + result);

        double n1, n2, n3;
        n1 = 0.5;
        n2 = 1.5;
        n3 = 5.6;
        Console.WriteLine("n1= {0} / n2= {1} / n3= {2}", n1, n2, n3);
    }
}