using System.ComponentModel.DataAnnotations.Schema;

namespace Companies.Models.DTOs
{
    public class CompanyDTO
    {
        public string? Name { get; set; }
        public int? DirectorOfNodeId { get; set; }
    }
}
