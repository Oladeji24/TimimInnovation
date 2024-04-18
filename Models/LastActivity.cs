using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimimInnovation.Models
{
    public class LastActivity
    {
        [Key]
        public int LastActivityId { get; set; }

        [Required]
        public string? Username { get; set; }

        [Required]
        public DateTime LastSeen { get; set; } = DateTime.Now;
    }
}
