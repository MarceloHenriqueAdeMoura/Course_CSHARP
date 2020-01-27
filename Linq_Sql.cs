using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;

namespace Linq_Sql
{
    class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Tier { get; set; }
    }

    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }

        public override string ToString()
        {
            return Id + ", " + Name + ", " + Price.ToString("F2", CultureInfo.InvariantCulture) + ", " + Category.Name + ", " + Category.Tier;
        }
    }    
    class Program
    {
        static void Print<T>(string message, IEnumerable<T> collection)
        {
            Console.WriteLine(message);
            foreach (T obj in collection)
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Category category1 = new Category() { Id = 1, Name = "Tools", Tier = 2 };
            Category category2 = new Category() { Id = 2, Name = "Computers", Tier = 1 };
            Category category3 = new Category() { Id = 3, Name = "Eletronics", Tier = 1 };

            List<Product> products = new List<Product>() { 
                new Product() { Id = 1, Name  = "Computer", Price = 1100.00, Category = category2 }, 
                new Product() { Id = 2, Name  = "Hammer", Price = 90.00, Category = category1 },
                new Product() { Id = 3, Name  = "TV", Price = 1700.00, Category = category3 },
                new Product() { Id = 4, Name  = "Notebook", Price = 1300.00, Category = category2 },
                new Product() { Id = 5, Name  = "Saw", Price = 80.00, Category = category1 },
                new Product() { Id = 6, Name  = "Tablet", Price = 700.00, Category = category2 },
                new Product() { Id = 7, Name  = "Camera", Price = 700.00, Category = category3 },
                new Product() { Id = 8, Name  = "Printer", Price = 350.00, Category = category3 },
                new Product() { Id = 9, Name  = "MacBook", Price = 1800.00, Category = category2 },
                new Product() { Id = 10, Name  = "Sound Bar", Price = 700.00, Category = category3 },
                new Product() { Id = 11, Name  = "Level", Price = 70.00, Category = category1 }
            };

            //var result1 = products.Where(p => p.Category.Tier == 1 && p.Price < 900.00);
            var result1 = from p in products 
                          where p.Category.Tier == 1 && p.Price < 900.00 
                          select p;
            Print("TIER 1 AND PRICE < 900", result1);

            //var result2 = products.Where(p => p.Category.Name == "Tools").Select(p => p.Name);
            var result2 = from p in products
                          where p.Category.Name == "Tools"
                          select p.Name;
            Print("NAMES OF PRODUCTS FROM TOOLS", result2);

            //var result3 = products.Where(p => p.Name[0] == 'C').Select(p => new { p.Name, p.Price, CategoryName = p.Category.Name });
            var result3 = from p in products
                          where p.Name[0] == 'C'
                          select new { p.Name, p.Price, CategoryName = p.Category.Name };
            Print("NAMES STARTED WITH 'C' AND ANONYMOUS OBJECT", result3);

            //var result4 = products.Where(p => p.Category.Tier == 1).OrderBy(p => p.Price).ThenBy(p => p.Name);
            var result4 = from p in products
                          where p.Category.Tier == 1
                          orderby p.Name
                          orderby p.Price
                          select p;
            Print("TIER 1 ORDER BY PRICE THEN BY NAME", result4);

            //var result5 = result4.Skip(2).Take(4);
            var result5 = (from  p in result4 
                           select p).Skip(2).Take(4);
            Print("TIER 1 ORDER BY PRICE THEN BY NAME SKIP 2 TAKE 4", result5);

            //var result6 = products.FirstOrDefault();
            var result6 = (from p in products
                           select p).FirstOrDefault();
            Console.WriteLine("First or Default test1: " + result6);

            //var result7 = products.Where(p => p.Price > 3000.00).FirstOrDefault();
            var result7 = (from p in products
                           where p.Price > 3000.00
                           select p).FirstOrDefault();
            Console.WriteLine("First or Default test2: " + result7);

            //var result8 = products.Where(p => p.Id == 3).SingleOrDefault();
            var result8 = (from p in products
                           where p.Id == 3
                           select p).SingleOrDefault();
            Console.WriteLine("\nSingle or Default test1: " + result8);

            //var result9 = products.Where(p => p.Id == 30).SingleOrDefault();
            var result9 = (from p in products
                           where p.Id == 30
                           select p).SingleOrDefault();
            Console.WriteLine("Single or Default test2: " + result9);

            //var result10 = products.Max(p => p.Price);
            var result10 = (from p in products                           
                            select p.Price).Max();
            Console.WriteLine("\nMax price: " + result10);

            //var result11 = products.Min(p => p.Price);
            var result11 = (from p in products
                            select p.Price).Min();
            Console.WriteLine("Min price: " + result11);

            //var result12 = products.Where(p => p.Category.Id == 1).Sum(p => p.Price);
            var result12 = (from p in products
                            where p.Category.Id == 1
                            select p.Price).Sum();
            Console.WriteLine("\nCategory 1 Sum prices: " + result12);

            //var result13 = products.Where(p => p.Category.Id == 1).Average(p => p.Price);
            var result13 = (from p in products
                            where p.Category.Id == 1
                            select p.Price).Average();
            Console.WriteLine("Category 1 Average prices: " + result13);

            //var result14 = products.Where(p => p.Category.Id == 5).Select(p => p.Price).DefaultIfEmpty(0.0).Average();
            var result14 = (from p in products
                            where p.Category.Id == 5
                            select p.Price).DefaultIfEmpty(0.0).Average();
            Console.WriteLine("Category 5 Average prices: " + result14);

            //var result15 = products.Where(p => p.Category.Id == 1).Select(p => p.Price).Aggregate((x, y) => x + y);
            var result15 = (from p in products
                            where p.Category.Id == 1
                            select p.Price).Aggregate((x, y) => x + y);
            Console.WriteLine("Category 1 Aggregate sum: " + result15);

            //var result16 = products.Where(p => p.Category.Id == 5).Select(p => p.Price).Aggregate(0.0, (x, y) => x + y);
            var result16 = (from p in products
                            where p.Category.Id == 5
                            select p.Price).Aggregate(0.0, (x, y) => x + y);
            Console.WriteLine("Category 5 Aggregate sum with initial value: " + result16);

            //var result17 = products.GroupBy(p => p.Category);
            var result17 = (from p in products
                            group p by p.Category);
            foreach (IGrouping<Category, Product> group in result17)
            {
                Console.WriteLine("\nCategory: " + group.Key.Name + ": ");
                foreach (Product p in group)
                {
                    Console.WriteLine(p);
                }                
            }
        }   
    }
}