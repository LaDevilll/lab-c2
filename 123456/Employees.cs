using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _123456
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
            _name = "";
            _lastname = "";
            _middlename = "";
            _address = "";
            _dateofbirth = new DateTime(1, 1, 1);
            _salary = 0;
            _post = "";
            _transfers = new Transfer[0];
        }

        public string Position   // возвращает текущую должность сотрудника
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
            newTransfers[newTransfers.Length - 1] = newTransfer; //  новый перевод в конец массива
            _transfers = newTransfers;
        }


        public int CalculateAge(DateTime currentDate)
        {
            return CalculateAge(currentDate, Dateofbirth);
        }

        public static int CalculateAge(DateTime currentDate, DateTime birthDate)
        {
            int age = currentDate.Year - birthDate.Year;
            if (currentDate.Month < birthDate.Month || (currentDate.Month == birthDate.Month && currentDate.Day < birthDate.Day))
            {
                age--;
            }
            return age;
        }



        public string FullName
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(_middlename))
                {
                    return $"{_name} {_lastname} {_middlename}";
                }
                else
                {
                    return $"{_name} {_lastname}";
                }
            }
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
            set { _middlename = value; }
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

        public void PrintEmployeeInfo(DateTime currentDate)
        {
            Console.WriteLine($"Сотрудник: {FullName}");
            Console.WriteLine($"Возраст: {CalculateAge(currentDate)} лет");
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

}
