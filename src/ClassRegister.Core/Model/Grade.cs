using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassRegister.Core.Model
{
    public class Grade
    {
        public Guid Id { get; set; }
        public int Value { get; set; }
        public virtual Student Student { get; set; }
        public Guid StudentId { get; set; }
        public Guid? SubjectId { get; set; }
    }
}