using System;
using System.Collections.Generic;
using System.Text;
using MovieLand.Data.Models;

namespace MovieLand.Services.Users
{
    public interface IUserService
    {
        public string EncryptPassword(string password);

        public bool Login(string identificator, string password);

        public bool Register(string email, string username, string password);

        public bool IsUserAuthenticated();

        public bool IsUserAdmin();

        public User GetCurrentUser();
    }
}
