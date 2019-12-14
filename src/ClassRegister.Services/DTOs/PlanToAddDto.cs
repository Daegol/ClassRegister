using System;
using System.Collections.Generic;
using System.Text;

namespace ClassRegister.Services.DTOs
{
    public class PlanToAddDto
    {
        public Guid ClassId { get; set; }
        public IEnumerable<LessonToAddDto> Monday { get; set; }
        public IEnumerable<LessonToAddDto> Tuesday { get; set; }
        public IEnumerable<LessonToAddDto> Wednesday { get; set; }
        public IEnumerable<LessonToAddDto> Thursday { get; set; }
        public IEnumerable<LessonToAddDto> Friday { get; set; }
    }
}
