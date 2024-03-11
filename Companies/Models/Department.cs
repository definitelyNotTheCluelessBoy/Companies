using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Companies.Models
{
    public class Department
    {
        [Key]
        public required string IdCode { get; set; }
        [Required]
        public required string Name { get; set; }
        [ForeignKey(nameof(DirectorOfNodeId))]
        public int? DirectorOfNodeId { get; set; }
        public Employee? DirectorOfNode { get; set; }
        public const string type = "Department";
        public required Project MotherProject { get; set; }
        public required string MotherProjectId { get; set; }
    }
}
