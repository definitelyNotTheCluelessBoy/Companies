using System.ComponentModel.DataAnnotations;
namespace Companies.Models.DTOs
{
    public class ProjectDTO
    {
        public string? Name { get; set; }
        public int? DirectorOfNodeId     { get; set; }
        public string? MotherDivisionIdCode { get; set; }
    }
}
