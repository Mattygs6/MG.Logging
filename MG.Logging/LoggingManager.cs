namespace MG.Logging
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	/// <summary>
	///     The Logging Manager
	/// </summary>
	public class LoggingManager : ILoggingManager
	{
		private readonly ILoggingProvider[] loggingProviders;

		/// <summary>
		///     Initializes a new instance of the <see cref="LoggingManager" /> class.
		/// </summary>
		/// <param name="providers">The providers.</param>
		public LoggingManager(IEnumerable<ILoggingProvider> providers)
		{
			loggingProviders = providers.ToArray();
		}

		#region ILoggingManager Members

		/// <summary>
		///     Logs an audit message.
		/// </summary>
		/// <param name="owner">The owner.</param>
		/// <param name="format">The format.</param>
		/// <param name="args">The format args.</param>
		public void Audit(object owner, string format, params object[] args)
		{
			foreach (var provider in loggingProviders)
			{
				provider.Log(LogLevel.Audit, owner, format, args);
			}
		}

		/// <summary>
		///     Logs a debug message.
		/// </summary>
		/// <param name="owner">The owner.</param>
		/// <param name="format">The format.</param>
		/// <param name="args">The format args.</param>
		public void Debug(object owner, string format, params object[] args)
		{
			foreach (var provider in loggingProviders)
			{
				provider.Log(LogLevel.Debug, owner, format, args);
			}
		}

		/// <summary>
		///     Logs an error message.
		/// </summary>
		/// <param name="owner">The owner.</param>
		/// <param name="format">The format.</param>
		/// <param name="args">The format args.</param>
		public void Error(object owner, string format, params object[] args)
		{
			foreach (var provider in loggingProviders)
			{
				provider.Log(LogLevel.Error, owner, format, args);
			}
		}

		/// <summary>
		///     Logs an exception. (Severity Error)
		/// </summary>
		/// <param name="exception">The exception.</param>
		/// <param name="owner">The owner.</param>
		/// <param name="message">The message.</param>
		public void Exception(Exception exception, object owner, string message = null)
		{
			foreach (var provider in loggingProviders)
			{
				provider.LogException(LogLevel.Error, exception, owner, message);
			}
		}

		/// <summary>
		///     Logs a critical message.
		/// </summary>
		/// <param name="owner">The owner.</param>
		/// <param name="format">The format.</param>
		/// <param name="args">The format args.</param>
		public void Fatal(object owner, string format, params object[] args)
		{
			foreach (var provider in loggingProviders)
			{
				provider.Log(LogLevel.Fatal, owner, format, args);
			}
		}

		/// <summary>
		///     Logs a critical exception.
		/// </summary>
		/// <param name="exception">The exception.</param>
		/// <param name="owner">The owner.</param>
		/// <param name="message">The message.</param>
		public void Fatal(Exception exception, object owner, string message = null)
		{
			foreach (var provider in loggingProviders)
			{
				provider.LogException(LogLevel.Fatal, exception, owner, message);
			}
		}

		/// <summary>
		///     Logs an Informational message.
		/// </summary>
		/// <param name="owner">The owner.</param>
		/// <param name="format">The format.</param>
		/// <param name="args">The format args.</param>
		public void Info(object owner, string format, params object[] args)
		{
			foreach (var provider in loggingProviders)
			{
				provider.Log(LogLevel.Info, owner, format, args);
			}
		}

		/// <summary>
		///     Determines whether the specified level is enabled for any log provider.
		/// </summary>
		/// <param name="level">The level.</param>
		/// <returns>True if enabled, false otherwise</returns>
		public bool IsEnabled(LogLevel level)
		{
			return loggingProviders.Any(lp => lp.IsEnabled(level));
		}

		/// <summary>
		///     Logs a message at the specified level.
		/// </summary>
		/// <param name="level">The level.</param>
		/// <param name="owner">The owner.</param>
		/// <param name="format">The format.</param>
		/// <param name="args">The format args.</param>
		public void Log(LogLevel level, object owner, string format, params object[] args)
		{
			foreach (var provider in loggingProviders)
			{
				provider.Log(level, owner, format, args);
			}
		}

		/// <summary>
		///     Logs an exception at the specified level.
		/// </summary>
		/// <param name="level">The level.</param>
		/// <param name="exception">The exception.</param>
		/// <param name="owner">The owner.</param>
		/// <param name="message">The message.</param>
		public void LogException(LogLevel level, Exception exception, object owner, string message = null)
		{
			foreach (var provider in loggingProviders)
			{
				provider.LogException(level, exception, owner, message);
			}
		}

		/// <summary>
		///     Logs a verbose message.
		/// </summary>
		/// <param name="owner">The owner.</param>
		/// <param name="format">The format.</param>
		/// <param name="args">The format args.</param>
		public void Verbose(object owner, string format, params object[] args)
		{
			foreach (var provider in loggingProviders)
			{
				provider.Log(LogLevel.Verbose, owner, format, args);
			}
		}

		/// <summary>
		///     Logs a message as a warning.
		/// </summary>
		/// <param name="owner">The owner.</param>
		/// <param name="format">The format.</param>
		/// <param name="args">The format args.</param>
		public void Warn(object owner, string format, params object[] args)
		{
			foreach (var provider in loggingProviders)
			{
				provider.Log(LogLevel.Warn, owner, format, args);
			}
		}

		/// <summary>
		///     Logs an exception as a warning.
		/// </summary>
		/// <param name="exception">The message.</param>
		/// <param name="owner">The owner.</param>
		/// <param name="message">The message.</param>
		public void Warn(Exception exception, object owner, string message = null)
		{
			foreach (var provider in loggingProviders)
			{
				provider.LogException(LogLevel.Warn, exception, owner, message);
			}
		}

		#endregion
	}
}