using Microsoft.AspNetCore.Mvc;
using Testing.Interfaces;
using Testing.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Testing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public List<Employee> Get()
        {
            return _employeeRepository.GetAllEmployee();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public string Post([FromQuery] Employee value)
        {
            string message = _employeeRepository.AddEmployee(value);
            return message;
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("Update")]
        public string Put([FromQuery] string value, int id)
        {
            return _employeeRepository.UpdateEmployee(value, id);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("Delete")]
        public string Delete([FromQuery] int id)
        {
            string message = _employeeRepository.DeleteEmployee(id);
            return message;
        }
    }
}
