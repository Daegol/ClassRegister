using System;
using System.Collections.Generic;

namespace ClassRegister.Services.DTOs
{
    public class ClassToAddDto
    {
        public string Name { get; set; }
        public Guid TutorId { get; set; }
        public IEnumerable<Guid> StudentsId { get; set; }

    }
}