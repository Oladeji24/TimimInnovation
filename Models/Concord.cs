using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimimInnovation.Models
{
    public class Concord
    {
        [Key]
        public int ConcordId { get; set; }

        [StringLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        public string? ConcordTitle { get; set; }

        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string? ConcordContinent { get; set; }

        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string? ConcordCountry { get; set; }

        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string? ConcordState { get; set; }

        [StringLength(2000)]
        [Column(TypeName = "nvarchar(5000)")]
        public string? ConcordText { get; set; }
    }
}
