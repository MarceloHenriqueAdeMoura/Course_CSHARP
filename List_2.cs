using System;
using System.Collections.Generic;
using System.Globalization;

namespace OO9
{
    class Employee
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public double Salario { get; set; }

        public Employee() { }

        public Employee(int id, string nome, double salario)
        {
            ID = id;
            Nome = nome;
            Salario = salario;
        }

        public void IncrementarSalario(double percent)
        {
            double porcentagem = percent / 100;
            Salario = (Salario * porcentagem) + Salario;
        }

        public override string ToString() 
        {
            return ID + ", " + Nome + ", " + Salario.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> list = new List<Employee>();

            Console.Write("How many employees will be registered? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Emplyoee #" + (i + 1));
                Console.Write("Id: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string nome = Console.ReadLine();
                Console.Write("Salary: ");
                double salario = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                list.Add(new Employee(id, nome, salario));
            }

            foreach (Employee obj in list)
            {
                Console.WriteLine(obj.ID + ", " + obj.Nome + ", " + obj.Salario.ToString("F2", CultureInfo.InvariantCulture));
            }

            Console.Write("Enter the employee id that will have salary increase: ");
            int IdFuncionario = int.Parse(Console.ReadLine());

            
            Employee employee = list.Find(x => x.ID == IdFuncionario);
            
            if (employee != null)
            {
                Console.Write("Enter the percentage: ");
                double porcentagem = double.Parse(Console.ReadLine());
                employee.IncrementarSalario(porcentagem);
            }
            else
            {
                Console.WriteLine("This id does not exist!");
            }

            Console.WriteLine("Updated list of employees: ");
            foreach (Employee obj in list)
            {
                Console.WriteLine(obj);
            }
        }
    }
}