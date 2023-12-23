using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CLASS;
using _BDApteki;

namespace _EmployeesTests
{
    [TestClass]
    public class EmployeeTest
    {
        [TestMethod]
        public void ChangePosition_1()
        {
            Employees employee = new Employees();
            employee.ChangePosition("Новая должность", 123, DateTime.Now); // для изменения должности сотрудника
            Assert.AreEqual("Новая должность", employee.Position); //проверяется, что текущая должность сотрудника соответствует ожидаемой
            Assert.AreEqual(1, employee.transfers.Length); //проверяется, что фактическое количество переводов соответствует ожидаемому
        }

        [TestMethod]
        public void ChangePosition_2()
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
        [DataRow(2003, 1, 4, 2)]
        [DataRow(2003, 1, 6, 1)]
        public void CalculateAge_Test(int birthYear, int birthMonth, int birthDay, int expected)
        {
            DateTime birthDate = new DateTime(birthYear, birthMonth, birthDay);
            Employees employee = new Employees("Имя", "Фамилия", "Отчество", "Адрес", birthDate, 50000, "Должность", null);
            DateTime currentDateForAgeCalculation = new DateTime(2005, 1, 5);
            int calculateAge = Employees.CalculateAge(currentDateForAgeCalculation, birthDate);
            Assert.AreEqual(expected, calculateAge);
        }


        [TestMethod]
        [DataRow("Пётр", "Иванов", "", "Пётр Иванов" )]
        [DataRow("Пётр", "Иванов", "Иванович", "Пётр Иванов Иванович")]
        
        public void FullName_Test(string Name, string LastlName, string MiddleName, string expected) 
        {
            Employees employee = new Employees(Name, LastlName, MiddleName,"ADADA", new DateTime(1957,10,2), 2000, "Фармацевт", new Transfer[1]); // отчество -gecnfz cnhjrf
            string fullName = employee.FullName; // возвращает строку, представляющую полное имя сотрудника
            Assert.AreEqual(expected, fullName); // проверка
        }
    }
}
