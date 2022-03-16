using System;
using System.Collections.Generic;
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
    }
}
