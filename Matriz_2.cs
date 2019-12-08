using System;

namespace OO11
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] linha = Console.ReadLine().Split(' ');

            int m = int.Parse(linha[0]);
            int n = int.Parse(linha[1]);

            int[,] matriz = new int[m, n];

            for (int i = 0; i < m; i++)
            {
                string[] values = Console.ReadLine().Split(' ');
                for (int j = 0; j < n; j++)
                {
                    matriz[i, j] = int.Parse(values[j]);
                }
            }

            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (num == matriz[i, j])
                    {

                        Console.WriteLine("Positon " + i + "," + j + ":");
                        if(j > 0)
                            Console.WriteLine("Left: " + matriz[i, (j - 1)]);
                        if(j < n-1)
                            Console.WriteLine("Right: " + matriz[i, (j + 1)]);
                        if(i > 0)
                            Console.WriteLine("Up: " + matriz[(i - 1), j]);
                        if(i < m-1)
                            Console.WriteLine("Down: " + matriz[(i + 1), j]);
                    }
                }
            }
        }
    }
}