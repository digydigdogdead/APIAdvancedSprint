using APIAdvancedSprint.Models;

namespace APIAdvancedSprint.Services
{
    public class SpellsService
    {
        private SpellsModel _spellsModel;
        public SpellsService(SpellsModel spellsModel)
        {
            this._spellsModel = spellsModel;
        }

        public List<Spell> GetAllSpells()
        {
            return _spellsModel.GetAllSpells();
        }

        public Spell GetRandomSpell()
        {
            return _spellsModel.GetRandomSpell();
        }

        public List<Spell>? GetSpellsByTeacherId(int id)
        {
            return _spellsModel.GetSpellsByTeacherId(id);
        }
    }
}
