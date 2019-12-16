using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassRegister.Services.DTOs;
using ClassRegister.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClassRegister.Application.Controllers
{
    [Authorize]
    public class ParentsController : ApiBaseController
    {
        private readonly IParentService _parentService;

        public ParentsController(IParentService parentService)
        {
            _parentService = parentService;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<ParentDto>>> GetParentsList()
        {
            var parents = await _parentService.GetParents();
            return Json(parents);
        }

        [HttpDelete("{pesel}")]
        public async Task<ActionResult> DeleteParent(string pesel)
        {
            await _parentService.DeleteParent(pesel);
            return Ok();
        }

        [HttpPut("update")]
        public async Task<ActionResult> UpdateParent([FromBody] UpdateParentDto parentDto)
        {
            await _parentService.UpdateParent(parentDto);
            return Ok();
        }

        [HttpGet("plan/{id}")]
        public async Task<IActionResult> GetPlan(Guid id)
        {
            var plan = await _parentService.GetPlan(id);
            return Json(plan);
        }
    }
}