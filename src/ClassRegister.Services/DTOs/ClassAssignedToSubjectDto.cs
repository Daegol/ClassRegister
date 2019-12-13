using System;

namespace ClassRegister.Services.DTOs
{
    public class ClassAssignedToSubjectDto
    {
        public Guid SubjectId { get; set; }
        public Guid ClassId { get; set; }
    }
}