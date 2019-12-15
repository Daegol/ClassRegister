﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassRegister.Services.DTOs;
using ClassRegister.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClassRegister.Application.Controllers
{
    [Authorize]
    public class StudentsController : ApiBaseController
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudentsList()
        {
            var students = await _studentService.GetStudents();
            return Json(students);
        }

        [HttpDelete("{pesel}")]
        public async Task<ActionResult> DeleteStudent(string pesel)
        {
            await _studentService.DeleteStudent(pesel);
            return Ok();
        }

        [HttpPut("update")]
        public async Task<ActionResult> UpdateStudent([FromBody] UpdateStudentDto studentDto)
        {
            await _studentService.UpdateStudent(studentDto);
            return Ok();
        }

        [HttpGet("stg")]
        public async Task<ActionResult<IEnumerable<StudentToGroupDto>>> GetStudentsToGroup()
        {
            var students = await _studentService.GetStudentsToGroup();
            return Json(students);
        }

        [HttpGet("stg/{id}")]
        public async Task<ActionResult<IEnumerable<StudentToGroupDto>>> GetStudentsToGroup(Guid id)
        {
            var students = await _studentService.GetStudentsToGroupEdit(id);
            return Json(students);
        }

        [HttpGet("grade/{id}")]
        public async Task<ActionResult<IEnumerable<StudentsToGrade>>> GetStudentsToGrades(Guid id)
        {
            var students = await _studentService.GetStudentsToGrade(id);
            return Json(students);
        }
    }
}