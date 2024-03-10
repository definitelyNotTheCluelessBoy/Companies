using System.ComponentModel.DataAnnotations;

namespace Companies.Models.DTOs
{
    public class UpdateEmployeeDTO
    {
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        public string Title { get; set; }
    }
}
