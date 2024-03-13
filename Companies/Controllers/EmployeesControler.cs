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


        /// Method <c>GetEmployees</c> returns all employees.
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<EmployeeDTO>> GetEmployees()
        {
            return Ok(database.employees);
        }

        /// Method <c>GetEmployees</c> returns employee with provided id.
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

        /// Method <c>CreateEmployee</c> adds employees to database.
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
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

            return Ok(employee);
        }


        /// Method <c>DeleteEmployee</c> deletes employee with provided id.
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

        /// Method <c>UpdateEmployeePhone</c> updates phone number of employee with provided Id.
        [HttpPut("UpdatePhone/{id}/{newPhone}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateEmployeePhone(int id, [Phone] string newPhone)
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

            
            employee.Phone = newPhone;

            database.SaveChanges();

            return NoContent();
        }

        /// Method <c>UpdateEmployeeEmail</c> updates phone number of employee with provided Id.
        [HttpPut("UpdateEmail/{id}/{newEmail}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateEmployeeEmail(int id, [EmailAddress] string newEmail)
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


            employee.Email = newEmail;

            database.SaveChanges();

            return NoContent();
        }

        [HttpPut("UpdateTitle/{id}/{newTitle}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateEmployee(int id, string newTitle)
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


            employee.Title = newTitle;

            database.SaveChanges();

            return NoContent();
        }


    }
}