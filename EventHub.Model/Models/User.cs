﻿using EventHub.Core.Entities;

namespace EventHub.Entities.Models
{
    public class User : IEntity
    {
        public int? UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
