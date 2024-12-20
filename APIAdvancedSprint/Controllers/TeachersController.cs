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

        [HttpGet]
        public IActionResult GetAllTeachers()
        {
            return Ok(_teachersService.GetAllTeachers());
        }

        [HttpGet("{id}")]
        public IActionResult GetTeacherById(int id)
        {
            var result = _teachersService.GetTeacherById(id);

            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult PostTeacher(Teacher teacher)
        {
            if (String.IsNullOrEmpty(teacher.Name))
            {
                return BadRequest("The new teacher must have a name.");
            }

            bool result = _teachersService.TryPostTeacher(teacher, out Teacher newTeacher);

            if (result)
            {
                return Created($"/teachers/{newTeacher.Id}", newTeacher);
            }

            return BadRequest(newTeacher);
        }
    }
}
