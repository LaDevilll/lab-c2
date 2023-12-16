using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _123456
{
    public class AssortmentOfMedicines
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
}
