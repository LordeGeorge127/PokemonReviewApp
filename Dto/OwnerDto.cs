﻿using Pokemon_Review_App.Models;

namespace Pokemon_Review_App.Dto
{
    public class OwnerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gym { get; set; }
        public Country Country { get; set; }
    }
}
