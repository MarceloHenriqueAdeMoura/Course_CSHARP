using System;
using System.Collections.Generic;

namespace OO15
{
    class Employee
    {
        public string Name { get; set; }
        public int Hours { get; set; }
        public double ValuePerHour { get; set; }

        public Employee() { }

        public Employee(string name, int hours, double valuePerHour)
        {
            Name = name;
            Hours = hours;
            ValuePerHour = valuePerHour;
        }

        public virtual double Payment()
        {
            return ValuePerHour * Hours;
        }
    }
    class OutsourcedEmployee : Employee
    {
        public double AdditionalCharge { get; set; }

        public OutsourcedEmployee() { }

        public OutsourcedEmployee(string name, int hours, double valuePerHour, double additionalCharge) : base(name, hours, valuePerHour)
        {
            AdditionalCharge = additionalCharge;
        }

        public sealed override double Payment()
        {
            double total = base.Payment();
            return total + (1.1 * AdditionalCharge);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();

            Console.Write("Enter the number of Employee: ");
            int n = int.Parse(Console.ReadLine());

            for (int i=0; i<n; i++)
            {
                Console.WriteLine("Employee #" + (i+1) + " data: ");
                Console.Write("Outsourced (y/n)? ");
                char op = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Hours: ");
                int hours = int.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double value = double.Parse(Console.ReadLine());
                switch (op)
                {
                    case 'y':
                        Console.Write("Additional charge: ");
                        double addCharge = double.Parse(Console.ReadLine());
                        employees.Add(new OutsourcedEmployee(name, hours, value, addCharge));
                        break;
                    case 'n':
                        employees.Add(new Employee(name, hours, value));
                        break;
                    default:
                        Console.WriteLine("Opção nao identificada!");
                        break;
                }
            }
            Console.WriteLine("\nPAYMENTS: ");
            foreach (Employee obj in employees)
            {
                Console.WriteLine(obj.Name + " - " + "$" + obj.Payment());
            }
          }
    }
}