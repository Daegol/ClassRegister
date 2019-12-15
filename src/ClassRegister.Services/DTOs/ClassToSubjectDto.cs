using System;

namespace ClassRegister.Services.DTOs
{
    public class ClassToSubjectDto
    {
        public string Name { get; set; }
        public int StudentsNumber { get; set; }
        public Guid Id { get; set; }
        public override bool Equals(object obj)
        {
            return obj is ClassToSubjectDto q && q.Id == this.Id && q.Name == this.Name && q.StudentsNumber == this.StudentsNumber;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode() ^ this.StudentsNumber.GetHashCode() ^ this.Name.GetHashCode();
        }
    }
}