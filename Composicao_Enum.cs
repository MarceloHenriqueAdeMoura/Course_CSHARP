using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Composicao_Enum
{
    enum OrderStatus : int
    {
        PendingPayment = 0,
        Processing = 1,
        Shipped = 2,
        Delivered = 3
    }

    class Client
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }

        public Client()
        {            
        }

        public Client(string name, string email, DateTime birthDate)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }

        public override string ToString()
        {
            return Name + " (" + BirthDate.ToString("dd/MM/YYYY HH:mm:ss") + ") - " + Email;
        }
    }
    
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

    class OrderItem
    {
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Product Product { get; set; }

        public OrderItem()
        {            
        }

        public OrderItem(int quantity, double price, Product product)
        {
            Quantity = quantity;
            Price = price;
            Product = product;
        }

        public double SubTotal()
        {
            return Quantity * Price;
        }

        public override string ToString()
        {
            return Product.Name + ", $" + Price.ToString("F2", CultureInfo.InvariantCulture) + ", Quantity: " + Quantity + ", SubTotal: $" + SubTotal().ToString("F2", CultureInfo.InvariantCulture);
        }
    }

    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order()
        {            
        }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }

        public double Total()
        {
            double sum = 0;
            foreach(OrderItem obj in Items)
            {
                sum += obj.SubTotal();
            }

            return sum;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("Oder moment: " + Moment.ToString("dd/MM/YYYY HH:mm:ss"));
            builder.AppendLine("Order status: " + Status);
            builder.AppendLine("Client: " + Client);
            builder.AppendLine("Order items: ");

            foreach(OrderItem obj in Items)
            {
                builder.AppendLine(obj.ToString());
            }

            builder.AppendLine("Total price: " + Total().ToString("F2", CultureInfo.InvariantCulture));

            return builder.ToString();
        }        
    }        
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            Client client = new Client(name, email, birthDate);

            Console.WriteLine("Enter order data: ");
            Console.Write("Status: ");
            OrderStatus status = (OrderStatus) Enum.Parse(typeof(OrderStatus), Console.ReadLine());

            Order order = new Order(DateTime.Now, status, client);

            Console.Write("How many items to this order? ");
            int n = int.Parse(Console.ReadLine());

            for(int i=0; i<n; i++)
            {
                Console.WriteLine("Enter #" + (i + 1) + " item data:");
                Console.Write("Product name: ");
                string nameProduct = Console.ReadLine();
                Console.Write("Product price: ");
                double priceProduct = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Product product = new Product(name, priceProduct);

                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());
                OrderItem item = new OrderItem(quantity, priceProduct, product);

                order.AddItem(item);
            }

            Console.WriteLine("\nOrder Summary: " + order);            
        }
    }
}