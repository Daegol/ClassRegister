using System;
using System.Threading.Tasks;
using ClassRegister.Services.DTOs;
using ClassRegister.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClassRegister.Application.Controllers
{
    [Authorize]
    public class ClassesController : ApiBaseController
    {
        private readonly IClassService _classService;

        public ClassesController(IClassService classService)
        {
            _classService = classService;
        }

        [HttpGet]
        public async Task<IActionResult> GetClasses()
        {
            var classesDto = await _classService.GetClasses();
            return Json(classesDto);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddClass([FromBody] ClassToAddDto classTo)
        {
            await _classService.AddClass(classTo);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClass(Guid id)
        {
            await _classService.DeleteClass(id);
            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateClass([FromBody] UpdateClassDto updateClass)
        {
            await _classService.UpdateClass(updateClass);
            return Ok();
        }

        [HttpGet("plan/{id}")]
        public async Task<IActionResult> GetPlan(Guid id)
        {
            var plan = await _classService.GetPlan(id);
            return Json(plan);
        }

        [HttpPost("plan/add")]
        public async Task<IActionResult> AddPlan([FromBody] PlanToAddDto planToAdd)
        {
            await _classService.AddPlan(planToAdd);
            return Ok();
        }
    }
}