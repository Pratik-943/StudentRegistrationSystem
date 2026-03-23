using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_9.Entity_Layer
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string Language { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public string Photo { get; set; }
    }
}