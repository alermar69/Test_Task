using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;


namespace ModelEmployees.Entities
{
    public class Employee
    {
        [HiddenInput(DisplayValue = false)]
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Пожалуйста, введите должность")]
        public string Capacity { get; set; }

        public bool Status { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Пожалуйста, введите положительное значение зарплаты")]
        public decimal Salary { get; set; }

    }
}
