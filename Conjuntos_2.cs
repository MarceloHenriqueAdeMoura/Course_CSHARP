using System;
using System.Collections.Generic;

namespace OO13
{
    class Program
    {
        static void Main(string[] args)
        {            
            HashSet<int> A = new HashSet<int>();
            HashSet<int> B = new HashSet<int>();
            HashSet<int> C = new HashSet<int>();

            Console.Write("O curso A possui quantos alunos? ");
            int numA = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite o codigo dos alunos do curso A: ");
            for(int i=0; i<numA; i++){
                int alunoA = int.Parse(Console.ReadLine());
                A.Add(alunoA);
            }

            Console.Write("O curso B possui quantos aluno? ");
            int numB = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o codigo dos alunos do curso B: ");
            for(int i=0; i<numB; i++){
                int alunoB = int.Parse(Console.ReadLine());
                B.Add(alunoB);
            }

            Console.Write("O curso C possui quantos alunos? ");
            int numC = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o codigo dos alunos do curso C: ");
            for(int i=0; i<numC; i++){
                int alunoC = int.Parse(Console.ReadLine());
                C.Add(alunoC);
            }
            C.UnionWith(A);
            A.UnionWith(B);
            B.UnionWith(C);


            Console.WriteLine("Total de aluno: " + B.Count);

            foreach(int obj in A){
                Console.WriteLine(obj);
            }
        }
    }
}