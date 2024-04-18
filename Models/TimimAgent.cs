using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimimInnovation.Models
{
    public class TimimAgent
    {
        [Key]
        public int AgentId { get; set; }

        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string? LastName { get; set; }

        [Required]
        [StringLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public string? AgentCode { get; set; }

        [StringLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        public string? Picture { get; set; }

        [Required]
        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string? Email { get; set; }

        [Required]
        [StringLength(20)]
        [Column(TypeName = "nvarchar(20)")]
        public string? PhoneNumber { get; set; }

        [StringLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public string? PropertyCode { get; set; }

        [StringLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public string? TransactionCode { get; set; }

        [StringLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public string? Commission { get; set; }

        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string? AgencyName { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Column(TypeName = "datetime")]
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        // ... Add more properties as needed
    }
}
