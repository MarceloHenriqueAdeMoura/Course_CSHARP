using System;
using System.Globalization;

namespace OO7
{
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(){}

        public Product(string name, double price){
            Name = name;
            Price = price;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //double x = null; // erro
            Nullable<double> x = null; // ou
            double? y = null;
            double? z = 10;

            Console.WriteLine(x.GetValueOrDefault()); //imprime o valor, se nao tiver imprime o valor padrao do tipo
            Console.WriteLine(y.GetValueOrDefault());
            Console.WriteLine(z.GetValueOrDefault());

            Console.WriteLine(x.HasValue); // retorna true caso tenha valor, senao retorna false
            Console.WriteLine(y.HasValue);
            Console.WriteLine(z.HasValue);

            if(x.HasValue && y.HasValue){ //verifica se X e Y tem valor
                Console.WriteLine(x.Value); //lança uma exeção caso nao tenha valor
                Console.WriteLine(y.Value);
            }else{
                Console.WriteLine("X e Y são nulos");
            }
            Console.WriteLine(z.Value);      

            /*--------------------------------------------------------------------------------------------- */
            int n = int.Parse(Console.ReadLine());
            double[] vetor = new double[n];
            double media, soma =0;      

            for(int i=0; i<n; i++){
                vetor[i] = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            }           

            for(int i=0; i<n; i++){
                soma += vetor[i];                
            }
            media = soma / n;
            Console.WriteLine("Media da altura: " + media.ToString("F2", CultureInfo.InvariantCulture));

            Product[] vet = new Product[n];
            Product product = new Product();

            for(int i=0; i<n; i++){
                product.Name = Console.ReadLine();
                product.Price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                vet[i] = new Product(product.Name, product.Price);
            }

            //para cada Product obj dentro do vet faça...
            foreach (Product obj in vet)
            {
                Console.WriteLine(obj.Name);
            }

            soma = media = 0;
            for(int i=0; i<n; i++){
                soma += vet[i].Price;
            }

            media = soma / n;
            Console.WriteLine("Media da altura: " + media.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}