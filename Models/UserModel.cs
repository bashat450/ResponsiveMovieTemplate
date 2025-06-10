using System;
using System.ComponentModel.DataAnnotations;

namespace MovieTicketBooking.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
