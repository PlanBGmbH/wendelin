using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;

namespace Functions.Extensions.Logging.Tests
{
    internal class Logger : ILogger
    {   
        private Action<string> Output => this.Logs.Add;
        public List<string> Logs { get; set; } = new List<string>();


        public void Dispose()
        {
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception,
            Func<TState, Exception, string> formatter) => this.Output(formatter(state, exception));

        public bool IsEnabled(LogLevel logLevel) => true;

        public IDisposable BeginScope<TState>(TState state) => NullLogger.Instance.BeginScope(state);
    }
}
