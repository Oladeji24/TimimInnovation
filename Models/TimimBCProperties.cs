using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimimInnovation.Models
{
    public class TimimBCProperties
    {
        // Primary key
        [Key]
        public int PropertyId { get; set; }

        // Strings with attributes
        [Required]
        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string? Username { get; set; }

        [Required]
        [StringLength(11)]
        [Column(TypeName = "nvarchar(100)")]
        public string NIN { get; set; }

        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string? PropertyName { get; set; }

        // Enums
        [Required]
        public PropertyType PropertyType { get; set; }
        [Required]
        public TransactionPurpose TransactionPurpose { get; set; }
        [Required]
        public TransactionStatus TransactionStatus { get; set; }
        // Strings related to the property details
        [Required]
        [StringLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public string? PropertyCode { get; set; }

        [Required]
        [StringLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public string? TransactionCode { get; set; }

        // Property features (integers)
        public int NoOfLivingRoom { get; set; }
        public int NoOfBedrooms { get; set; }
        public int NoOfBathrooms { get; set; }
        public int NoOfFloors { get; set; }
        public string? PropertySize { get; set; }

        // Strings related to location
        [Required]
        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string? Street { get; set; }

        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string? LocalGovernmentArea { get; set; }

        [Required]
        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string? City { get; set; }

        [Required]
        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string? State { get; set; }

        [Required]
        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string? Country { get; set; }

        // Pricing
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? MaintenanceCost { get; set; }

        [StringLength(20)]
        [Column(TypeName = "nvarchar(20)")]
        public string? ZipCode { get; set; }

        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string? NearestLandmark { get; set; }

        // Booleans for features
        public bool HasGarage { get; set; }
        public bool HasSwimmingPool { get; set; }
        public bool HasGarden { get; set; }
        public bool HasBalcony { get; set; }
        public bool IsVerified { get; set; }
        public bool Negotiable { get; set; }  

        // Other attributes
        public bool WaterSupply { get; set; }
        public bool PowerBackup { get; set; }

        [StringLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public string? FacingDirection { get; set; }

        [StringLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        public string? View { get; set; }

        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string? LegalStatus { get; set; }

        [StringLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        public string? PublicTransitAccess { get; set; }

        [StringLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        public string? VirtualTourLink { get; set; }

        [StringLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        public string? VideoLink { get; set; }

        public string? RegisterPersonnelCode { get; set; }

        [StringLength(15)]
        [Column(TypeName = "nvarchar(15)")]
        public string? ContactNumber { get; set; }

        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string? ContactEmail { get; set; }

        // Strings for property images and description
        [StringLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        public string? PropertyImage1 { get; set; }

        [StringLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        public string? PropertyImage2 { get; set; }

        [StringLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        public string? PropertyImage3 { get; set; }

        [StringLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        public string? Description { get; set; }

        [StringLength(500)]
        [Column(TypeName = "nvarchar(500)")]
        public string? DocumentOnProperty { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
    public enum TransactionPurpose
    {
        Sale,
        Rent,
        Shortlet
    }

    public enum TransactionStatus
    {
        Available,
        NotAvailable
    }

    public enum PropertyType
    {
        Apartments,
        Villa,
        Home,
        Office,
        Building,
        Townhouse,
        Shop,
        Garage
    }

}
