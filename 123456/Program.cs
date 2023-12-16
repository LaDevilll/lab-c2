using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Runtime.ConstrainedExecution;
using _123456;

namespace CLASS
{
   

    internal class Program
    {
        static void Main(string[] args)
        {
            Transfer[] transfers = new[]
            {
                new Transfer(),
                new Transfer("ррпр","прапрарп",90, new DateTime(1991, 5, 15))
            };
            Employees employees = new Employees("Иван", "Иванов", "Иванович", "Улица Пушкина", new DateTime(1997, 5, 15), 120000, "Заместитель фармацевта", transfers);
            employees.PrintToConsole();

            AssortmentOfMedicines assortmentOfMedicines = new AssortmentOfMedicines("Парацетомол", "Прямоугольная", 200, 4);
            assortmentOfMedicines.AddDiscount(10);

            Employees employeeWithoutMiddleName = new Employees("Петр", "Петров", "", "Улица Лермонтова", new DateTime(1990, 3, 25), 100000, "Фармацевт", transfers);
            employeeWithoutMiddleName.PrintToConsole();

            Console.WriteLine("\nИзменение должности:");
            employees.ChangePosition("Новая должность", 123, DateTime.Now);
            employees.PrintEmployeeInfo();
            assortmentOfMedicines.PrintToConsole();
            Console.ReadKey();
        }
    }
}


