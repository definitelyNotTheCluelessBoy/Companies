using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Companies.Models
{
    public class Division
    {
        [Key]
        public required string IdCode { get; set; }
        public required string Name { get; set; }
        [ForeignKey(nameof(DirectorOfNodeId))]
        public int? DirectorOfNodeId { get; set; }
        public Employee? DirectorOfNode { get; set; }
        public const string type = "Division";
        [ForeignKey(nameof(MotherCompanyId))]
        public required Company MotherCompany { get; set; }
        public required string MotherCompanyId { get; set; }
        public List<Project>? listOfProjects { get; set; }
    }
}
