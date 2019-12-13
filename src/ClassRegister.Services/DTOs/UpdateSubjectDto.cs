using System;

namespace ClassRegister.Services.DTOs
{
    public class UpdateSubjectDto
    {
        public string Name { get; set; }
        public string TeacherPesel { get; set; }
        public Guid Id { get; set; }
    }
}