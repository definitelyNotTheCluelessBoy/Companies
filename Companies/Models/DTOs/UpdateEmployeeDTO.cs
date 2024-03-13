using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Companies.Models.DTOs
{
    public class UpdateEmployeeDTO
    {
        [EmailAddress]
        public string? EmailAddress { get; set; }
        [Phone]
        public string? Phone { get; set; }
        public string? Title { get; set; }

    }
}
