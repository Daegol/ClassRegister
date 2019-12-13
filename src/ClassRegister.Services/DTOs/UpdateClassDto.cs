using System;
using System.Collections.Generic;

namespace ClassRegister.Services.DTOs
{
    public class UpdateClassDto
    {
        public string Name { get; set; }
        public string TutorId { get; set; }
        public IEnumerable<Guid> StudentsId { get; set; }
        public Guid ClassId { get; set; }
    }
}