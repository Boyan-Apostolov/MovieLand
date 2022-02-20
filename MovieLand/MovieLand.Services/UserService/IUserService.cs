using System;
using System.Collections.Generic;
using System.Text;

namespace MovieLand.Services.UserService
{
    public interface IUserService
    {
        public string EncryptPassword(string password);

        public bool Login(string username, string password);

        public bool Register(string email, string username, string password);
    }
}
