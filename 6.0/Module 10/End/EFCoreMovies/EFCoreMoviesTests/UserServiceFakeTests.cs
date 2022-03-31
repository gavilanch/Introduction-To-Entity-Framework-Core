using EFCoreMovies.Utilities;
using EFCoreMoviesTests.Mocks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EFCoreMoviesTests
{
    [TestClass]
    public class UserServiceFakeTests
    {
        [TestMethod]
        public void GetUserId_DoesNotReturnNull()
        {
            // Preparation
            var userService = new UserServiceFake();

            // Test
            var result = userService.GetUserId();

            // Verification
            Assert.IsNotNull(result);
            Assert.AreNotEqual("", result);
        }
    }
}