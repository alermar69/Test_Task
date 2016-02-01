using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ModelEmployees.Abstract;
using MVC.Models;
using ModelEmployees.Entities;
using System.Net.Mime;

namespace MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeRepository repository;
        private ITax taxEmployee;
        private PageInfo pageInfo;
        private int pageSize;
        public int PageSize
        {
            get
            {
                return pageSize;
            }
            set
            {
                pageSize = value;
                if (pageInfo != null)
                    pageInfo.CountEmployeesPage = pageSize;
            }
        }

        public EmployeeController(IEmployeeRepository employeeRepository, ITax taxEmployee)
        {
            repository = employeeRepository;
            this.taxEmployee = taxEmployee;

            pageInfo = new PageInfo
            {
                CountEmployees = repository.Employees.Count(),
                CountEmployeesPage = PageSize,
                CurrentPage = 1
            };
            PageSize = 3;
        }

        // GET: Employee
        public ViewResult List(int page = 1)
        {
            IEnumerable<Employee> employes = repository.Employees;

            pageInfo.CurrentPage = page;

            ViewBag.PageInfo = pageInfo;
            ViewBag.Action = "List";

            return View(GetEmployeesPage(repository.Employees, page));
        }
        public ViewResult ListActiv(int page = 1)
        {
            IEnumerable<Employee> employes = repository.Employees.Where(m => m.Status);

            pageInfo.CurrentPage = page;
            pageInfo.CountEmployees = employes.Count();

            ViewBag.PageInfo = pageInfo;
            ViewBag.Action = "ListActiv";

            return View("List", GetEmployeesPage(employes, page));
        }
        public ViewResult ListNoActiv(int page = 1)
        {
            IEnumerable<Employee> employes = repository.Employees.Where(m => !m.Status);

            pageInfo.CurrentPage = page;
            pageInfo.CountEmployees = employes.Count();

            ViewBag.PageInfo = pageInfo;
            ViewBag.Action = "ListNoActiv";

            return View("List", GetEmployeesPage(employes, page));
        }

        public FileResult ReportEmployees()
        {
            IEnumerable<Employee> employees = repository.Employees.Where(m => m.Status);
            string path = Server.MapPath("~/Files/report.txt");
            IReport report = new Report(employees, taxEmployee);
            report.WriteFile(path);

            return File(path, MediaTypeNames.Text.Plain, "Отчет по активным сотрудникам");
        }

        private IEnumerable<Employee> GetEmployeesPage(IEnumerable<Employee> employes, int page)
        {
            return employes.OrderBy(m => m.EmployeeID).Skip((page - 1) * PageSize).Take(PageSize);
        }
    }
}