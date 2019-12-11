using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Functions.Extensions.Logging
{
    /// <summary>
    /// The ILogger Extensions.
    /// </summary>
    public static class LoggerExtension
    {
        /// <summary>
        /// Informations the specified event identifier.
        /// </summary>
        /// <param name="log">The log.</param>
        /// <param name="correlationId">The correlation identifier.</param>
        /// <param name="message">The message.</param>
        /// <param name="trace">The trace.</param>
        /// <param name="eventId">The event id.</param>
        public static void LogInformation(this ILogger log, Guid correlationId, string message, IDictionary<string, string> trace = null, EventId eventId = default(EventId))
        {
            if (log == null)
            {
                return;
            }

            eventId = eventId == default(EventId) ? new EventId(correlationId.GetHashCode(), Constants.EsbCorrelationTraceName) : eventId;

            var state = CreateDefaultTrace(correlationId);
            state.Add(new KeyValuePair<string, object>("Message", message));

            if (trace != null)
            {
                var rator = trace.GetEnumerator();
                while (rator.MoveNext())
                {
                    if (!state.Any(n => n.Key == rator.Current.Key))
                    {
                        state.Add(new KeyValuePair<string, object>(rator.Current.Key, rator.Current.Value));
                    }
                }
            }

            log.Log(LogLevel.Information, eventId, state, null, Formatter);
        }

        /// <summary>
        /// Logs the error.
        /// </summary>
        /// <param name="log">The log.</param>
        /// <param name="correlationId">The correlation identifier.</param>
        /// <param name="message">The message.</param>
        /// <param name="trace">The trace.</param>
        /// <param name="exception">The exeception</param>
        /// <param name="eventId">The event id.</param>
        public static void LogError(this ILogger log, Guid correlationId, string message, IDictionary<string, string> trace = null, Exception exception = null, EventId eventId = default(EventId))
        {
            if (log == null)
            {
                return;
            }

            eventId = eventId == default(EventId) ? new EventId(correlationId.GetHashCode(), Constants.EsbCorrelationTraceName) : eventId;

            var state = CreateDefaultTrace(correlationId);
            state.Add(new KeyValuePair<string, object>("Message", message));

            if (trace != null)
            {
                var rator = trace.GetEnumerator();
                while (rator.MoveNext())
                {
                    if (!state.Any(n => n.Key == rator.Current.Key))
                    {
                        state.Add(new KeyValuePair<string, object>(rator.Current.Key, rator.Current.Value));
                    }
                }

                if (exception == null)
                {
                    exception = new Exception(message);
                }
            }

            log.Log(LogLevel.Error, eventId, state, exception, Formatter);
        }

        /// <summary>
        /// Creates the default trace.
        /// </summary>
        /// <param name="correlationId">The correlation identifier.</param>
        /// <returns></returns>
        internal static IList<KeyValuePair<string, object>> CreateDefaultTrace(Guid correlationId)
        {
            var state = new List<KeyValuePair<string, object>>()
            {
                { new KeyValuePair<string, object>(Constants.EsbCorrelationTraceName, correlationId.ToString()) },
                { new KeyValuePair<string, object>(Constants.EsbBuildNumberTraceName, Settings.GetSetting("BuildNumber")) },
                { new KeyValuePair<string, object>(Constants.EsbFabricNodeIPOrFQDNTraceName, Settings.GetSetting("Fabric_NodeIPOrFQDN")) },
                { new KeyValuePair<string, object>(Constants.EsbFabricNodeNameTraceName, Settings.GetSetting("Fabric_NodeName")) },
                { new KeyValuePair<string, object>(Constants.EsbImageSourceTraceName, Settings.GetSetting("ImageSource")) },
            };

            return state;
        }

        /// <summary>
        /// Informations the specified event identifier.
        /// </summary>
        /// <param name="log">The log.</param>
        /// <param name="correlationId">The correlation identifier.</param>
        /// <param name="message">The message.</param>
        /// <param name="trace">The trace.</param>
        /// <param name="eventId">The event id.</param>
        public static void LogInformation(this ILogger log, string message, IDictionary<string, string> trace = null, EventId eventId = default(EventId))
        {
            if (log == null)
            {
                return;
            }

            var state = CreateDefaultTrace();
            state.Add(new KeyValuePair<string, object>("Message", message));

            if (trace != null)
            {
                var rator = trace.GetEnumerator();
                while (rator.MoveNext())
                {
                    if (!state.Any(n => n.Key == rator.Current.Key))
                    {
                        state.Add(new KeyValuePair<string, object>(rator.Current.Key, rator.Current.Value));
                    }
                }
            }

            log.Log(LogLevel.Information, eventId, state, null, Formatter);
        }

        /// <summary>
        /// Logs the error.
        /// </summary>
        /// <param name="log">The log.</param>
        /// <param name="correlationId">The correlation identifier.</param>
        /// <param name="message">The message.</param>
        /// <param name="trace">The trace.</param>
        /// <param name="exception">The exeception</param>
        /// <param name="eventId">The event id.</param>
        public static void LogError(this ILogger log, string message, IDictionary<string, string> trace = null, Exception exception = null, EventId eventId = default(EventId))
        {
            if (log == null)
            {
                return;
            }

            var state = CreateDefaultTrace();
            state.Add(new KeyValuePair<string, object>("Message", message));

            if (trace != null)
            {
                var rator = trace.GetEnumerator();
                while (rator.MoveNext())
                {
                    if (!state.Any(n => n.Key == rator.Current.Key))
                    {
                        state.Add(new KeyValuePair<string, object>(rator.Current.Key, rator.Current.Value));
                    }
                }

                if (exception == null)
                {
                    exception = new Exception(message);
                }
            }

            log.Log(LogLevel.Error, eventId, state, exception, Formatter);
        }

        /// <summary>
        /// Creates the default trace.
        /// </summary>
        /// <param name="correlationId">The correlation identifier.</param>
        /// <returns></returns>
        internal static IList<KeyValuePair<string, object>> CreateDefaultTrace()
        {
            var state = new List<KeyValuePair<string, object>>()
            {                
                { new KeyValuePair<string, object>(Constants.EsbBuildNumberTraceName, Settings.GetSetting("BuildNumber")) },
                { new KeyValuePair<string, object>(Constants.EsbFabricNodeIPOrFQDNTraceName, Settings.GetSetting("Fabric_NodeIPOrFQDN")) },
                { new KeyValuePair<string, object>(Constants.EsbFabricNodeNameTraceName, Settings.GetSetting("Fabric_NodeName")) },
                { new KeyValuePair<string, object>(Constants.EsbImageSourceTraceName, Settings.GetSetting("ImageSource")) },
            };

            return state;
        }

        /// <summary>
        /// Style of logging.
        /// </summary>
        /// <typeparam name="T">State.</typeparam>
        /// <param name="state">State Param.</param>
        /// <param name="ex">Exception.</param>
        /// <returns>Message.</returns>
        internal static string Formatter<T>(T state, Exception ex)
        {
            if (ex != null)
            {
                return ex.ToString();
            }

            IList<KeyValuePair<string, object>> stateDictionary = state as List<KeyValuePair<string, object>>;
            if (stateDictionary != null && stateDictionary.Any(n => n.Key == "Message"))
            {
                return stateDictionary.FirstOrDefault(n => n.Key == "Message").Value?.ToString() ?? string.Empty;
            }

            return string.Empty;
        }
    }
}
