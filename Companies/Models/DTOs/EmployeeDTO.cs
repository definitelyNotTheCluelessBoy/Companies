using System.ComponentModel.DataAnnotations;

namespace Companies.Models.DTOs
{
    public class EmployeeDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Phone]
        [Required]
        public string Phone { get; set; }
        public string Title { get; set; }
    }
}
