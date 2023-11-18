using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CLASS
{
    class Staff
    {
        string _name;
        string _lastname;
        string _middlename;
        string _address;
        DateTime _dateofbirth;
        decimal _salary;
        Transfer[] _tranfers;

        public void PrintToConsole()
        {
            Console.WriteLine($"Сотрудник {_name} {_lastname} {_middlename} {_address} {_dateofbirth} {_salary} рублей {_tranfers}");
        }

        public Staff(string name, string lastname, string middlename, string address, DateTime dateofbirth, decimal salary)
        {
            this._name = name;
            this._lastname = lastname;
            this._middlename = middlename;
            this._address = address;
            this._dateofbirth = dateofbirth;
            this._salary = salary;
        }

        public Staff()
        {
            _name = "Валерий";
            _lastname = "Леонтьев";
            _middlename = "Сергеевич";
            _address = "Космическая 99";
            _dateofbirth = new DateTime(2000, 10, 30);
            _salary = 150000;
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

        class Transfer
        {
            string _post;
            string _reasonfortranfer;
            int _ordernumbers;
            DateTime _dateoftheorder;

            public Transfer()
            {
                _post = "Фармацевт";
                _reasonfortranfer = "...";
                _dateoftheorder = new DateTime(2001, 11, 25);
            }
        }
    }
}
