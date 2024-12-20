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

        public List<Spell>? GetSpellsByTeacherId(int id)
        {
            var allSpells = GetAllSpells();
            TeachersModel teachersModel = new TeachersModel();
            Teacher? teacher = teachersModel.GetTeacherById(id);
            if (teacher == null) return null;

            List<string> teachersSpells = teacher.Teaches;

            List<Spell> relevantSpells = (from spell in allSpells
                                         join teachersspell in teachersSpells on spell.Name equals teachersspell
                                         select spell).ToList();

            return relevantSpells;
        }
    }
}
