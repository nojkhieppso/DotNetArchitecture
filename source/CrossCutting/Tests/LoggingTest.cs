using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solution.CrossCutting.Logging;
using System;

namespace Solution.CrossCutting.Tests
{
    [TestClass]
    public class LoggingTest
    {
        public LoggingTest()
        {
            Logger = new Logger(new ConfigurationBuilder().AddJsonFile("AppSettings.json").Build());
        }

        private ILogger Logger { get; }

        [TestMethod]
        public void LoggerError()
        {
            Logger.Error(new Exception(nameof(Logger.Error)));
        }
    }
}
