using System;
using System.ComponentModel.DataAnnotations;

namespace prog6212_part3_ST10456157.Models
{
    public class LecturerClaim
    {
        [Key]
        public int ClaimId { get; set; }

        [Required]
        public string LecturerName { get; set; }

        [Required]
        public int HoursWorked { get; set; }

        [Required]
        public decimal HourlyRate { get; set; }

        // Auto-calculated
        public decimal TotalAmount { get; set; }

        // Required for workflow
        public string Status { get; set; } = "Pending";

        // Workflow timestamps (nullable)
        public DateTime? DateSubmitted { get; set; }
        public DateTime? DateVerified { get; set; }
        public DateTime? DateApproved { get; set; }

        // File upload
        public string? DocumentName { get; set; }
    }
}


