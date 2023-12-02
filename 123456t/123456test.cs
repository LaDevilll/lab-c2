using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CLASS;

namespace _123456t
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Employees employees = new Employees();
            employees.ChangePosition("Новая должность", 123, DateTime.Now);
            Assert.AreEqual(1, employees.transfers.Length);
            Assert.AreEqual("Новая должность", employees.Position);
        }
    }
}
