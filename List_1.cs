using System;
using System.Collections.Generic;

namespace OO8
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lista = new List<string> {"Valor 1", "Valor 2"};
            List<string> list = new List<string>();

            list.Add("Gabriel"); //insere ao final da lista
            list.Add("Rafael");
            list.Add("Lucas");
            list.Add("Ana");
            list.Insert(1, "Alex"); //adciona elemento passando posiçao            

            foreach (string obj in list)
            {
                Console.WriteLine(obj);
            }
            
            Console.WriteLine("Tamanho da lista: " + list.Count); //mostra o tamanho da lista

            //pode ser passado uma funçao booleana ou uma expressao lambda(funçao anonima)
            Console.WriteLine(list.Find(Test));

            //retorne o obj x tal que x na posiçao 0 (primeira posiçao) seja igual a A
            Console.WriteLine(list.Find(x => x[0] == 'A')); //retorna a primeira ocorrencia de um valor que comece com A 

            string elemento = list.FindLast(x => x[0] == 'A'); //retorna a ultima ocorrencia de um elemnto que comece com A
            Console.WriteLine(elemento);

            Console.WriteLine(list.FindIndex(x => x[0] == 'A')); //retorna a posiçao da primeira ocorrencia de um elemento que comece com A

            int posiçao = list.FindLastIndex(x => x[0] == 'A'); //retorna a posiçao da ultima ocorrencia de um elemento que comece com A
            Console.WriteLine(posiçao);

            Console.WriteLine("-----------------------------------------------------");

            //findAll criar uma nova lista com elementos que satisfaça a exressao
            List<string> list2 = list.FindAll(x => x.Length == 5); //retorna um filtro com todos os elementos que possuem 5 caracteres

            foreach (string obj in list2)
            {
                Console.WriteLine(obj);
            }

            list.Remove("Gabriel"); //remove o elmento passado
            Console.WriteLine("-----------------------------------------------------");
            foreach(string obj in list)
            {
                Console.WriteLine(obj);
            }

            list.RemoveAll(x => x[0] == 'A'); //remove os elmentos que satisfaçam a expressao
            Console.WriteLine("-----------------------------------------------------");
            foreach(string obj in list)
            {
                Console.WriteLine(obj);
            }

            list.RemoveAt(2); //remove o elemento que foi passada a posiçao
            Console.WriteLine("-----------------------------------------------------");
            foreach(string obj in list)
            {
                Console.WriteLine(obj);
            }

            list.RemoveRange(1, 2); //remove uma quantidade de elementos passados a partir de uma posiçao passada
            Console.WriteLine("-----------------------------------------------------");
            foreach(string obj in list)
            {
                Console.WriteLine(obj);                
            }
        }

        static bool Test(string x)
        {
            return x[0] == 'A'; //retorna true quando a condiçao for verdadeira
        }
    }
}