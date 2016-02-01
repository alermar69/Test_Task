using ModelEmployees.Abstract;
using ModelEmployees.Entities;
using System.Linq;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class AdminController : Controller
    {
        private IEmployeeRepository repository;

        public AdminController(IEmployeeRepository employeeRepository)
        {
            repository = employeeRepository;
        }

        public ViewResult Index()
        {
            return View(repository.Employees);
        }

        public ViewResult Edit(int employeeId)
        {
            return View(repository.Employees.First(m => m.EmployeeID == employeeId));
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if(ModelState.IsValid)
            {
                repository.SaveEmployee(employee);
                TempData["message"] = employee.Name + " успешно сохранен";
                return RedirectToAction("Index");
            }
            else
            {
                return View(employee);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Employee());
        }
    }
}