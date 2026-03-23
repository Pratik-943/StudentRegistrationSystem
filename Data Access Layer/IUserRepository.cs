using Lab_9.Entity_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab_9.Data_Access_Layer
{
    public interface IUserRepository
    {
        void Insert(User u);

        User Login(string email, string password);
    }
}