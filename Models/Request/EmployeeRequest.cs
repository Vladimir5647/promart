using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promart_Crud.Models.Request
{
    public class EmployeeRequest
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public decimal? EmployeeSalary { get; set; }
        public int? EmployeeAge { get; set; }
    }
}
