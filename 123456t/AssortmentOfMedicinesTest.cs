using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using _BDApteki;

namespace AssortmentOfMedicines_Tests
{
    [TestClass]
    public class AOMTest
    {
        [TestMethod]
        [DataRow(10, 90)]
        public void AddDiscount_Test(double discount, double expected)
        {
            AssortmentOfMedicines assortment = new AssortmentOfMedicines("Лекарство", "Форма", 100, 2);
            
            assortment.AddDiscount(discount);
            Assert.AreEqual(expected, (double)assortment.Priceperpackage);
            //AAA Arange -> Act -> Assert
        }

       [TestMethod]
       [DataRow(-10, 90)]
        public void AddDiscount_Test2(double discount, double expected)
        {
            bool catched = false;
            try
            {
                AssortmentOfMedicines assortment = new AssortmentOfMedicines("Лекарство", "Форма", 100, 2);
                assortment.AddDiscount(discount);
            }
            catch
            {
                catched = true;
            }
            Assert.IsTrue(catched, "скидка не была успешно обработана");
        }

        [TestMethod]
        [DataRow(-10, 90)]
        public void AddDiscount_Test3(double discount, double expected)
        {
            AssortmentOfMedicines assortment = new AssortmentOfMedicines("Лекарство", "Форма", 100, 2);
            Assert.ThrowsException<ArgumentException>(() => assortment.AddDiscount(discount), "скидка не была успешно обработана");
        }
    }
}
