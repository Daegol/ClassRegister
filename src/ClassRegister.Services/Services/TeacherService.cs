using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ClassRegister.Core.Repositories;
using ClassRegister.Services.DTOs;
using ClassRegister.Services.IServices;
using ClassRegister.Services.Mappers;

namespace ClassRegister.Services.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;
        private readonly MyMapper _mymapper = new MyMapper();

        public TeacherService(ITeacherRepository TeacherRepository, IMapper mapper)
        {
            _teacherRepository = TeacherRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TeacherDto>> GetTeachers()
        {
            var teachers = await _teacherRepository.Get();
            var teacherDtos = _mapper.Map<IEnumerable<TeacherDto>>(teachers);
            int id = 1;
            foreach (var teacher in teacherDtos)
            {
                teacher.Id = id;
                id++;
            }

            return teacherDtos;
        }

        public async Task DeleteTeacher(string pesel)
        {
            await _teacherRepository.DeleteTeacher(pesel);
        }

        public async Task UpdateTeacher(UpdateTeacherDto teacherDto)
        {
            var teacher = await _teacherRepository.GetByPesel(teacherDto.Pesel);
            teacher = _mymapper.UpdateTeacherMap(teacherDto, teacher);
            await _teacherRepository.UpdateTeacher(teacher);
        }
    }
}