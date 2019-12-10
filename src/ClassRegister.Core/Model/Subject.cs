using System;
using System.Collections.Generic;

namespace ClassRegister.Core.Model
{
    public class Subject
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        private ISet<Lesson> _lessons = new HashSet<Lesson>();
        public IEnumerable<Lesson> Lessons => _lessons;
        public Guid TeacherId { get; set; }
    }
}