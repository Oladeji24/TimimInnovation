using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimimInnovation.Models
{
    public class ClientConcord
    {
        [Key]
        public int ClientConcordId { get; set; }

        public ServiceType? ClientConcordServiceType { get; set; }

        [StringLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        public string? ClientConcordTitle { get; set; }

        [StringLength(2000)]
        [Column(TypeName = "nvarchar(2000)")]
        public string? ClientConcordText { get; set; }

        public enum ServiceType
        {
            Sales,
            Rent,
            Shortage,
            Booking
        }
    }
}
