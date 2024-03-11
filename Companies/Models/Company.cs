using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Companies.Models
{
    public class Company
    {
        [Key]
        public required string IdCode { get; set; }
        public required string Name { get; set; }
        [ForeignKey(nameof(DirectorOfNodeId))]
        public int? DirectorOfNodeId { get; set; }
        public Employee? DirectorOfNode { get; set; }
        public const string type = "Company";
        public List<Division>? divisionsOfCompany {  get; set; } 
    }
}
