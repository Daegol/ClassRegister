using System;

namespace ClassRegister.Services.DTOs
{
    public class ClassesDto
    {
        public string Name { get; set; }
        public string Tutor { get; set; }
        public string TutorPesel { get; set; }
        public int StudentsNumber { get; set; }
        public Guid DatabaseId { get; set; }
    }
}