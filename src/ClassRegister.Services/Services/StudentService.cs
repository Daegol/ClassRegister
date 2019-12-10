using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ClassRegister.Core.Model;
using ClassRegister.Core.Repositories;
using ClassRegister.Services.DTOs;
using ClassRegister.Services.IServices;
using ClassRegister.Services.Mappers;

namespace ClassRegister.Services.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StudentDto>> GetStudents()
        { 
            var students = await _studentRepository.Get();
            var studentDtos =  _mapper.Map<IEnumerable<StudentDto>>(students);
            int id = 1;
            foreach (var student in studentDtos)
            {
                student.Id = id;
                id++;
            }

            return studentDtos;
        }

        public async Task DeleteStudent(string pesel)
        {
            await _studentRepository.DeleteStudent(pesel);
        }

        public async Task UpdateStudent(UpdateStudentDto studentDto)
        {
            var student = await _studentRepository.GetByPesel(studentDto.Pesel);
            student = MyMapper.UpdateStudentMap(studentDto, student);
            await _studentRepository.UpdateStudent(student);
        }

        public async Task<IEnumerable<StudentToGroupDto>> GetStudentsToGroup()
        {
            var students = await _studentRepository.Get();
            var studentsToGroup = _mapper.Map<IEnumerable<StudentToGroupDto>>(students);
            return studentsToGroup;
        }
    }
}