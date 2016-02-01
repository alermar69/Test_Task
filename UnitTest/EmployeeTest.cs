using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ModelEmployees.Abstract;
using ModelEmployees.Entities;
using System.Collections.Generic;
using MVC.Controllers;
using System.Linq;
using System.Web.Mvc;
using MVC.Models;
using MVC.HtmlHelpers;

namespace UnitTest
{
    [TestClass]
    public class EmployeeTest
    {
        [TestMethod]
        public void Split_Page()
        {
            Mock<IEmployeeRepository> mockData = new Mock<IEmployeeRepository>();
            mockData.Setup(m => m.Employees).Returns(new List<Employee> {
                new Employee {EmployeeID = 1, Name = "Name1"},
                new Employee {EmployeeID = 2, Name = "Name2"},
                new Employee {EmployeeID = 3, Name = "Name3"},
                new Employee {EmployeeID = 4, Name = "Name4"},
                new Employee {EmployeeID = 5, Name = "Name5"}
            });

            EmployeeController controller = new EmployeeController(mockData.Object, new Mock<ITax>().Object);
            controller.PageSize = 3;


            IEnumerable<Employee> result = (IEnumerable<Employee>)controller.List(2).Model;


            List<Employee> employees = result.ToList();
            Assert.IsTrue(employees.Count == 2);
            Assert.AreEqual(employees[0].Name, "Name4");
            Assert.AreEqual(employees[1].Name, "Name5");
        }

        [TestMethod]
        public void Generate_Page_Links()
        {


            HtmlHelper myHelper = null;
            PageInfo pageInfo = new PageInfo
            {
                CurrentPage = 2,
                CountEmployees = 14,
                CountEmployeesPage = 5
            };


            MvcHtmlString result = myHelper.PageLinks(pageInfo, m => "Page" + m);

            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>"
                + @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>"
                + @"<a class=""btn btn-default"" href=""Page3"">3</a>",
                result.ToString());
        }

        [TestMethod]
        public void Filter_Employee()
        {
            Mock<IEmployeeRepository> mockData = new Mock<IEmployeeRepository>();
            mockData.Setup(m => m.Employees).Returns(new List<Employee> {
                new Employee {EmployeeID = 1, Name = "Name1", Status = true},
                new Employee {EmployeeID = 2, Name = "Name2", Status = true},
                new Employee {EmployeeID = 3, Name = "Name3", Status = false},
                new Employee {EmployeeID = 4, Name = "Name4", Status = true},
                new Employee {EmployeeID = 5, Name = "Name5", Status = false}
            });

            EmployeeController controller = new EmployeeController(mockData.Object, new Mock<ITax>().Object);


            List<Employee> employeesActiv = ((IEnumerable<Employee>)controller.ListActiv().Model).ToList();
            List<Employee> employeesNoActiv = ((IEnumerable<Employee>)controller.ListNoActiv().Model).ToList();

            Assert.IsTrue(employeesActiv.Count == 3);
            Assert.AreEqual(employeesActiv[0].Name, "Name1");
            Assert.AreEqual(employeesActiv[1].Name, "Name2");
            Assert.AreEqual(employeesActiv[2].Name, "Name4");

            Assert.IsTrue(employeesNoActiv.Count == 2);
            Assert.AreEqual(employeesNoActiv[0].Name, "Name3");
            Assert.AreEqual(employeesNoActiv[1].Name, "Name5");
        }

        [TestMethod]
        public void Count_Page_StatusEmployee()
        {
            Mock<IEmployeeRepository> mockData = new Mock<IEmployeeRepository>();
            mockData.Setup(m => m.Employees).Returns(new List<Employee> {
                new Employee {EmployeeID = 1, Name = "Name1", Status = true},
                new Employee {EmployeeID = 2, Name = "Name2", Status = true},
                new Employee {EmployeeID = 3, Name = "Name3", Status = false},
                new Employee {EmployeeID = 4, Name = "Name4", Status = true},
                new Employee {EmployeeID = 5, Name = "Name5", Status = false}
            });

            EmployeeController controller = new EmployeeController(mockData.Object, new Mock<ITax>().Object);
            controller.PageSize = 2;
            
            int resAll = ((PageInfo)controller.List().ViewBag.PageInfo).CountPages;
            int resActiv = ((PageInfo)controller.ListActiv().ViewBag.PageInfo).CountPages;
            int resNoActiv = ((PageInfo)controller.ListNoActiv().ViewBag.PageInfo).CountPages;
          
            Assert.AreEqual(resAll, 3);
            Assert.AreEqual(resActiv, 2);
            Assert.AreEqual(resNoActiv, 1);
        }
    }
}
