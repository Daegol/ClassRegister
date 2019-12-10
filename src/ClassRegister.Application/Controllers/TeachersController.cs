using System.Collections.Generic;
using System.Threading.Tasks;
using ClassRegister.Services.DTOs;
using ClassRegister.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClassRegister.Application.Controllers
{
    [Authorize]
    public class TeachersController : ApiBaseController
    {
        private readonly ITeacherService _teacherService;

        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<TeacherDto>>> GetTeachersList()
        {
            var teachers = await _teacherService.GetTeachers();
            return Json(teachers);
        }

        [HttpDelete("{pesel}")]
        public async Task<ActionResult> DeleteTeacher(string pesel)
        {
            await _teacherService.DeleteTeacher(pesel);
            return Ok();
        }

        [HttpPut("update")]
        public async Task<ActionResult> UpdateTeacher([FromBody] UpdateTeacherDto teacherDto)
        {
            await _teacherService.UpdateTeacher(teacherDto);
            return Ok();
        }
    }
}