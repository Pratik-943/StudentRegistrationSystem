using Lab_9.Data_Access_Layer;
using Lab_9.Entity_Layer;
using System;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using Lab_9.Entity_Layer;
using Lab_9.Data_Access_Layer;

namespace Lab_9.Business_Access_Layer
{
    public class StudentService
    {
        private IStudentRepository repo;

        public StudentService()
        {
            repo = new StudentRepository();
        }

        public void AddStudent(Student s)
        {
            repo.Insert(s);
        }

        public void UpdateStudent(Student s)
        {
            repo.Update(s);
        }

        public void DeleteStudent(int id)
        {
            repo.Delete(id);
        }

        public List<Student> GetStudents()
        {
            return repo.GetAll();
        }

        // ⭐ THIS METHOD WAS MISSING
        public Student GetStudentById(int id)
        {
            return repo.GetById(id);
        }
    }
}