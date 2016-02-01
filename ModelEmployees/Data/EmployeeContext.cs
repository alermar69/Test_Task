using System.Data.Entity;
using ModelEmployees.Entities;

namespace ModelEmployees.Data
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
    }
}
