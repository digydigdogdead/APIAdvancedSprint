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

        public List<Teacher> GetAllTeachers()
        {
            return JsonSerializer.Deserialize<List<Teacher>>(File.ReadAllText("Resources/Teachers.json"));
        }

        public bool TryAddTeacher(Teacher newTeacher, out Teacher postedTeacher)
        {
            var allTeachers = GetAllTeachers();

            if (newTeacher == null)
            {
                postedTeacher = newTeacher;
                return false;
            }

            if (newTeacher.Id == 0 || newTeacher.Id !> allTeachers.Count)
            {
                newTeacher.Id = allTeachers.Count + 1;
            }

            postedTeacher = newTeacher;

            try
            {
                allTeachers.Add(newTeacher);
                File.WriteAllText("Resources/Teachers.json", JsonSerializer.Serialize(allTeachers));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool TryDeleteTeacherById(int id)
        {
            var allTeachers = GetAllTeachers();

            foreach (Teacher teacher in allTeachers)
            {
                if (teacher.Id == id)
                {
                    allTeachers.Remove(teacher);
                    File.WriteAllText("Resources/Teachers.json", JsonSerializer.Serialize(allTeachers));
                    return true;
                }
            }

            return false;
        }
    }
}
