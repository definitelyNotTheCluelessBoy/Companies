using Companies.Database;
using Companies.Models.DTOs;
using Companies.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Companies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentControler : ControllerBase
    {
        private readonly Context database;

        public DepartmentControler(Context db)
        {
            this.database = db;
        }


        /// Method <c>GetDepartment</c> lists out all departments stored in database.
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<DepartmentDTO>> GetDepartments()
        {
            List<DepartmentDTO> temp = new List<DepartmentDTO>();

            foreach (var department in database.departments)
            {
                temp.Add(new DepartmentDTO { Name = department.Name, DirectorOfNodeId = department.DirectorOfNodeId, MotherProjectIdCode = department.MotherProjectId });
            }

            return Ok(temp);
        }

        /// Method <c>GetDepartmentByIdCode</c> returns department with provided ID code or error if department with such code doesn't exists.
        [HttpGet("{idCode}", Name = "GetDepartmentByIdCode")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Department> GetDepartmentByIdCode(string idCode)
        {

            var department = database.departments.FirstOrDefault(n => n.IdCode.Equals(idCode));

            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }


        /// Method <c>AddDepartment</c> creates and adds new department to database or throws error if department with provided Id code allready exists.
        [HttpPost("{newIdCode}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Department> AddDepartment(string newIdCode, DepartmentDTO departmentDto)
        {
            if (database.departments.FirstOrDefault(n => n.IdCode == newIdCode) != null)
                return BadRequest("Department with this Id allready exists!");

            if (database.employees.FirstOrDefault(n => n.Id == departmentDto.DirectorOfNodeId) == null)
                return BadRequest("Employee doesn't exists!");

            Department department = new Department
            {
                IdCode = newIdCode,
                Name = departmentDto.Name,
                DirectorOfNodeId = departmentDto.DirectorOfNodeId,
                DirectorOfNode = database.employees.FirstOrDefault(n => n.Id == departmentDto.DirectorOfNodeId),
                MotherProjectId = departmentDto.MotherProjectIdCode,
                MotherProject = database.projects.FirstOrDefault(n => n.IdCode.Equals(departmentDto.MotherProjectIdCode))
            };

            database.departments.Add(department);

            database.SaveChanges();

            return CreatedAtRoute("GetDepartmentByIdCode", new { idCode = department.IdCode }, department);
        }

        /// Method <c>DeleteDepartment</c> deletes department with provided Id code.
        [HttpDelete("{IdCode}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<Department> DeleteDepartment(string IdCode)
        {
            var department = database.departments.FirstOrDefault(n => n.IdCode == IdCode);

            if (department == null)
                return NotFound();

            database.departments.Remove(department);
            database.SaveChanges();

            return NoContent();
        }

        /// Method <c>ModifieDepartmentName</c> changes name of department with provided Id code.
        [HttpPut("UpdateName/{IdCode}/{newName}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<Department> ModifieDepartmentName(string IdCode, string newName)
        {
            var department = database.departments.FirstOrDefault(n => n.IdCode == IdCode);

            if (department == null)
                return NotFound();

            department.Name = newName;

            database.SaveChanges();

            return NoContent();
        }

        /// Method <c>ModifieDepartmentName</c> changes director of department with provided Id code if such person exist in database.
        [HttpPut("UpdateDirector/{IdCode}/{newDirectorOfNodeId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<Department> ModifieDepartmentDirector(string IdCode, int newDirectorOfNodeId)
        {
            var department = database.departments.FirstOrDefault(n => n.IdCode == IdCode);

            if (department == null)
                return NotFound();

            if (database.employees.FirstOrDefault(n => n.Id == newDirectorOfNodeId) == null)
                return NotFound("Employee doesn't exists!");

            department.DirectorOfNodeId = newDirectorOfNodeId;

            database.SaveChanges();

            return NoContent();
        }
    }
}
