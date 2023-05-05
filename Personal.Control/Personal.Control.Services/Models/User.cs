﻿namespace Personal.Control.Services.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public User() 
        { 
            Id = Guid.NewGuid().ToString();
        }
    }
}
