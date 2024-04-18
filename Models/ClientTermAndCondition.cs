using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimimInnovation.Models
{
    public class ClientTermAndCondition
    {
        [Key]
        public int ClientTermAndConditionId { get; set; }

        [StringLength(150)]
        [Column(TypeName = "nvarchar(150)")]
        public string? ClientTermAndConditionUsername { get; set; }

        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string? ClientTermAndConditionFirstName { get; set; }

        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string? ClientTermAndConditionLastname { get; set; }

        [StringLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        public string? ClientTermAndConditionDecision { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime SignDate { get; set; } = DateTime.Now;

        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
    }
}
