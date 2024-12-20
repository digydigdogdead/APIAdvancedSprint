using APIAdvancedSprint.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;


namespace APIAdvancedSprint.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class SpellsController : ControllerBase
    {
        private SpellsService _spellsService;
        public SpellsController(SpellsService spellsService)
        {
            _spellsService = spellsService;
        }

        [HttpGet]
        public IActionResult GetAllSpells()
        {
            var result = _spellsService.GetAllSpells();
            if (result.Count != 0 || result != null) return Ok(result);
            else return NoContent();
        }

        [HttpGet("/spell")]
        [EnableRateLimiting("fixedSpell")]
        public IActionResult GetRandomSpell()
        {
            return Ok(_spellsService.GetRandomSpell());
        }

        [HttpGet("teacher/{id}")]
        public IActionResult GetSpellsByTeacher(int id)
        {
            List<Spell>? result = _spellsService.GetSpellsByTeacherId(id);

            if (result is null) return NotFound();

            if (result.Count == 0) return NoContent();

            return Ok(result);
        }
    }
}
