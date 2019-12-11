using System;

namespace ClassRegister.Services.DTOs
{
    public class StudentToGroupDto
    {
        public Guid Id { get; set; }
        public bool IsAssigned { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pesel { get; set; }
    }
}