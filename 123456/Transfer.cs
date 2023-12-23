using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BDApteki
{
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

        public void PrintToConsole()
        {
            Console.WriteLine($"Должность: {_post}, Причина: {_reasonfortransfer}, Номер приказа: {_ordernumbers}, Дата приказа: {_dateoftheorder.ToString("dd.MM.yyyy")}");
        }
    }
}
