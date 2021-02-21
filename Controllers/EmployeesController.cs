using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entity;
using Bussines;
using System.Net;
using Promart_Crud.Models.Request;
using Promart_Crud.Models.Response;
using Promart_Crud.Models;
namespace Promart_Crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();
            oRespuesta.Exito = 0;
            try
            {

                using (promartContext db = new promartContext())
                {
                    var lst = db.Employees.ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lst;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }
        [HttpPost]
        public IActionResult Add(EmployeeRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            string modo = "I";
            try
            {
                
                    EEmployees oEmployees = new EEmployees();
                    oEmployees.EmployeeName = oModel.EmployeeName;
                    oEmployees.EmployeeSalary = oModel.EmployeeSalary;
                    oEmployees.EmployeeAge = oModel.EmployeeAge;
                    BEmployees.crud(modo, oEmployees);
                    oRespuesta.Exito = 1;
                
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }
        [HttpPut]
        public IActionResult Edit(EmployeeRequest oModel)
        {
            Respuesta oRespuesta = new Respuesta();
            string modo;
            try
            {
                
                    EEmployees oEmployees = BEmployees.Getemployee(modo = "L", oModel.Id); 
                    oEmployees.EmployeeName = oModel.EmployeeName;
                    oEmployees.EmployeeSalary = oModel.EmployeeSalary;
                    oEmployees.EmployeeAge = oModel.EmployeeAge;
                    BEmployees.crud(modo="U", oEmployees);
                    oRespuesta.Exito = 1;
                
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }
    }
}
