using APIAdvancedSprint.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace APIAdvancedSprint.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class TeachersController : Controller
    {
        private TeachersService _teachersService;
        private readonly IMemoryCache _cache;
        private const string TeacherCacheKey = "TeacherList";

        public TeachersController(TeachersService teachersService, IMemoryCache cache)
        {
            _teachersService = teachersService;
            _cache = cache;
        }

        [HttpGet]
        public IActionResult GetAllTeachers()
        {
            List<Teacher> teachers;

            // If the cache contains products, store them in the `products` variable
            if (!_cache.TryGetValue(TeacherCacheKey, out teachers))
            {
                // If cache is empty, retrieve products from the service layer
                teachers = _teachersService.GetAllTeachers();

                // Then store the retrieved products in the cache
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(2));

                _cache.Set(TeacherCacheKey, teachers, cacheEntryOptions);
            }

            // return them, either from cache or from the service layer
            return Ok(teachers);
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

        [HttpDelete("{id}")]
        public IActionResult DeleteTeacherById(int id)
        {
            bool result = _teachersService.TryDeleteTeacherById(id);

            if (result) return NoContent();
            else return BadRequest();
        }
    }
}
