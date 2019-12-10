using System;
using System.Collections.Generic;

namespace ClassRegister.Core.Model
{
    public class Schedule
    {
        public Guid Id { get; set; }
        public string DayOfTheWeek { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        private ISet<Lesson> _lessons = new HashSet<Lesson>();
        public IEnumerable<Lesson> Lessons => _lessons;
    }
}