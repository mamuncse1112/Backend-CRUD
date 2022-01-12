using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication3.Model;
using WebApplication3.Repository.Contracts;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {

       

        public readonly IEmployeeRepository _repository;

        public HomeController(IEmployeeRepository repository)
        {
            _repository = repository;
        }
        
        [HttpPost]

        public JsonResult SaveEmp([FromBody] Employee employee)
        {
            var employees = _repository.Save(employee);
            return Json(employees);

        }
        [HttpGet]
        [EnableCors("AllowOrigin")]
        public List<Employee> GetAllEmployee()
        {
            List<Employee> employees = _repository.Gets().ToList();
            return employees;

        }
        [HttpPost]
        public JsonResult DeleteEmployee([FromBody] DeleteEmployee deleteEmployee)
        {

            var delEmp = _repository.Delete(deleteEmployee.Id);
            return Json(delEmp);
        }
    }
}
