using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System.Linq;

namespace Linq
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
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();

            List<Product> products = new List<Products>();

            using (StreamReader str = File.OpenText(path))
            {
                while(!str.EndOfStream)
                {
                    string[] fields = str.ReadLine().Split(',');
                    string name = fields[0];
                    double price = double.Parse(fields[1], CultureInfo.InvariantCulture);
                    products.Add(new Product(name, price));
                }
            }

            var avg = products.Select(p => p.Price).DefaultIfEmpty(0.0).Average();
            Console.WriteLine("Average price: " + avg.ToString("F2", CultureInfo.InvariantCulture));

            var names = products.Where(p => p.Price < avg).OrderByDescending(p => p.Name).Select(p => p.Name);
            foreach (string name in names)
            {
                Console.WriteLine(name);
            } 
        }
    }
}