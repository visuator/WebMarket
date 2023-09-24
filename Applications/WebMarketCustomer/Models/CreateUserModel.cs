﻿using System.ComponentModel.DataAnnotations;

namespace WebMarketCustomer.Models
{
    public class CreateUserModel
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        public string? Address { get; set; }
        [Required]
        public string Password { get; set; }
    }
}