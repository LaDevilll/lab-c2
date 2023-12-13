using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CLASS;

namespace _123456_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ChangePosition_()
        {
            Employees employee = new Employees();
            employee.ChangePosition("Новая должность", 123, DateTime.Now);
            Assert.AreEqual("Новая должность", employee.Position);
            Assert.AreEqual(3, employee.transfers.Length);
        }

        [TestMethod]
        public void ChangePosition_1()
        {
            Transfer[] transfers = new[]
            {
                new Transfer(),
                new Transfer("ррпр", "прапрарп", 90, new DateTime(1991, 5, 15))
            };
            Employees employee = new Employees("Иван", "Иванов", "Иванович", "Улица Пушкина", new DateTime(1997, 5, 15), 120000, "Заместитель фармацевта", transfers);
            employee.ChangePosition("Новая должность", 123, DateTime.Now);
            Assert.AreEqual("Новая должность", employee.Position);
            Assert.AreEqual(3, employee.transfers.Length);
        }

        [TestMethod]
        public void CalculateAge_2()
        {
            DateTime birthDateMinusOneDay = DateTime.Now.AddYears(-23).AddDays(-1);
            DateTime birthDatePlusOneDay = DateTime.Now.AddYears(-23).AddDays(1);

            Employees employee1 = new Employees("Имя", "Фамилия", "Отчество", "Адрес", birthDateMinusOneDay, 50000, "Должность", null);
            Employees employee2 = new Employees("Имя", "Фамилия", "Отчество", "Адрес", birthDatePlusOneDay, 50000, "Должность", null);

            int age1 = employee1.CalculateAge();
            int age2 = employee2.CalculateAge();

            Assert.AreEqual(23, age1);
            Assert.AreEqual(22, age2);
        }

        [TestMethod]
        public void FullName_WithMiddleName()
        {
            Transfer[] transfers = { new Transfer(), new Transfer("ррпр", "прапрарп", 90, new DateTime(1991, 5, 15)) };
            Employees employee = new Employees("Иван", "Иванов", "Иванович", "Улица Пушкина", new DateTime(1997, 5, 15), 120000, "Заместитель фармацевта", transfers);
            string fullName = employee.FullName;
            Assert.AreEqual("Иван Иванов Иванович", fullName);
        }

        [TestMethod]
        public void FullName_WithoutMiddleName()
        {
            Transfer[] transfers = { new Transfer(), new Transfer("ррпр", "прапрарп", 90, new DateTime(1991, 5, 15)) };
            Employees employee = new Employees("Петр", "Петров", "", "Улица Лермонтова", new DateTime(1990, 3, 25), 100000, "Фармацевт", transfers);
            string fullName = employee.FullName;
            Assert.AreEqual("Петр Петров", fullName);
        }
    }
}
