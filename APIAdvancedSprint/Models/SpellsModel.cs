using System.Text.Json;

namespace APIAdvancedSprint.Models
{
    public class SpellsModel
    {
        public List<Spell> GetAllSpells()
        {
            return JsonSerializer.Deserialize<List<Spell>>(File.ReadAllText("Resources/Spells.json"));
        }
    }
}
