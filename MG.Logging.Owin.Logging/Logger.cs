namespace MG.Logging.Owin.Logging.NLog
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
			var level = this.getLogLevel(eventType);

			if (state == null)
			{
				return this.loggingManager.IsEnabled(level);
			}

			if (!this.loggingManager.IsEnabled(level))
			{
				return false;
			}

			this.loggingManager.LogException(level, exception, name, formatter(state, exception));

			return true;
		}

		#endregion
	}
}