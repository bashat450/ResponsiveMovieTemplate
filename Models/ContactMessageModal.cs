﻿using System;
using System.ComponentModel.DataAnnotations;


namespace MovieTicketBooking.Models
{
    public class ContactMessageModal
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public string Phone { get; set; }

        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }


        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}


