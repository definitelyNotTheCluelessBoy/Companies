using Companies.Database;
using Companies.Models.DTOs;
using Companies.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Companies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisionControler : ControllerBase
    {
        private readonly Context database;

        public DivisionControler(Context db)
        {
            this.database = db;
        }


        /// Method <c>GetDivisions</c> lists out all divisions stored in database.
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<DivisionDTO>> GetDivisons()
        {
            List<DivisionDTO> temp = new List<DivisionDTO>();

            foreach (var division in database.divisions)
            {
                temp.Add(new DivisionDTO { Name = division.Name, DirectorOfNodeId = division.DirectorOfNodeId, MotherCompanyIdCode = division.MotherCompanyId});
            }

            return Ok(temp);
        }

        /// Method <c>GetDivisionByIdCode</c> returns divion with provided ID code or error if division with such code doesn't exists.
        [HttpGet("{idCode}", Name = "GetDivisionByIdCode")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<DivisionDTO> GetDivisionByIdCode(string idCode)
        {

            var division = database.divisions.FirstOrDefault(n => n.IdCode.Equals(idCode));

            if (division == null)
            {
                return NotFound();
            }
            return Ok(division);
        }


        /// Method <c>GetProjectsOfDivision</c> lists out all projects that belong under division with provided Id code.
        [HttpGet("Projects/{idCode}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<ProjectDTO>> GetProjectsOfDivision(string idCode)
        {
            if (database.divisions.FirstOrDefault(n => n.IdCode == idCode) == null)
                return NotFound("Wrong Id!");

            List<ProjectDTO>? temp = new List<ProjectDTO>();

           
                
            foreach (var project in database.projects)
                {
                    if (project.MotherDivisionId.Equals(idCode))
                        temp.Add(new ProjectDTO { Name = project.Name, DirectorOfNodeId = project.DirectorOfNodeId, MotherDivisionIdCode = project.MotherDivisionId });

                }
                

            if (temp.Count == 0)
                return NotFound("No projects of division found.");


            return Ok(temp);
        }

        /// Method <c>GetDepartmentsOfDivision</c> lists out all departments that belong under division with provided Id code.
        [HttpGet("Departments/{idCode}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<DepartmentDTO>> GetDepartmentsOfDivision(string idCode)
        {
            if (database.divisions.FirstOrDefault(n => n.IdCode == idCode) == null)
                return NotFound("Wrong Id!");


            List<DepartmentDTO>? temp = new List<DepartmentDTO>();

            
                    foreach (var project in database.projects)
                    {
                        if (project.MotherDivisionId.Equals(idCode))
                        {
                            foreach (var department in database.departments)
                            {
                                if (department.MotherProjectId.Equals(project.IdCode))
                                    temp.Add(new DepartmentDTO { Name = department.Name, DirectorOfNodeId = department.DirectorOfNodeId, MotherProjectIdCode = department.MotherProjectId });
                            }
                        }
                    }


            if (temp.Count == 0)
                return NotFound("No departments of division found.");


            return Ok(temp);
        }

        /// Method <c>AddDivision</c> creates and adds new division to database or throws error if division with provided Id code allready exists.
        [HttpPost("{newIdCode}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Division> AddDivision(string newIdCode, DivisionDTO divisionDto)
        {
            if (database.divisions.FirstOrDefault(n => n.IdCode == newIdCode) != null)
                return BadRequest("Division with this Id allready exists!");

            if (database.employees.FirstOrDefault(n => n.Id == divisionDto.DirectorOfNodeId) == null)
                return BadRequest("Employee doesn't exists!");

            Division division = new Division{
                IdCode = newIdCode,
                Name = divisionDto.Name,
                DirectorOfNodeId = divisionDto.DirectorOfNodeId,
                DirectorOfNode = database.employees.FirstOrDefault(n => n.Id == divisionDto.DirectorOfNodeId),
                MotherCompanyId = divisionDto.MotherCompanyIdCode,
                MotherCompany = database.companies.FirstOrDefault(n => n.IdCode.Equals(divisionDto.MotherCompanyIdCode))
            };

            database.divisions.Add(division);

            database.SaveChanges();

            return CreatedAtRoute("GetDivisionsByIdCode", new { idCode = division.IdCode }, division);
        }

        /// Method <c>DeleteDivision</c> deletes division with provided Id code.
        [HttpDelete("{IdCode}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<Division> DeleteDivision(string IdCode)
        {
            var division = database.divisions.FirstOrDefault(n => n.IdCode == IdCode);

            if (division == null)
                return NotFound();

            database.divisions.Remove(division);
            database.SaveChanges();

            return NoContent();
        }

        /// Method <c>ModifieDivisionName</c> changes name of division with provided Id code.
        [HttpPut("UpdateName/{IdCode}/{newName}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<Division> ModifieDivisionName(string IdCode, string newName)
        {
            var division = database.divisions.FirstOrDefault(n => n.IdCode == IdCode);

            if (division == null)
                return NotFound();

            division.Name = newName;

            database.SaveChanges();

            return NoContent();
        }

        /// Method <c>ModifieDivisionName</c> changes director of division with provided Id code if such person exist in database.
        [HttpPut("UpdateDirector/{IdCode}/{newDirectorOfNodeId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<Division> ModifieDivisionDirector(string IdCode, int newDirectorOfNodeId)
        {
            var division = database.divisions.FirstOrDefault(n => n.IdCode == IdCode);

            if (division == null)
                return NotFound();

            if (database.employees.FirstOrDefault(n => n.Id == newDirectorOfNodeId) == null)
                return NotFound("Employee doesn't exists!");

            division.DirectorOfNodeId = newDirectorOfNodeId;


            database.SaveChanges();

            return NoContent();
        }
    }
}
