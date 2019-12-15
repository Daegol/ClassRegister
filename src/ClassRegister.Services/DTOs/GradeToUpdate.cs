using System;

namespace ClassRegister.Services.DTOs
{
    public class GradeToUpdate
    {
        public int Value { get; set; }
        public string Type { get; set; }
        public string StudentPesel { get; set; }
        public Guid GradeId { get; set; }
    }
}