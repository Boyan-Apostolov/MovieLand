using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using MovieLand.Common;
using MovieLand.Data;
using MovieLand.Data.Models;

namespace MovieLand.Services.Users
{
    public class UserService : IUserService
    {
        private readonly MovieLandDbContext dbContext;
        private User currentUser;

        public UserService(MovieLandDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public string EncryptPassword(string password)
        {
            SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
            byte[] password_bytes = Encoding.ASCII.GetBytes(password);
            byte[] encrypted_bytes = sha256.ComputeHash(password_bytes);

            return Convert.ToBase64String(encrypted_bytes);
        }

        public bool ELogin(string email, string password)
        {
            string hashed_password = EncryptPassword(password);

            var user = dbContext.Users
                .FirstOrDefault(x => x.Email == email);

            if (user == null || (user.Password != hashed_password)) throw new Exception("Unsuccessful login!");
            this.currentUser = user;
            return true;
        }

        public bool ULogin(string username, string password)
        {
            string hashed_password = EncryptPassword(password);

            var user = dbContext.Users.FirstOrDefault(x => x.UserName == username);

            if (user == null || (user.Password != hashed_password)) throw new Exception("Unsuccessful login!");

            this.currentUser = user;
            return true;
        }

        public bool Register(string email, string username, string password)
        {
            //test@test.com
            var emailPattern = @"[A-z]+@+[A-z]+\.+[A-z]+";

            //Minimum six characters, at least one uppercase letter, one lowercase letter and one number:
            var passwordPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{6,}$";

            if (this.dbContext.Users.Any(x => x.UserName == username) 
                || this.dbContext.Users.Any(x=>x.Email == email))
            {
                throw new Exception("User already exists!");
            }

            if (!Regex.Match(email, emailPattern).Success
                || !Regex.Match(password, passwordPattern).Success)
            {
                throw new Exception("Email or password does not meet the requirements of minimum six characters, at least one uppercase letter and one lowercase letter!");
            }

            var user = new User()
            {
                Email = email,
                Password = this.EncryptPassword(password),
                UserName = username,
            };

            this.dbContext.Users.Add(user);
            this.dbContext.SaveChanges();

            this.currentUser = user;
            return true;
        }

        public bool IsUserAuthenticated() => this.currentUser != null;

        public bool IsUserAdmin() => this.currentUser.Email == GlobalConstants.AdminEmail;

        public User GetCurrentUser() => this.currentUser;
    }
}
