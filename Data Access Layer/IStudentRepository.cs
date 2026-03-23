using Lab_9.Entity_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_9.Data_Access_Layer
{
    public interface IStudentRepository
    {
        void Insert(Student student);
        void Update(Student student);
        void Delete(int id);
        List<Student> GetAll();
        Student GetById(int id);
    }
}