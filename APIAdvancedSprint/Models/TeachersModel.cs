using System.Text.Json;
namespace APIAdvancedSprint.Models
{
    public class TeachersModel
    {
        public Teacher? GetTeacherById(int id)
        {
            List<Teacher>? allTeachers = JsonSerializer.Deserialize<List<Teacher>>(File.ReadAllText("Resources/Teachers.json"));

            if (allTeachers is null) return null;

            foreach (Teacher teacher in allTeachers)
            {
                if (teacher.Id == id) return teacher;
            }

            return null;
        }
    }
}
