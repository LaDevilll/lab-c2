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
        string _post;
        double _salary;
        Transfer[] _transfers;

        public void PrintToConsole()
        {
            Console.WriteLine($"Сотрудники: \nИмя: {_name}, Фамилия: {_lastname}, Отчество: {_middlename}, Место проживания: {_address}, Дата рождения: {_dateofbirth.ToString("dd.MM.yyyy")}, Должность: {_post}, Зарплата: {_salary} рублей");
            Console.WriteLine("Переводы:");
            foreach (var transfer in _transfers)
            {
                transfer.PrintToConsole();
            }
        }

        public Employees(string name, string lastname, string middlename, string address, DateTime dateofbirth, double salary, string post, Transfer[] transfers)
        {
            _transfers = transfers ?? new Transfer[0];
            _name = name;
            _lastname = lastname;
            _middlename = middlename;
            _address = address;
            _dateofbirth = dateofbirth;
            _post = post;
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
            _post = "Заместитель фармацевта";
            _transfers = new Transfer[] { new Transfer("Фармацевт", "Повышение", 333, new DateTime(25,2,2333)), new Transfer() };
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Имя не может быть пустым или состоять только из пробельных символов");
                _name = value;
            }
        }

        public string Lastname
        {
            get { return _lastname; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Фамилия не может быть пустой или состоять только из пробельных символов");
                _lastname = value;
            }
        }

        public string Middlename
        {
            get { return _middlename; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Отчество не может быть пустым или состоять только из пробельных символов");
                _middlename = value;
            }
        }

        public string Address
        {
            get { return _address; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Адрес не может быть пустым или состоять только из пробельных символов");
                _address = value;
            }
        }

        public DateTime Dateofbirth
        {
            get { return _dateofbirth; }
            set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("Дата рождения не может быть в будущем");
                _dateofbirth = value;
            }
        }

        public string Post
        {
            get { return _post; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Должность не может быть пустой или состоять только из пробельных символов");
                _post = value;
            }
        }

        public double Salary
        {
            get { return _salary; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Зарплата не может быть отрицательной");
                _salary = value;
            }
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
            Console.WriteLine($"Должность: {_post}, Причина: {_reasonfortransfer}, Номер приказа: {_ordernumbers}, Дата приказа: {_dateoftheorder.ToString("dd.MM.yyyy")}");
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

        public string Nameofthemedicine
        {
            get { return _nameofthemedicine; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Название лекарства не может быть пустым или состоять только из пробельных символов");
                _nameofthemedicine = value;
            }
        }

        public string Packagingform
        {
            get { return _packagingform; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Форма упаковки не может быть пустой или состоять только из пробельных символов");
                _packagingform = value;
            }
        }

        public decimal Priceperpackage
        {
            get { return _priceperpackage; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Цена за упаковку не может быть отрицательной");
                _priceperpackage = value;
            }
        }

        public decimal Amount
        {
            get { return _amount; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Количество упаковок не может быть отрицательным");
                _amount = value;
            }
        }

        public void PrintToConsole()
        {
            Console.WriteLine($"Название лекарства: {_nameofthemedicine}, Форма упаковки: {_packagingform}, Цена за упаковку: {_priceperpackage}, Количество: {_amount}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Transfer[] transfers = new[]
            {
                new Transfer(),
                new Transfer("ррпр","прапрарп",90, DateTime.Now)
            };
            Employees employees = new Employees("Иван", "Иванов", "Иванович", "Улица Пушкина", new DateTime(1980, 5, 15), 120000, "Заместитель фармацевта", transfers);
            employees.PrintToConsole();
            AssortmentOfMedicines assortmentOfMedicines = new AssortmentOfMedicines("Парацетомол", "Прямоугольная", 200, 4);
            assortmentOfMedicines.PrintToConsole();
            Console.ReadKey();
        }
    }
}




