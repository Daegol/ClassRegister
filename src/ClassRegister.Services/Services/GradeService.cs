using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassRegister.Core.Repositories;
using ClassRegister.Services.DTOs;
using ClassRegister.Services.IServices;
using ClassRegister.Services.Mappers;

namespace ClassRegister.Services.Services
{
    public class GradeService : IGradeService
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ISubjectRepository _subjectRepository;
        private readonly IParentRepository _parentRepository;
        private readonly IMailService _mailService;

        public GradeService(IGradeRepository gradeRepository, IStudentRepository studentRepository, ISubjectRepository subjectRepository, IParentRepository parentRepository, IMailService mailService)
        {
            _gradeRepository = gradeRepository;
            _studentRepository = studentRepository;
            _subjectRepository = subjectRepository;
            _parentRepository = parentRepository;
            _mailService = mailService;
        }

        public async Task AddGrade(GradeToAdd grade)
        {
            var g = MyMapper.GradeToAddMap(grade, _studentRepository);
            await _gradeRepository.AddGrade(g);
            string subject = "Nowa ocena";
            string body = "Pańskie dziecko otrzymało nową ocenę";
            var parent = _studentRepository.GetByPesel(grade.StudentPesel).Result.Parent;
            _mailService.Send(subject,body,parent);
        }

        public async Task DeleteGrade(Guid id)
        {
            await _gradeRepository.DeleteGrade(id);
        }

        public async Task UpdateGrade(GradeToUpdate updateGrade)
        {
            var grade = await _gradeRepository.GetById(updateGrade.GradeId);
            grade = MyMapper.GradeToUpdateMap(updateGrade, grade);
            await _gradeRepository.UpdateGrade(grade);
        }

        public async Task<IEnumerable<StudentGradesDto>> GetStudentGrades(Guid id)
        {
            var parent = await _parentRepository.GetByIdWithGrades(id);
            List<StudentGradesDto> studentGrades = new List<StudentGradesDto>();
            var grades = parent.Student.Grades;
            foreach (var grade in grades)
            {
                var subjectName = _subjectRepository.GetById(grade.SubjectId.Value).Result.Name;
                var item = studentGrades.SingleOrDefault(x => x.Subject == subjectName);
                if (item == null)
                {
                    var studentGrade = new StudentGradesDto();
                    studentGrade.Subject = subjectName;
                    studentGrade.Grades = grade.Value.ToString();
                    studentGrades.Add(studentGrade);
                }
                else
                {
                    item.Grades = item.Grades + ", " + grade.Value.ToString();
                }
            }

            return studentGrades;
        }
    }
}