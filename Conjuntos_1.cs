using System;
using System.Collections.Generic;

namespace OO12
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> A = new HashSet<int>();
            HashSet<int> B = new HashSet<int>();

            A.Add(2);
            A.Add(1);
            A.Add(6);
            A.Add(3);

            B.Add(0);
            B.Add(4);
            B.Add(8);

            Console.WriteLine("Entre com um numero inteiro: ");
            int num = int.Parse(Console.ReadLine());

            if(A.Contains(num)){
                Console.WriteLine(num + "pertence ao conjunto A");
            }

            A.Remove(3);

            //diferena entre conjuntos
            A.ExceptWith(B);
            //uniao entre conjuntos
            A.UnionWith(B);
            //intersecçao entre conjuntos
            A.IntersectWith(B);
            foreach(int obj in A){
                Console.WriteLine(obj);
            }
        }
    }    
}