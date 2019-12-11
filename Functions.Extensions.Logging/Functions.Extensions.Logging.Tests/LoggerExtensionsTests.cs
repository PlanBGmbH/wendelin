using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Functions.Extensions.Logging.Tests
{
    [TestClass]
    public class LoggerExtensionsTests
    {
        Logger log;
        Guid guid;

        [TestInitialize]
        public void Init()
        {
            this.log = new Logger();
            this.guid = Guid.NewGuid();
        }

        /// <summary>B
        /// Initializes a new instance of the <see cref="LoggerExtensions" /> class.
        /// </summary>
        [TestMethod]
        public void LogInfoNullNotFailed()
        {            
            log.LogInformation(null, null);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggerExtensions" /> class.
        /// </summary>
        [TestMethod]
        public void LogInfoMessageNullNotFailed()
        {            
            var trace = new Dictionary<string, string> { { "test", "test" } };
            log.LogInformation(null, trace);
            Assert.IsTrue(log.Logs.Count == 1);
        }

        /// <summary>
        /// Logs the error null not failed.
        /// </summary>
        [TestMethod]
        public void LogErrorNullNotFailed()
        {                    
            log.LogError(null, null);
            Assert.IsTrue(log.Logs.Count == 1);
        }

        [TestMethod]
        public void LogErrorMessageNullNotFailed()
        {            
            var trace = new Dictionary<string, string> { { "test", "test" } };
            log.LogError(null, trace, null);
            Assert.IsTrue(log.Logs.Count == 1);
        }

        /// <summary>
        /// Logs the error null not failed.
        /// </summary>
        [TestMethod]
        public void LogErrorNullExceptionNotFailed()
        {            
            var ex = new Exception();
            log.LogError(null, null, ex);
            Assert.IsTrue(log.Logs.Count == 1);
        }

        [TestMethod]
        public void LogMessageWithEventIdOk()
        {
            string message = DateTime.UtcNow.ToString();
            log.LogInformation(message, null, LoggerEvents.DistributionAccepted);
            Assert.IsTrue(log.Logs.Count == 1);
            Assert.IsTrue(log.Logs.Any(n => n == message));
        }

        [TestMethod]
        public void LogErrorWithEventIdOk()
        {
            string message = DateTime.UtcNow.ToString();
            log.LogError(message, null, null, LoggerEvents.DistributionAccepted);
            Assert.IsTrue(log.Logs.Count == 1);
            Assert.IsTrue(log.Logs.Any(n => n == message));
        }

        [TestMethod]
        public void LogErrorWithEventIdAndExceptionOk()
        {
            string message = DateTime.UtcNow.ToString();
            log.LogError(message, null, new Exception(), LoggerEvents.DistributionAccepted);
            Assert.IsTrue(log.Logs.Count == 1);

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggerExtensions" /> class.
        /// </summary>
        [TestMethod]
        public void LogInfoNullNotFailedCorrelation()
        {
            log.LogInformation(guid, null, null);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoggerExtensions" /> class.
        /// </summary>
        [TestMethod]
        public void LogInfoMessageNullNotFailedCorrelation()
        {
            var trace = new Dictionary<string, string> { { "test", "test" } };
            log.LogInformation(guid, null, trace);
            Assert.IsTrue(log.Logs.Count == 1);
        }

        /// <summary>
        /// Logs the error null not failed.
        /// </summary>
        [TestMethod]
        public void LogErrorNullNotFailedCorrelation()
        {
            log.LogError(guid, null, null);
            Assert.IsTrue(log.Logs.Count == 1);
        }

        [TestMethod]
        public void LogErrorMessageNullNotFailedCorrelation()
        {
            var trace = new Dictionary<string, string> { { "test", "test" } };
            log.LogError(guid, null, trace, null);
            Assert.IsTrue(log.Logs.Count == 1);
        }

        /// <summary>
        /// Logs the error null not failed.
        /// </summary>
        [TestMethod]
        public void LogErrorNullExceptionNotFailedCorrelation()
        {
            var ex = new Exception();
            log.LogError(guid, null, null, ex);
            Assert.IsTrue(log.Logs.Count == 1);
        }

        [TestMethod]
        public void LogMessageWithEventIdOkCorrelation()
        {
            string message = DateTime.UtcNow.ToString();
            log.LogInformation(guid, message, null, LoggerEvents.DistributionAccepted);
            Assert.IsTrue(log.Logs.Count == 1);
            Assert.IsTrue(log.Logs.Any(n => n == message));
        }

        [TestMethod]
        public void LogErrorWithEventIdOkCorrelation()
        {
            string message = DateTime.UtcNow.ToString();
            log.LogError(guid, message, null, null, LoggerEvents.DistributionAccepted);
            Assert.IsTrue(log.Logs.Count == 1);
            Assert.IsTrue(log.Logs.Any(n => n == message));
        }

        [TestMethod]
        public void LogErrorWithEventIdAndExceptionOkCorrelation()
        {
            string message = DateTime.UtcNow.ToString();
            log.LogError(guid, message, null, new Exception(), LoggerEvents.DistributionAccepted);
            Assert.IsTrue(log.Logs.Count == 1);

        }
    }
}
