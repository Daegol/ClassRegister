using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassRegister.Core.Model
{
    public class Lesson
    {
        public Guid Id { get; set; }
        public virtual Class Class { get; set; }
        public Guid? ClassId { get; set; }
        public virtual Subject Subject { get; set; }
        public Guid? SubjectId { get; set; }
        public virtual Teacher Teacher { get; set; }
        public Guid? TeacherId { get; set; }
        public virtual Schedule Schedule { get; set; }
        public Guid? ScheduleId { get; set; }
    }
}