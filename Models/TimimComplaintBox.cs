using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimimInnovation.Models
{
    public class TimimComplaintBox
    {
        // Primary key
        [Key]
        public int TimimComplaintBoxId { get; set; }

        // Strings with attributes
        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string? PropertyOwnerName { get; set; }

        [StringLength(15)]
        [Column(TypeName = "nvarchar(15)")]
        public string? PropertyOwnerPhoneNumber { get; set; }

        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string? PropertyOwnerEmail { get; set; }

        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string? PropertyAddress { get; set; }

        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string? TenantFullName { get; set; }

        [StringLength(15)]
        [Column(TypeName = "nvarchar(15)")]
        public string? TenantPhoneNumber { get; set; }

        [StringLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        public string? Complain { get; set; }

        // Date property
        public DateTime ComplainDate { get; set; }

    }
}
