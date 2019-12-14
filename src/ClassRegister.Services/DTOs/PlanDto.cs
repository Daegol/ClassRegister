using System;
using System.Collections.Generic;
using System.Text;

namespace ClassRegister.Services.DTOs
{
    public class PlanDto
    {
        public bool IsExisting { get; set; }
        public IEnumerable<LessonDto> Monday { get; set; }
        public IEnumerable<LessonDto> Tuesday { get; set; }
        public IEnumerable<LessonDto> Wednesday { get; set; }
        public IEnumerable<LessonDto> Thursday { get; set; }
        public IEnumerable<LessonDto> Friday { get; set; }
    }
}
