namespace MG.Logging.Owin.Logging
{
	using System;
	using System.Diagnostics;
	using System.Web.Mvc;

	using Microsoft.Owin.Logging;

	public class LoggingManagerFactory : ILoggerFactory
	{
		/// <summary>
		///     The log level translation function to get a NLog loglevel
		/// </summary>
		private readonly Func<TraceEventType, LogLevel> getLogLevel;

		/// <summary>
		///     Create a logger factory with the default translation
		/// </summary>
		public LoggingManagerFactory()
		{
			getLogLevel = DefaultGetLogLevel;
		}

		/// <summary>
		///     Create a logger factory with a custom translation routine
		/// </summary>
		/// <param name="getLogLevel"></param>
		public LoggingManagerFactory(Func<TraceEventType, LogLevel> getLogLevel)
		{
			this.getLogLevel = getLogLevel;
		}

		#region ILoggerFactory Members

		/// <summary>
		///     Creates a new ILogger instance of the given name.
		/// </summary>
		/// <param name="name">The logger context name.</param>
		/// <returns>A logger instance.</returns>
		public ILogger Create(string name)
		{
			return Create(name, DependencyResolver.Current.GetService<ILoggingManager>());
		}

		#endregion

		/// <summary>
		///     Creates a new ILogger instance of the given name.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="loggingManager">The logging manager.</param>
		/// <returns>A logger isntance</returns>
		public ILogger Create(string name, ILoggingManager loggingManager)
		{
			return new Logger(name, getLogLevel, loggingManager);
		}

		/// <summary>
		///     This is the standard translation
		/// </summary>
		/// <param name="traceEventType"></param>
		/// <returns></returns>
		private static LogLevel DefaultGetLogLevel(TraceEventType traceEventType)
		{
			switch (traceEventType)
			{
				case TraceEventType.Critical:
					return LogLevel.Fatal;
				case TraceEventType.Error:
					return LogLevel.Error;
				case TraceEventType.Warning:
					return LogLevel.Warn;
				case TraceEventType.Information:
					return LogLevel.Info;
				case TraceEventType.Verbose:
					return LogLevel.Verbose;
				case TraceEventType.Start:
					return LogLevel.Debug;
				case TraceEventType.Stop:
					return LogLevel.Debug;
				case TraceEventType.Suspend:
					return LogLevel.Debug;
				case TraceEventType.Resume:
					return LogLevel.Debug;
				case TraceEventType.Transfer:
					return LogLevel.Debug;
				default:
					throw new ArgumentOutOfRangeException("traceEventType");
			}
		}
	}
}