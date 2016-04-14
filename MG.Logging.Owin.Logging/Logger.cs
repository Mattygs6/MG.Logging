namespace MG.Logging.Owin.Logging
{
	using System;
	using System.Diagnostics;

	using Microsoft.Owin.Logging;

	/// <summary>
	///     NLog adapter class
	/// </summary>
	internal class Logger : ILogger
	{
		private readonly Func<TraceEventType, LogLevel> getLogLevel;

		private readonly ILoggingManager loggingManager;

		private readonly string name;

		/// <summary>
		///     Initializes a new instance of the <see cref="Logger" /> class.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="getLogLevel">The get log level.</param>
		/// <param name="loggingManager">The logging manager.</param>
		internal Logger(string name, Func<TraceEventType, LogLevel> getLogLevel, ILoggingManager loggingManager)
		{
			this.name = name;
			this.getLogLevel = getLogLevel;
			this.loggingManager = loggingManager;
		}

		#region ILogger Members

		/// <summary>
		///     Aggregates most logging patterns to a single method.  This must be compatible with the Func representation in the
		///     OWIN environment.
		///     To check IsEnabled call WriteCore with only TraceEventType and check the return value, no event will be written.
		/// </summary>
		/// <param name="eventType"></param>
		/// <param name="eventId"></param>
		/// <param name="state"></param>
		/// <param name="exception"></param>
		/// <param name="formatter"></param>
		/// <returns>True if enabled, false otherwise</returns>
		public bool WriteCore(
			TraceEventType eventType,
			int eventId,
			object state,
			Exception exception,
			Func<object, Exception, string> formatter)
		{
			var level = getLogLevel(eventType);

			if (state == null)
			{
				return loggingManager.IsEnabled(level);
			}

			if (!loggingManager.IsEnabled(level))
			{
				return false;
			}

			loggingManager.LogException(level, exception, name, formatter(state, exception));

			return true;
		}

		#endregion
	}
}