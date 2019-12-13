using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassRegister.Core.Model;
using ClassRegister.Services.DTOs;
using ClassRegister.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace ClassRegister.Application.Controllers
{
    public class SubjectsController : ApiBaseController
    {
        private readonly ISubjectService _subjectService;

        public SubjectsController(ISubjectService subjectService)
        {
            this._subjectService = subjectService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subject>>> GetAll()
        {
            var subjects = await _subjectService.GetSubjects();
            return Json(subjects);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddSubject([FromBody] SubjectToAddDto subjectToAdd)
        {
            await _subjectService.AddSubject(subjectToAdd);
            return Ok();
        }

        [HttpDelete("remove/{subjectId}")]
        public async Task<IActionResult> RemoveSubject(Guid subjectId)
        {
            await _subjectService.RemoveSubject(subjectId);
            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateSubject([FromBody] UpdateSubjectDto updateSubject)
        {
            await _subjectService.UpdateSubject(updateSubject);
            return Ok();
        }

    }
}