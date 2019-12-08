using System;

namespace OO2
{
    class Produto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }    

        public double ValorTotalEmEstoque()
        {
            return Price * Quantity;
        }

        public void AdicionarProdutos(int quantity)
        {
            Quantity += quantity;
        }

        public void RemoverProdutos(int quantity)
        {
            Quantity -= quantity;
        }

        public override string ToString()
        {
            return Name + ", $ " + Price + ", " + Quantity + " unidades, Total: " + ValorTotalEmEstoque();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Produto produto = new Produto();

            Console.WriteLine(produto.ToString());

            Console.WriteLine("Entre com os dados do produto: ");
            Console.Write("Nome: ");
            produto.Name = Console.ReadLine();
            Console.Write("Preço: ");
            produto.Price = double.Parse(Console.ReadLine());
            Console.Write("Quantidade no estoque: ");
            produto.Quantity = int.Parse(Console.ReadLine());

            Console.WriteLine("Dados do produto: " + produto.ToString());

            Console.Write("Digite o numero de produtos a ser adicionado no estoque: ");
            int quantity = int.Parse(Console.ReadLine());
            produto.AdicionarProdutos(quantity);

            Console.WriteLine("Dados atualizados do produto: " + produto);

            Console.Write("Digite o numero de produtos a ser removidos do estoque: ");
            quantity = int.Parse(Console.ReadLine()); 
            produto.RemoverProdutos(quantity); 

            Console.WriteLine("Dados atualizados do produto: " + produto);
            
        }
    }
}