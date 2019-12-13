using System;
using System.Collections.Generic;

namespace ClassRegister.Services.DTOs
{
    public class SubjectDto
    {
        public string Name { get; set; }
        public string TeacherName { get; set; }
        public string TeacherPesel { get; set; }
        public IEnumerable<ClassToSubjectDto> GroupsAssignedToSubject { get; set; }
        public Guid DatabaseId { get; set; }
    }
}