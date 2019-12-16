using System;

namespace ClassRegister.Services.DTOs
{
    public class UpdateParentDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Pesel { get; set; }
        public string Address { get; set; }
        public string Id { get; set; }
    }
}