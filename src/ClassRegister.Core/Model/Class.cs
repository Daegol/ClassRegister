using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassRegister.Core.Model
{
    public class Class
    {
        public Guid Id { get; set; }

        private ISet<Student> _students = new HashSet<Student>();
        public IEnumerable<Student> Students => _students;

        private ISet<Lesson> _lessons = new HashSet<Lesson>();
        public IEnumerable<Lesson> Lessons => _lessons;
        public Guid TeacherId { get; set; }
    }
}