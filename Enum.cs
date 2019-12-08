using System;

namespace OO18
{
    enum OrderStatus
    {
        PendingPayment,
        Processing,
        Shipped,
        Delivered
    }
    class Order
    {
        public int Id { get; set; }
        public DateTime Moment { get; set; }    
        public OrderStatus Status { get; set; }

        public override string ToString(){
            return Id + ", " + Moment + ", " + Status;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Order order = new Order{
                Id = 0001,
                Moment = DateTime.Now,
                Status = OrderStatus.PendingPayment
            };

            Console.WriteLine(order);

            string txt = OrderStatus.Shipped.ToString();
            Console.WriteLine(txt);

            OrderStatus os = (OrderStatus) Enum.Parse(typeof(OrderStatus), ("Delivered"));
            Console.WriteLine(os);

        }
    }
}