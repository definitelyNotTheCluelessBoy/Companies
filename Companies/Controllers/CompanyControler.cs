using Companies.Database;
using Companies.Models;
using Companies.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Companies.Controllers
{

    /// Class <c>CompanyControler</c> is derived from <c>ControllerBase</c> and its main purpose is to control Company entities in API.
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyControler : ControllerBase
    {
        private readonly Context database;

        public CompanyControler(Context db)
        {
            this.database = db;
        }

       
        /// Method <c>GetCompanies</c> lists out all companies stored in database.
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<CompanyDTO>> GetCompanies()
        {
            List<CompanyDTO> temp = new List<CompanyDTO>();

            foreach (var company in database.companies)
            {
                  temp.Add(new CompanyDTO { Name = company.Name, DirectorOfNodeId = company.DirectorOfNodeId });
            }

            return Ok(temp);
        }

        /// Method <c>GetCompanyByIdCode</c> returns company with provided ID code or error if company with such code doesn't exists.
        [HttpGet("{idCode}" , Name = "GetCompanyByIdCode")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Company> GetCompanyByIdCode(string idCode)
        {

            var company = database.companies.FirstOrDefault(n=>n.IdCode.Equals(idCode));

            if (company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }

        /// Method <c>GetDivisionsOfCompany</c> lists out all divisons that belong under company with provided Id code.
        [HttpGet("Divisions/{idCode}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<DivisionDTO>> GetDivisionsOfCompany(string idCode)
        {
            if (database.companies.FirstOrDefault(n => n.IdCode == idCode) == null)
                return NotFound("Wrong Id!");
            

            List<DivisionDTO>? temp = new List<DivisionDTO>();

            foreach (var division in database.divisions)
            {
                if (division.MotherCompanyId.Equals(idCode))
                    temp.Add(new DivisionDTO { Name = division.Name, DirectorOfNodeId = division.DirectorOfNodeId, MotherCompanyIdCode = division.MotherCompanyId });
            }
            

            if (temp.Count == 0)
                return NotFound("No divisions of company found.");
            

            return Ok(temp);
        }

        /// Method <c>GetProjectsOfCompany</c> lists out all projects that belong under company with provided Id code.
        [HttpGet("Projects/{idCode}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<ProjectDTO>> GetProjectsOfCompany(string idCode)
        {
            if (database.companies.FirstOrDefault(n => n.IdCode == idCode) == null)
                return NotFound("Wrong Id!");

            List<ProjectDTO>? temp = new List<ProjectDTO>();

            foreach (var division in database.divisions)
            {
                if (division.MotherCompanyId.Equals(idCode))
                {
                    foreach (var project in database.projects)
                    {
                        if(project.MotherDivisionId.Equals(division.IdCode))
                            temp.Add(new ProjectDTO { Name = project.Name, DirectorOfNodeId = project.DirectorOfNodeId, MotherDivisionIdCode = project.MotherDivisionId });

                    }
                }
            }

            if (temp.Count == 0)
                return NotFound("No projects of company found.");


            return Ok(temp);
        }

        /// Method <c>GetDepartmentsOfCompany</c> lists out all departments that belong under company with provided Id code.
        [HttpGet("Departments/{idCode}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<DepartmentDTO>> GetDepartmentsOfCompany(string idCode)
        {
            if (database.companies.FirstOrDefault(n => n.IdCode == idCode) == null)
                return NotFound("Wrong Id!");


            List<DepartmentDTO>? temp = new List<DepartmentDTO>();

            foreach (var division in database.divisions)
            {
                if (division.MotherCompanyId.Equals(idCode))
                {
                    foreach (var project in database.projects)
                    {
                        if (project.MotherDivisionId.Equals(division.IdCode)) 
                        {
                            foreach (var department in database.departments)
                            {
                                if (department.MotherProjectId.Equals(project.IdCode))
                                    temp.Add(new DepartmentDTO { Name = department.Name, DirectorOfNodeId = department.DirectorOfNodeId, MotherProjectIdCode = department.MotherProjectId });
                            }
                        }
                    }
                }
            }


            if (temp.Count == 0)
                return NotFound("No departments of company found.");


            return Ok(temp);
        }

        /// Method <c>AddCompany</c> creates and adds new company to database or throws error if company with provided Id code allready exists.
        [HttpPost("{newIdCode}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Company> AddCompany(string newIdCode,CompanyDTO companyDto)
        {
            if (database.companies.FirstOrDefault(n => n.IdCode == newIdCode) != null)
                return BadRequest("Company with this Id allready exists!");

            if (database.employees.FirstOrDefault(n=> n.Id == companyDto.DirectorOfNodeId) == null)
                return BadRequest("Employee doesn't exists!");

            Company company = new Company { IdCode = newIdCode, Name =  companyDto.Name, DirectorOfNodeId = companyDto.DirectorOfNodeId, 
            DirectorOfNode = database.employees.FirstOrDefault(n=>n.Id==companyDto.DirectorOfNodeId)}; 

            database.companies.Add(company);

            database.SaveChanges();
            
            return CreatedAtRoute("GetCompanyByIdCode", new { idCode = company.IdCode }, company);
        }

        /// Method <c>DeleteCompany</c> deletes company with provided Id code.
        [HttpDelete("{IdCode}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<Company> DeleteCompany(string IdCode) 
        {
            var company = database.companies.FirstOrDefault(n => n.IdCode==IdCode);
            
            if (company == null)
                return NotFound();

            database.companies.Remove(company);
            database.SaveChanges();

            return NoContent();
        }

        /// Method <c>ModifieCompanyName</c> changes name of company with provided Id code.
        [HttpPut("UpdateName/{IdCode}/{newName}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<Company> ModifieCompanyName(string IdCode, string newName) 
        {
            var company = database.companies.FirstOrDefault(n => n.IdCode == IdCode);

            if (company == null)
                return NotFound();

            company.Name = newName;

            database.SaveChanges();

            return NoContent();
        }

        /// Method <c>ModifieCompanyName</c> changes director of company with provided Id code if such person exist in database.
        [HttpPut("UpdateDirector/{IdCode}/{newDirectorOfNodeId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<Company> ModifieCompanyDirector(string IdCode, int newDirectorOfNodeId)
        {
            var company = database.companies.FirstOrDefault(n => n.IdCode == IdCode);

            if (company == null)
                return NotFound();

            if (database.employees.FirstOrDefault(n => n.Id == newDirectorOfNodeId) == null)
                return NotFound("Employee doesn't exists!");

            company.DirectorOfNodeId = newDirectorOfNodeId;


            database.SaveChanges();

            return NoContent();
        }

    }
}
