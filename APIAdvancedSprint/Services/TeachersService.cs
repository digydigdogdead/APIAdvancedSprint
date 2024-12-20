﻿using APIAdvancedSprint.Models;

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

        public bool TryPostTeacher(Teacher teacher, out Teacher newTeacher)
        {
            return _teachersModel.TryAddTeacher(teacher, out newTeacher);
        }

        public List<Teacher> GetAllTeachers()
        {
            return _teachersModel.GetAllTeachers();
        }

        public bool TryDeleteTeacherById(int id)
        {
            return _teachersModel.TryDeleteTeacherById(id);
        }

        public bool TryIncrementRatingById(int id, out Teacher? updatedTeacher)
        {
            return _teachersModel.TryIncrementRatingById(id, out updatedTeacher);
        }
    }
}
