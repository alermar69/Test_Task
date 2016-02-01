using System.Collections.Generic;
using ModelEmployees.Abstract;
using ModelEmployees.Entities;

namespace ModelEmployees.Data
{
    public class EFEmployeeRepository : IEmployeeRepository
    {
        private EmployeeContext context = new EmployeeContext();
        public IEnumerable<Employee> Employees
        {
            get
            {
                return context.Employees;
            }
        }

        public void SaveEmployee(Employee employee)
        {
            if(employee.EmployeeID == 0)
            {
                context.Employees.Add(employee);
            }
            else
            {
                Employee emp = context.Employees.Find(employee.EmployeeID);
                if(emp != null)
                {
                    emp.Name = employee.Name;
                    emp.Capacity = employee.Capacity;
                    emp.Status = employee.Status;
                    emp.Salary = employee.Salary;
                }
            }
            context.SaveChanges();
        }
    }
}
