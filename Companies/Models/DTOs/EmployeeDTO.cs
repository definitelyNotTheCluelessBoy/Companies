using System.ComponentModel.DataAnnotations;

namespace Companies.Models.DTOs
{
    public class EmployeeDTO
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        [EmailAddress]
        public required string Email { get; set; }
        [Phone]
        public required string Phone { get; set; }
        public string? Title { get; set; }
        public string? CompanyNodeID { get; set; }
    }
}
