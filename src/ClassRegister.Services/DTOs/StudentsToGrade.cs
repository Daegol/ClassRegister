using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ClassRegister.Services.DTOs
{
    public class StudentsToGrade
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pesel { get; set; }
        public IEnumerable<GradesDto> Grades { get; set; }
    }
}