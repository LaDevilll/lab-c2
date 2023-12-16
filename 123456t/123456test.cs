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
            employee.ChangePosition("Новая должность", 123, DateTime.Now); // для изменения должности сотрудника
            Assert.AreEqual("Новая должность", employee.Position); //проверяется, что текущая должность сотрудника соответствует ожидаемой
            Assert.AreEqual(1, employee.transfers.Length - 1); //проверяется, что фактическое количество переводов соответствует ожидаемому
        }

        [TestMethod]
        public void ChangePosition_1()
        {
            Transfer[] transfers = new[]
            {
                new Transfer(),
                new Transfer("ррпр", "прапрарп", 90, new DateTime(1991, 5, 15)) //создается массив переводов, состоящий из двух элементов. Первый элемент - это пустой перевод, а второй - перевод с конкретными данными
            }; 
            Employees employee = new Employees("Иван", "Иванов", "Иванович", "Улица Пушкина", new DateTime(1997, 5, 15), 120000, "Заместитель фармацевта", transfers); // принимает
            employee.ChangePosition("Новая должность", 123, DateTime.Now); // вызывается метод
            Assert.AreEqual("Новая должность", employee.Position); // после изменения должности соответствует строке новая должность
            Assert.AreEqual(3, employee.transfers.Length);
        }

        [TestMethod]
        public void CalculateAge_2()
        {
            DateTime birthDateMinusOneDay = DateTime.Now.AddYears(-23).AddDays(-1); //до
            DateTime birthDatePlusOneDay = DateTime.Now.AddYears(-23).AddDays(1); // после

            Employees employee1 = new Employees("Имя", "Фамилия", "Отчество", "Адрес", birthDateMinusOneDay, 50000, "Должность", null); // создается объект класса Employees с использованием первой даты рождения
            Employees employee2 = new Employees("Имя", "Фамилия", "Отчество", "Адрес", birthDatePlusOneDay, 50000, "Должность", null); // вторая дата 

            int age1 = employee1.CalculateAge(); // вызывается метод CalculateAge для первого сотрудника, возвращающий его возраст
            int age2 = employee2.CalculateAge();

            Assert.AreEqual(23, age1); //проверка
            Assert.AreEqual(22, age2);
        }

        [TestMethod]
        public void FullName_WithMiddleName()
        {
            Transfer[] transfers = { new Transfer(), new Transfer("ррпр", "прапрарп", 90, new DateTime(1991, 5, 15)) }; // мас из 2 переводов, 1 - пустой 
            Employees employee = new Employees("Иван", "Иванов", "Иванович", "Улица Пушкина", new DateTime(1997, 5, 15), 120000, "Заместитель фармацевта", transfers); // объект класса, вкл мас переводов
            string fullName = employee.FullName; //dызывается свойство FullName 
            Assert.AreEqual("Иван Иванов Иванович", fullName);//проверка
        }

        [TestMethod]
        public void FullName_WithoutMiddleName()
        {
            Transfer[] transfers = { new Transfer(), new Transfer("ррпр", "прапрарп", 90, new DateTime(1991, 5, 15)) };
            Employees employee = new Employees("Петр", "Петров", "", "Улица Лермонтова", new DateTime(1990, 3, 25), 100000, "Фармацевт", transfers); // отчество -gecnfz cnhjrf
            string fullName = employee.FullName; // возвращает строку, представляющую полное имя сотрудника
            Assert.AreEqual("Петр Петров", fullName); //проверка
        }
    }
}
