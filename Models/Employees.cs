using System;
using System.Collections.Generic;

namespace Promart_Crud.Models
{
    public partial class Employees
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public decimal? EmployeeSalary { get; set; }
        public int? EmployeeAge { get; set; }
    }
}
