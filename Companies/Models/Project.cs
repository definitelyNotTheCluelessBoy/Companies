using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Companies.Models
{
    public class Project
    {
        [Key]
        public required string IdCode { get; set; }
        public required string Name { get; set; }
        [ForeignKey(nameof(DirectorOfNodeId))]
        public int? DirectorOfNodeId { get; set; }
        public Employee? DirectorOfNode { get; set; }
        public const string type = "Project";
        [ForeignKey(nameof(MotherDivisionId))]
        public required Division MotherDivision { get; set; }
        public required string MotherDivisionId { get; set; }
        public List<Department>? ListOdDepartments { get; set; }
    }
}
