using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace MovieLand.Tests
{
    public class UserServiceTests : BaseTestClass
    {
        [Test]
        public void EncryptPasswordShouldReturnCorrectOutput()
        {
            var password = "test";
            var expectedOutput = "n4bQgYhMfWWaL+qgxVrQFaO/TxsrC4Is0V1sFbDwCgg=";

            var actualOutput = this.userService.EncryptPassword(password);

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void RegisterShouldReturnTrueWhenCorrect()
        {
            var email = Guid.NewGuid().ToString() + "@test.com";
            string password = "Admin123";

            bool result = this.userService.Register(email, email, password);

            Assert.IsTrue(result);

            this.RemoveUser(email);
        }

        [Test]
        public void RegisterShouldReturnFalseWhenIncorrectEmail()
        {
            var email = "@test.com";
            string password = "Admin123";


            Assert.Throws<Exception>(() =>
            {
                this.userService.Register(email, email, password);
            });
        }

        [Test]
        public void RegisterShouldReturnThrowWhenIncorrectPassword()
        {
            var email = "@test.com";
            string password = "a";


            Assert.Throws<Exception>(() =>
            {
                this.userService.Register(email, email, password);
            });
        }

        [Test]
        public void ELoginShouldReturnTrue()
        {
            string password = "Admin123";
            var email = Guid.NewGuid().ToString() + "@test.com"; ;

            this.userService.Register(email, email, password);

            bool result = this.userService.Login(email, password);

            Assert.IsTrue(result);

            this.RemoveUser(email);
        }

        [Test]
        public void ELoginShouldReturnThrowWhenIncorrect()
        {
            string password = "Admin123";
            var email = Guid.NewGuid().ToString() + "@test.com"; ;

            this.userService.Register(email, email, password);

            Assert.Throws<Exception>(() =>
            {
                this.userService.Login(email, "a");
            });

            this.RemoveUser(email);
        }

        private void RemoveUser(string email)
        {
            var user = this.dbContext.Users.First(x => x.Email == email);
            this.dbContext.Users.Remove(user);
            this.dbContext.SaveChanges();
        }
    }
}
