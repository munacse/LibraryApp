using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryApp.DataAccess;
using LibraryApp.Mongo.Interfaces;
using LibraryApp.Mongo.Model;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Web.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWorkMongo _unitOfWorkMongo;

        public EmployeeController(IUnitOfWorkMongo unitOfWorkMongo)
        {
            _unitOfWorkMongo = unitOfWorkMongo;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAuthor()
        {
            var employees = await _unitOfWorkMongo.EmployeeRepository.GetAllEmployees();

            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]  Employee employee)
        {

            employee.Id = "2";
            await _unitOfWorkMongo.EmployeeRepository.AddEmployee(employee);

            return Created($"api/Employee/{employee}",employee);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var employee = _unitOfWorkMongo.EmployeeRepository.GetEmployee(id);
            return Ok(employee);
        }
    }
}