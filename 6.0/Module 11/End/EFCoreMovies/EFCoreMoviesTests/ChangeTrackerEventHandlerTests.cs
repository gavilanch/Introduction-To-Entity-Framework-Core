using EFCoreMovies.Utilities;
using EFCoreMoviesTests.Mocks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreMoviesTests
{
    [TestClass]
    public class ChangeTrackerEventHandlerTests
    {
        [TestMethod]
        public void SavedChangesHandler_Send3AsAmountOfEntries_LogsCorrectMessage()
        {
            // Preparation
            var loggerFake = new LoggerFake<ChangeTrackerEventHandler>();
            var changeTrackerEventHandler = new ChangeTrackerEventHandler(loggerFake);

            // Testing
            var savedChangesEventArgs = new SavedChangesEventArgs(
                acceptAllChangesOnSuccess: false, 
                entitiesSavedCount: 3);
            changeTrackerEventHandler.SavedChangesHandler(null, savedChangesEventArgs);

            // Verification
            Assert.AreEqual("We processed 3 entities.", loggerFake.LastLog);
            Assert.AreEqual(1, loggerFake.CountLogs);
        }
    }
}
