﻿using System;

namespace ClassRegister.Services.DTOs
{
    public class StudentToParentDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pesel { get; set; }
    }
}