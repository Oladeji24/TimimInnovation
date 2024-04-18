using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimimInnovation.Models
{
    public class TermAndCondition
    {
        [Key]
        public int TermAndConditionId { get; set; }

        [StringLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        public string? Title { get; set; }

        [StringLength(150)]
        [Column(TypeName = "nvarchar(150)")]
        public string? ClientUsername { get; set; }

        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string? ClientFirstName { get; set; }

        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string? ClientLastName { get; set; }

        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string? Continent { get; set; }

        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string? Country { get; set; }

        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string? CountryState { get; set; }

        [StringLength(2000)]
        [Column(TypeName = "nvarchar(5000)")]
        public string? TermAndConditionText { get; set; }

        public bool Agreement { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime SignDate { get; set; } = DateTime.Now;

        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
    }
}
