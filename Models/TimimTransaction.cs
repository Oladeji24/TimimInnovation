using System.ComponentModel.DataAnnotations;

namespace TimimInnovation.Models
{
    public class TimimTransaction
    {
        [Key]
        public int TransactionId { get; set; }

        // User Details
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        [EnumDataType(typeof(Gender))]
        public Gender Sex { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string WhatsAppNumber { get; set; }
        [Phone]
        public string MobileNumber { get; set; }

        // Identification
        public string NIN { get; set; }
        public string OtherMeansOfIdentification { get; set; }
        public string IdentificationNumber { get; set; }

        // Transaction Details
        public string TransactionCode { get; set; }
        public string PropertyCode { get; set; }
        [EnumDataType(typeof(PaymentStatus))]
        public PaymentStatus PaymentStatus { get; set; }
        [EnumDataType(typeof(PaymentMethod))]
        public PaymentMethod PaymentMethod { get; set; }
        public string ReceiptNo { get; set; }

        // Property Details
        public string PropertyName { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; } = DateTime.Now;
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; } = DateTime.Now;

        // Date Details
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [DataType(DataType.Date)]
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

    }

    public enum Gender
    {
        Male,
        Female,
        Other
    }

    public enum PaymentStatus
    {
        Pending=1,
        Completed=2,
        NonCompleted=3
    }

    public enum PaymentMethod
    {
        Cash,
        Bank,
        Card,
        Crypto,
        Cheque,
        Transfer
    }
}
