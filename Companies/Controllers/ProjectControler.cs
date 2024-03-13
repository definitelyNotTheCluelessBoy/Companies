using Companies.Database;
using Companies.Models.DTOs;
using Companies.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Companies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectControler : ControllerBase
    {
        private readonly Context database;

        public ProjectControler(Context db)
        {
            this.database = db;
        }


        /// Method <c>GetProjects</c> lists out all projects stored in database.
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<ProjectDTO>> GetProjects()
        {
            List<ProjectDTO> temp = new List<ProjectDTO>();

            foreach (var project in database.projects)
            {
                temp.Add(new ProjectDTO { Name = project.Name, DirectorOfNodeId = project.DirectorOfNodeId, MotherDivisionIdCode = project.MotherDivisionId });
            }

            return Ok(temp);
        }

        /// Method <c>GetProjectByIdCode</c> returns project with provided ID code or error if project with such code doesn't exists.
        [HttpGet("{idCode}", Name = "GetProjectByIdCode")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ProjectDTO> GetProjectByIdCode(string idCode)
        {

            var project = database.projects.FirstOrDefault(n => n.IdCode.Equals(idCode));

            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        /// Method <c>GetDepartmentsOfProject</c> lists out all departments that belong under project with provided Id code.
        [HttpGet("Departments/{idCode}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<DepartmentDTO>> GetDepartmentsOfProject(string idCode)
        {
            if (database.projects.FirstOrDefault(n => n.IdCode == idCode) == null)
                return NotFound("Wrong Id!");


            List<DepartmentDTO>? temp = new List<DepartmentDTO>();


            foreach (var department in database.departments)
            {
                if (department.MotherProjectId.Equals(idCode))
                {
                     temp.Add(new DepartmentDTO { Name = department.Name, DirectorOfNodeId = department.DirectorOfNodeId, MotherProjectIdCode = department.MotherProjectId });
                }
            }


            if (temp.Count == 0)
                return NotFound("No departments of project found.");


            return Ok(temp);
        }

        /// Method <c>AddProject</c> creates and adds new project to database or throws error if project with provided Id code allready exists.
        [HttpPost("{newIdCode}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Project> AddProject(string newIdCode, ProjectDTO projectDto)
        {
            if (database.projects.FirstOrDefault(n => n.IdCode == newIdCode) != null)
                return BadRequest("Project with this Id allready exists!");

            if (database.employees.FirstOrDefault(n => n.Id == projectDto.DirectorOfNodeId) == null)
                return BadRequest("Employee doesn't exists!");

            Project project = new Project
            {
                IdCode = newIdCode,
                Name = projectDto.Name,
                DirectorOfNodeId = projectDto.DirectorOfNodeId,
                DirectorOfNode = database.employees.FirstOrDefault(n => n.Id == projectDto.DirectorOfNodeId),
                MotherDivisionId = projectDto.MotherDivisionIdCode,
                MotherDivision = database.divisions.FirstOrDefault(n => n.IdCode.Equals(projectDto.MotherDivisionIdCode))
            };

            database.projects.Add(project);

            database.SaveChanges();

            return CreatedAtRoute("GetProjectsByIdCode", new { idCode = project.IdCode }, project);
        }

        /// Method <c>DeleteProject</c> deletes project with provided Id code.
        [HttpDelete("{IdCode}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<Project> DeleteProject(string IdCode)
        {
            var project = database.projects.FirstOrDefault(n => n.IdCode == IdCode);

            if (project == null)
                return NotFound();

            database.projects.Remove(project);
            database.SaveChanges();

            return NoContent();
        }

        /// Method <c>ModifieProjectName</c> changes name of project with provided Id code.
        [HttpPut("UpdateName/{IdCode}/{newName}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<Project> ModifieProjectName(string IdCode, string newName)
        {
            var project = database.projects.FirstOrDefault(n => n.IdCode == IdCode);

            if (project == null)
                return NotFound();

            project.Name = newName;

            database.SaveChanges();

            return NoContent();
        }

        /// Method <c>ModifieProjectName</c> changes director of project with provided Id code if such person exist in database.
        [HttpPut("UpdateDirector/{IdCode}/{newDirectorOfNodeId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<Project> ModifieProjectDirector(string IdCode, int newDirectorOfNodeId)
        {
            var project = database.projects.FirstOrDefault(n => n.IdCode == IdCode);

            if (project == null)
                return NotFound();

            if (database.employees.FirstOrDefault(n => n.Id == newDirectorOfNodeId) == null)
                return NotFound("Employee doesn't exists!");

            project.DirectorOfNodeId = newDirectorOfNodeId;


            database.SaveChanges();

            return NoContent();
        }
    }
}
