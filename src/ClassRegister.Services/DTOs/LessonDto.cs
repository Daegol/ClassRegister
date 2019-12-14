using System;
using System.Collections.Generic;
using System.Text;

namespace ClassRegister.Services.DTOs
{
    public class LessonDto
    {
        public string SubjectName { get; set; }
        public int LessonHour { get; set; }
        public string TeacherName { get; set; }
        public Guid DatabaseId { get; set; }
    }
}
