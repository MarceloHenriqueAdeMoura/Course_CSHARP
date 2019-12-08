using System;
using System.Collections.Generic;

namespace OO10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite o tamanho da matriz: ");
            int n = int.Parse(Console.ReadLine());
            int[,]  matriz = new int[n,n];

            for(int i=0; i<n; i++){
                string[] values = Console.ReadLine().Split(' ');
                for(int j=0; j<n; j++){
                    matriz[i,j] = int.Parse(values[j]);
                }
            }

            Console.WriteLine("Diagonal da matriz: ");

            for(int i=0; i<n; i++){
                Console.Write(matriz[i,i] + " ");
                /*for(int j=0; j<n; j++){
                    if(i == j){
                        Console.WriteLine(matriz[i,j] + " ");
                    }
                } */
            }

            Console.WriteLine("\nQuantos numeros negativos tem na matriz: ");
            int count = 0;
            for(int i=0; i<n; i++){
                for(int j=0; j<n; j++){
                    if(matriz[i,j] < 0){
                        count++;                        
                    }
                }
            }
            Console.Write(count);
        }
    }
}