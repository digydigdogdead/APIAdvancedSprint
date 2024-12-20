using System.Text.Json;

namespace APIAdvancedSprint.Models
{
    public class SpellsModel
    {
        public List<Spell> GetAllSpells()
        {
            return JsonSerializer.Deserialize<List<Spell>>(File.ReadAllText("Resources/Spells.json"));
        }

        public Spell GetRandomSpell()
        {
            var allSpells = GetAllSpells();
            Random random = new();

            int randomIndex = random.Next(1, allSpells.Count);

            return allSpells[randomIndex];
        }
    }
}
