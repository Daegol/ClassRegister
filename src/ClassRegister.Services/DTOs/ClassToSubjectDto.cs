using System;

namespace ClassRegister.Services.DTOs
{
    public class ClassToSubjectDto
    {
        public string Name { get; set; }
        public int StudentsNumber { get; set; }
        public Guid Id { get; set; }
    }
}