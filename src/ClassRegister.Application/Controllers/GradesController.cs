using System;
using System.Threading.Tasks;
using ClassRegister.Services.DTOs;
using ClassRegister.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ClassRegister.Application.Controllers
{
    public class GradesController : ApiBaseController
    {
        private readonly IGradeService _gradeService;
        private readonly IMailService _mailService;

        public GradesController(IGradeService gradeService, IMailService mailService)
        {
            _gradeService = gradeService;
            _mailService = mailService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddGrade([FromBody] GradeToAdd gradeToAdd)
        {
            await _gradeService.AddGrade(gradeToAdd);
            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateGrade([FromBody] GradeToUpdate gradeToUpdate)
        {
            await _gradeService.UpdateGrade(gradeToUpdate);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrade(Guid id)
        {
            await _gradeService.DeleteGrade(id);
            return Ok();
        }

        [HttpGet("student/{id}")]
        public async Task<IActionResult> GetGrades(Guid id)
        {
            var grades = await _gradeService.GetStudentGrades(id);
            return Json(grades);
        }
    }
}