using System;
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

        public GradeService(IGradeRepository gradeRepository, IStudentRepository studentRepository)
        {
            _gradeRepository = gradeRepository;
            _studentRepository = studentRepository;
        }

        public async Task AddGrade(GradeToAdd grade)
        {
            var g = MyMapper.GradeToAddMap(grade, _studentRepository);
            await _gradeRepository.AddGrade(g);
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
    }
}