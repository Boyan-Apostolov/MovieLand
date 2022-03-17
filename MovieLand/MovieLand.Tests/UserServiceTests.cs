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

            Assert.AreEqual(expectedOutput,actualOutput);
        }
        [Test]

        public void RegisterShouldReturnTrue()
        {
            string password = "Admin123";
            string username = "Admin";
            string email = "Admin@land.db";

            bool result = this.userService.Register(email, username, password);

            Assert.IsTrue(true);

            var user = this.dbContext.Users.First(x => x.UserName == "Admin");
            this.dbContext.Users.Remove(user);
            this.dbContext.SaveChanges();
        }

            [Test]
        public void ULoginSouldReturnTrue()
        {
            string password = "Admin123";
            string username = "Admin";
            string email = "Admin@land.db";

            
           this.userService.Register(email, username, password);

            bool result = this.userService.ULogin(username, password);

            Assert.IsTrue(result);

            var user = this.dbContext.Users.First(x => x.UserName == "Admin");
            this.dbContext.Users.Remove(user);
            this.dbContext.SaveChanges();
        }
        
        [Test]
        public void ELoginSholdRetunrTrue()
        {
            string password = "Admin123";
            string username = "Admin";
            string email = "Admin@land.db";

            this.userService.Register(email, username, password);

            bool reslut = this.userService.ELogin(email, password);

            Assert.IsTrue(reslut);

            var user = this.dbContext.Users.First(x => x.UserName == "Admin");
            this.dbContext.Users.Remove(user);
            this.dbContext.SaveChanges();
        }
    }
}
