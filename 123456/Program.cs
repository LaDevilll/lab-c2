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
    public class Employees
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
            _transfers = new Transfer[] { new Transfer("Фармацевт", "Повышение", 333, new DateTime(2010,2,10)), new Transfer() };
        }

        public string Position
        {
            get
            {
                if (_transfers.Length > 0)
                {
                    return _transfers[_transfers.Length - 1].Post; // Возвращает последнюю должность из массива _transfers
                }
                else
                {
                    return "Не работает";
                }
            }
        }

        public void ChangePosition(string newPosition, int orderNumber, DateTime orderDate)
        {
            Transfer newTransfer = new Transfer(newPosition, "Изменение должности", orderNumber, orderDate);
            Transfer[] newTransfers = new Transfer[_transfers.Length + 1];
            Array.Copy(_transfers, newTransfers, _transfers.Length);
            newTransfers[newTransfers.Length - 1] = newTransfer;
            _transfers = newTransfers;
        }

        public int CalculateAge()
        {
            DateTime currentDate = DateTime.Now;
            int age = currentDate.Year - _dateofbirth.Year;
            if (currentDate.Month < _dateofbirth.Month || (currentDate.Month == _dateofbirth.Month && currentDate.Day < _dateofbirth.Day))
            {
                age--;
            }
            return age;
        }

        public string FullName
        {
            get { return $"{_name} {_lastname} {_middlename}"; }
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

        public void PrintEmployeeInfo()
        {
            Console.WriteLine($"Сотрудник: {FullName}");
            Console.WriteLine($"Возраст: {CalculateAge()} лет");
            Console.WriteLine($"Место проживания: {Address}");
            Console.WriteLine($"Должность: {Position}");
            Console.WriteLine($"Зарплата: {Salary} рублей");
            Console.WriteLine("Переводы:");
            foreach (var transfer in _transfers)
            {
                transfer.PrintToConsole();
            }
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

        public string Reasonfortransfer
        {
            get { return _reasonfortransfer; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Причина перевода не может быть пустой или состоять только из пробельных символов");
                _reasonfortransfer = value;
            }
        }

        public int Ordernumbers
        {
            get { return _ordernumbers; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Номер перевода не может быть отрицательным");
                _ordernumbers = value;
            }
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

        public void AddDiscount(double discount)
        {
            if (discount < 0 || discount > 100)
                throw new ArgumentException("Скидка должна быть в пределах от 0 до 100 %");

            decimal discountMultiplier = (decimal)(1 - discount / 100);
            Priceperpackage *= discountMultiplier;
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
                new Transfer("ррпр","прапрарп",90, new DateTime(1991, 5, 15))
            };
            Employees employees = new Employees("Иван", "Иванов", "Иванович", "Улица Пушкина", new DateTime(1997, 5, 15), 120000, "Заместитель фармацевта", transfers);
            employees.PrintToConsole();

            AssortmentOfMedicines assortmentOfMedicines = new AssortmentOfMedicines("Парацетомол", "Прямоугольная", 200, 4);
            assortmentOfMedicines.AddDiscount(10);


            Console.WriteLine("\nИзменение должности:");
            employees.ChangePosition("Новая должность", 123, DateTime.Now);
            employees.PrintEmployeeInfo();
            assortmentOfMedicines.PrintToConsole();
            Console.ReadKey();
        }
    }
}




