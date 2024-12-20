using APIAdvancedSprint.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIAdvancedSprint.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class TeachersController : Controller
    {
        private TeachersService _teachersService;

        public TeachersController(TeachersService teachersService)
        {
            _teachersService = teachersService;
        }

        [HttpGet("{id}")]
        public IActionResult GetTeacherById(int id)
        {
            var result = _teachersService.GetTeacherById(id);

            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}
