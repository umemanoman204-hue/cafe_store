using System.ComponentModel.DataAnnotations;

namespace Cafee_web.Models // Matches your exact project namespace
{
    public class Booking
    {
        [Key] // This tells SQL to make this an auto-incrementing Primary Key
        public int Id { get; set; }

        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        public DateTime ReservationDate { get; set; }

        [Required]
        public string TimeSlot { get; set; } = string.Empty;

        [Required]
        public string GuestCount { get; set; } = "2";
    }
}