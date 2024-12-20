using APIAdvancedSprint.Services;
using Microsoft.AspNetCore.Mvc;


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
        public IActionResult GetRandomSpell()
        {
            return Ok(_spellsService.GetRandomSpell());
        }
    }
}
