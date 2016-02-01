using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelEmployees.Entities;
using ModelEmployees.Abstract;

namespace UnitTest
{
    [TestClass]
    public class EntitiesTest
    {

        [TestMethod]
        public void ApplyTax()
        {
            ITax tax = new TaxSalary();

            decimal res1 = tax.ApplyTax(5000M);
            decimal res2 = tax.ApplyTax(15000M);
            decimal res3 = tax.ApplyTax(30000M);

            Assert.AreEqual(4500, res1);
            Assert.AreEqual(12750, res2);
            Assert.AreEqual(22500, res3);
        }
    }
}
