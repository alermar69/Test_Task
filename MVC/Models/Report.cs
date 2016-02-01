using ModelEmployees.Abstract;
using ModelEmployees.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MVC.Models
{
    public class Report : IReport
    {
        public IEnumerable<Employee> Employees { get; }
        public ITax TaxSalary { get; }

        private int widthName = 20;
        private int widthSalary = 15;

        public Report (IEnumerable<Employee> employees, ITax taxSalary)
        {
            Employees = employees;
            TaxSalary = taxSalary;
        }

        public void WriteFile(string path)
        {
            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                WrtiteHead(sw);
                WriteEmployees(sw);
                WriteFooter(sw);
            }
        }


        private void WrtiteHead(StreamWriter sw)
        {
            sw.Write(AddSpase("Имя", widthName));
            sw.Write(AddSpase("Зарплата", widthSalary));
            sw.Write(AddSpase("Налог", widthSalary));
            sw.WriteLine(AddSpase("Зарплата с налогом", widthSalary));
            sw.WriteLine();
        }
        private void WriteEmployees(StreamWriter sw)
        {
            foreach (Employee emp in Employees)
            {
                sw.Write(AddSpase(emp.Name, widthName));
                sw.Write(AddSpase(emp.Salary.ToString("c"), widthSalary));
                sw.Write(AddSpase(TaxSalary.GetTax(emp.Salary).ToString() + "%", widthSalary));
                sw.WriteLine(AddSpase(TaxSalary.ApplyTax(emp.Salary).ToString("c"), widthSalary));
            }
            sw.WriteLine();
        }
        private void WriteFooter(StreamWriter sw)
        {
            sw.Write(AddSpase(String.Empty, widthName));
            sw.Write(AddSpase(Employees.Sum(m => m.Salary).ToString("c"), widthSalary));
            sw.Write(AddSpase(String.Empty, widthSalary));
            sw.WriteLine(AddSpase(Employees.Sum(m => TaxSalary.ApplyTax(m.Salary)).ToString("c"), widthSalary));
        }

        private string AddSpase(string str, int count)
        {
            if (count - str.Length < 0)
                return str;
            return str + new string(' ', count - str.Length);
        }
    }
}