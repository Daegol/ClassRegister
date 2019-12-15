using System;
using System.Reflection.Metadata.Ecma335;

namespace ClassRegister.Services.DTOs
{
    public class GradesDto
    {
        public Guid Id { get; set; }
        public int Value { get; set; }
        public string Type { get; set; }
    }
}