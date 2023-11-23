using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Runtime.ConstrainedExecution;

namespace CLASS
{
    class Employees
    {
        string _name;
        string _lastname;
        string _middlename;
        string _address;
        DateTime _dateofbirth;
        decimal _salary;
        Transfer[] _transfers;

        public void PrintToConsole()
        {
            Console.WriteLine($"Сотрудник: {_name} {_lastname} {_middlename}, {_address}, {_dateofbirth}, {_salary} рублей");
            Console.WriteLine("Переводы:");
            foreach (var transfer in _transfers)
            {
                transfer.PrintToConsole();
            }
        }

        public Employees(string name, string lastname, string middlename, string address, DateTime dateofbirth, decimal salary, Transfer[] transfers)
        {
            _transfers = transfers ?? new Transfer[0];
            _name = name;
            _lastname = lastname;
            _middlename = middlename;
            _address = address;
            _dateofbirth = dateofbirth;
            _salary = salary;
        }

        public Employees()
        {
            _name = "Валерий";
            _lastname = "Леонтьев";
            _middlename = "Сергеевич";
            _address = "Космическая 99";
            _dateofbirth = new DateTime(2000, 10, 30);
            _salary = 150000;
            _transfers = new Transfer[] { new Transfer("Фармацевт", "Повышение", 333, new DateTime(2001, 11, 25)), new Transfer() };
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Lastname
        {
            get { return _lastname; }
            set { _lastname = value; }
        }

        public string Middlename
        {
            get { return _middlename; }
            set { _middlename = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public DateTime Dateofbirth
        {
            get { return _dateofbirth; }
            set { _dateofbirth = value; }
        }

        public decimal Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }

        public Transfer[] transfers
        {
            get { return _transfers; }
            set { _transfers = value; }
        }
    }

    public class Transfer
    {
        private string _post;
        private string _reasonfortransfer;
        private int _ordernumbers;
        private DateTime _dateoftheorder;

        public Transfer()
        {
            _post = "Фармацевт";
            _reasonfortransfer = "Повышение";
            _ordernumbers = 333;
            _dateoftheorder = new DateTime(2001, 11, 25);
        }

        public Transfer(string post, string reasonfortransfer, int ordernumbers, DateTime dateoftheorder)
        {
            _post = post;
            _reasonfortransfer = reasonfortransfer;
            _ordernumbers = ordernumbers;
            _dateoftheorder = dateoftheorder;
        }

        public void PrintToConsole()
        {
            Console.WriteLine($"Перевод: {_post}, Причина: {_reasonfortransfer}, Номер приказа: {_ordernumbers}, Дата приказа: {_dateoftheorder}");
        }
    }


    class AssortmentOfMedicines
    {
        string _nameofthemedicine;
        string _packagingform;
        decimal _priceperpackage;
        decimal _amount;

        public AssortmentOfMedicines(string nameofthemedicine, string packagingform, decimal priceperpackage, decimal amount)
        {
            _nameofthemedicine = nameofthemedicine;
            _packagingform = packagingform;
            _priceperpackage = priceperpackage;
            _amount = amount;

        }
        public AssortmentOfMedicines()
        {
            _nameofthemedicine = "Парацетомол";
            _packagingform = "Прямоугольная";
            _priceperpackage = 200;
            _amount = 4;
        }

        public string Тameofthemedicine
        {
            get { return _nameofthemedicine; }
            set { _nameofthemedicine = value; }
        }

        public string Packagingform
        {
            get { return _packagingform; }
            set { _packagingform = value; }
        }

        public decimal Priceperpackage
        {
            get { return _priceperpackage; }
            set { _priceperpackage = value; }
        }

        public decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Transfer[] transfers = new[]
            {
                new Transfer("Фармацевт", "Повышение", 333, new DateTime(2001, 11, 25)),
                new Transfer(),
            };
            Employees employees = new Employees("Иван", "Иванов", "Иванович", "Улица Пушкина", new DateTime(1980, 5, 15), 120000, transfers);
            employees.PrintToConsole();
        }
    }
}




