using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassRegister.Core.Model
{
    public class Student : User
    {
        public Student(Guid id, string role, string firstName, byte[] passwordHash, byte[] passwordSalt,
            string lastName, string email, string phoneNumber, string pesel, string postCode, string city,
            string street, string houseNumber) : base(id, role, firstName, passwordHash, passwordSalt, lastName, email,
            phoneNumber, pesel, postCode, city, street, houseNumber)
        {
        }

        public virtual Class Class { get; set; }
        public Guid? ClassId { get; set; }

        public virtual Parent Parent { get; set; }
        public Guid? ParentId { get; set; }

        private ISet<Grade> _grades = new HashSet<Grade>();
        public IEnumerable<Grade> Grades => _grades;
    }
}