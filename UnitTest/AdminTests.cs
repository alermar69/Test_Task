using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelEmployees.Abstract;
using ModelEmployees.Entities;
using Moq;
using MVC.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace UnitTest
{
    [TestClass]
    public class AdminTests
    {
        [TestMethod]
        public void Index_AllEmployes()
        {
            Mock<IEmployeeRepository> mock = new Mock<IEmployeeRepository>();
            mock.Setup(m => m.Employees).Returns(new List<Employee> {
                new Employee {EmployeeID = 1, Name = "Name1"},
                new Employee {EmployeeID = 2, Name = "Name2"},                
            });

            AdminController controller = new AdminController(mock.Object);

            List<Employee> result = ((IEnumerable<Employee>)controller.Index().Model).ToList();

            Assert.IsTrue(result.Count == 2);
            Assert.AreEqual(result[0].Name, "Name1");
            Assert.AreEqual(result[1].Name, "Name2");
        }

        [TestMethod]
        public void Edit_Employee()
        {
            Mock<IEmployeeRepository> mock = new Mock<IEmployeeRepository>();
            mock.Setup(m => m.Employees).Returns(new List<Employee> {
                new Employee {EmployeeID = 1, Name = "Name1"},
                new Employee {EmployeeID = 2, Name = "Name2"},
                new Employee {EmployeeID = 3, Name = "Name3"},
            });

            AdminController controller = new AdminController(mock.Object);

            Employee e1 = controller.Edit(1).Model as Employee;
            Employee e2 = controller.Edit(2).Model as Employee;
            Employee e3 = controller.Edit(3).Model as Employee;

            Assert.AreEqual(e1.EmployeeID, 1);
            Assert.AreEqual(e2.EmployeeID, 2);
            Assert.AreEqual(e3.EmployeeID, 3);
        }

        [TestMethod]
        public void Edit_Save()
        {
            Mock<IEmployeeRepository> mock = new Mock<IEmployeeRepository>();
            AdminController controller = new AdminController(mock.Object);
            Employee emp = new Employee { Name = "Test" };

            ActionResult res = controller.Edit(emp);

            mock.Verify(m => m.SaveEmployee(emp));
            Assert.IsNotInstanceOfType(res, typeof(ViewResult));
        }
    }
}
