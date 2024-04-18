using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TimimInnovation.Models
{
    public class TenantComplain
    {
        // Primary key
        [Key]
        public int TenantComplainId { get; set; }

        // Strings with attributes
        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string? TenantName { get; set; }

        [StringLength(15)]
        [Column(TypeName = "nvarchar(15)")]
        public string? TenantPhoneNumber { get; set; }

        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string? TenantEmail { get; set; }

        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string? PropertyAddress { get; set; }

        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string? LandLordtFullName { get; set; }

        [StringLength(15)]
        [Column(TypeName = "nvarchar(15)")]
        public string? LandLoordNumber { get; set; }

        [StringLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        public string? TenantComplainText { get; set; }

        // Date property
        public DateTime ComplainDate { get; set; }

    }
}
