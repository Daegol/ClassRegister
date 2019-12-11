using System;
using System.Threading.Tasks;
using AutoMapper;
using ClassRegister.Core.Model;
using ClassRegister.Core.Repositories;
using ClassRegister.Services.DTOs;
using ClassRegister.Services.IServices;
using ClassRegister.Services.Mappers;

namespace ClassRegister.Services.Services
{
    public class ClassService : IClassService
    {
        private readonly IClassRepository _classRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public ClassService(IClassRepository classRepository, IMapper mapper, IStudentRepository studentRepository)
        {
            _classRepository = classRepository;
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task AddClass(ClassToAddDto @group)
        {
            var newClass = new Class();
            var cl = MyMapper.AddClassMap(group, newClass);
            await _classRepository.AddClass(cl);
            await _studentRepository.AddClasses(group.StudentsId, cl.Id);
        }
    }
}