using System;
using System.Collections.Generic;

namespace Predicate
{
    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Product()
        {            
        }
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            return Name + ", " + Price.ToString("F2");
        }
    }    
    class Program
    {
        public static bool ProductTest(Product p)
        {
            return p.Price >= 100.00;
        }
        static void Main(string[] args)
        {
        List<Product> list = new List<Product>();

        list.Add(new Product("TV", 900.00));
        list.Add(new Product("Mouse", 50.00));
        list.Add(new Product("Tablet", 350.50));
        list.Add(new Product("HD Case", 80.90));

        //list.RemoveAll(p => p.Price >= 100.00);
        list.RemoveAll(ProductTest);
        foreach (Product p in list)
        {
            Console.WriteLine(p);
        }

        }
    }
}