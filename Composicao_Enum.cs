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

            builder.AppendLine("Order moment: ");
            builder.Append(Moment.ToString("dd/MM/YYYY HH:mm:ss"));
            builder.AppendLine("Order status: ");
            builder.Append(Status);
            builder.AppendLine("Client: ");
            builder.Append(Client.Name);
            builder.Append(" ");
            builder.Append(Client.BirthDate.ToString("dd/MM/YYYY HH:mm:ss"));
            builder.Append(" - ");
            builder.Append(Client.Email);
            builder.AppendLine("Order items:");

            foreach(Order obj in Items)
            {
                builder.AppendLine(obj.Items);
            }

            builder.AppendLine(Total());

            return builder.ToString();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}