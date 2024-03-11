using Companies.Database;
using Companies.Models;
using Companies.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Companies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesControler : ControllerBase
    {
        private readonly Context database;

        public EmployeesControler(Context db)
        {
            this.database = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EmployeeDTO>> GetEmployees()
        {
            return Ok(database.employees);
        }

        [HttpGet("{id}", Name = "GetEmployee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<EmployeeDTO> GetEmployee(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var employee = database.employees.FirstOrDefault(n => n.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<EmployeeDTO> CreateEmployee([FromBody] EmployeeDTO employeeDTO)
        {
            if (employeeDTO == null)
            {
                return BadRequest(employeeDTO);
            }

            Employee employee = new()
            {
                FirstName = employeeDTO.FirstName,
                LastName = employeeDTO.LastName,
                Email = employeeDTO.Email,
                Phone = employeeDTO.Phone,
                Title = employeeDTO.Title,
            };

            database.employees.Add(employee);
            database.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteEmployee(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            var employee = database.employees.FirstOrDefault(n => n.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            database.employees.Remove(employee);
            database.SaveChanges();
            return NoContent();
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateEmployee(int id, [FromBody] UpdateEmployeeDTO update)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var employee = database.employees.FirstOrDefault(n => n.Id == id);

            if (employee == null)
            {
                return NotFound();
            }

            if (update.EmailAddress != "")
                if (new EmailAddressAttribute().IsValid(update.EmailAddress))
                    employee.Email = update.EmailAddress;

            if (update.Phone != "")
                employee.Phone = update.Phone;

            if (update.Title != "")
                employee.Title = update.Title;

            database.SaveChanges();

            return NoContent();
        }


    }
}