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

        [HttpPost("add")]
        public async Task<IActionResult> AddClass([FromBody] ClassToAddDto classTo)
        {
            await _classService.AddClass(classTo);
            return Ok();
        }
    }
}