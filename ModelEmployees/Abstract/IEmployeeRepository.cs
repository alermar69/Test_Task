using ModelEmployees.Entities;
using System.Collections.Generic;

namespace ModelEmployees.Abstract
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> Employees { get; }
        void SaveEmployee(Employee employee);
    }
}
