using System;

namespace ClassRegister.Services.DTOs
{
    public class GradeToAdd
    {
        public int Value { get; set; }
        public string Type { get; set; }
        public string StudentPesel { get; set; }
        public Guid SubjectId { get; set; }
    }
}