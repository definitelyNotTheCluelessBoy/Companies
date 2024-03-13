using System.ComponentModel.DataAnnotations;

namespace Companies.Models.DTOs
{
    public class DepartmentDTO
    {
        public string? Name { get; set; }
        public int? DirectorOfNodeId { get; set; }
        public string? MotherProjectIdCode { get; set; }
    }
}
