using APIAdvancedSprint.Models;

namespace APIAdvancedSprint.Services
{
    public class TeachersService
    {
        private TeachersModel _teachersModel;
        public TeachersService(TeachersModel teachersModel)
        {
            _teachersModel = teachersModel;
        }

        public Teacher? GetTeacherById(int id)
        {
            return _teachersModel.GetTeacherById(id);
        }
    }
}
