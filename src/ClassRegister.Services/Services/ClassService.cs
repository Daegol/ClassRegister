using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;

        public ClassService(IClassRepository classRepository, ITeacherRepository teacherRepository,
            IMapper mapper, IStudentRepository studentRepository)
        {
            _classRepository = classRepository;
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }

        public async Task AddClass(ClassToAddDto @group)
        {
            var newClass = new Class();
            var cl = MyMapper.AddClassMap(group, newClass);
            await _classRepository.AddClass(cl);
            await _studentRepository.AddClasses(group.StudentsId, cl.Id);
        }

        public async Task<IEnumerable<ClassesDto>> GetClasses()
        {
            var classes = await _classRepository.GetAll();
            return classes.Select(x => MyMapper.ClassesToSend(x, _teacherRepository));
        }

        public async Task DeleteClass(Guid id)
        {
            await _classRepository.DeleteClass(id);
        }

        public async Task UpdateClass(UpdateClassDto updateClass)
        {
            var cl = await _classRepository.GetById(updateClass.ClassId);
            cl = MyMapper.UpdateClassMap(updateClass, cl, _teacherRepository);
            await _studentRepository.AddClasses(updateClass.StudentsId, updateClass.ClassId);
            await _classRepository.UpdateClass(cl);
        }
    }
}