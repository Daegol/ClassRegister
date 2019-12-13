using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassRegister.Core.Model;
using ClassRegister.Core.Repositories;
using ClassRegister.Services.DTOs;
using ClassRegister.Services.IServices;
using ClassRegister.Services.Mappers;

namespace ClassRegister.Services.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly ILessonRepository _lessonRepository;
        private readonly ITeacherRepository _teacherRepository;

        public SubjectService(ISubjectRepository subjectRepository, ILessonRepository lessonRepository, ITeacherRepository teacherRepository)
        {
            _subjectRepository = subjectRepository;
            _lessonRepository = lessonRepository;
            _teacherRepository = teacherRepository;
        }
        public async Task AddSubject(SubjectToAddDto subjectDto)
        {
//            var lesson = new Lesson();
//            lesson.Id = Guid.NewGuid();
//            lesson.Subject = MyMapper.AddSubjectMap(subjectDto);
//            lesson.TeacherId = _teacherRepository.GetByPesel(subjectDto.TeacherPesel).Result.Id;
//            await _lessonRepository.AddLesson(lesson);
            var subject = new Subject();
            subject.Id = Guid.NewGuid();
            subject.Name = subjectDto.Name;
            subject.TeacherId = _teacherRepository.GetByPesel(subjectDto.TeacherPesel).Result.Id;
            await _subjectRepository.AddSubject(subject);
        }

        public async Task<IEnumerable<SubjectDto>> GetSubjects()
        {
            var subjects = await _subjectRepository.GetAll();
            var subjectDto = subjects.Select(x => MyMapper.SubjectToSend(x, _teacherRepository).Result);
            return subjectDto;
        }

        public async Task RemoveSubject(Guid subjectId)
        {
            await _subjectRepository.RemoveSubject(subjectId);
        }

        public async Task UpdateSubject(UpdateSubjectDto updateSubject)
        {
            var subject = await _subjectRepository.GetById(updateSubject.Id);
            await _subjectRepository.UpdateSubject(MyMapper.UpdateSubjectMap(updateSubject, subject, _teacherRepository));
        }
    }
}