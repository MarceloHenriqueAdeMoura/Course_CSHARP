using System;
using System.Collections.Generic;

namespace Action
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
        static void UpdatePrice(Product p)
        {
            p.Price += p.Price * 0.1;
        }
        static void Main(string[] args)
        {
            List<Product> list = new List<Product>();

            list.Add(new Product("TV", 900.00));
            list.Add(new Product("Mouse", 50.00));
            list.Add(new Product("Tablet", 350.50));
            list.Add(new Product("HD Case", 80.90));

            //Action<Product> action1 = p => { p.Price += p.Price * 0.1; }
            Action<Product> action = UpdatePrice;

            list.ForEach(action);

            foreach (Product p in list)
            {
                Console.WriteLine(p);
            }
        }
    }
}