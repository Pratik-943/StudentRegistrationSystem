using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_9.Entity_Layer
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}