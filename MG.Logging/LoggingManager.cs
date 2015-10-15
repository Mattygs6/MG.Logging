namespace MG.Logging
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using JetBrains.Annotations;

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
		/// <param name="format">The format.</param>
		/// <param name="owner">The owner.</param>
		/// <param name="args">The format args.</param>
		[StringFormatMethod("format")]
		public void Audit(string format, object owner, params object[] args)
		{
			foreach (var provider in loggingProviders)
			{
				provider.Log(LogLevel.Audit, format, owner, args);
			}
		}

		/// <summary>
		///     Logs a debug message.
		/// </summary>
		/// <param name="format">The format.</param>
		/// <param name="owner">The owner.</param>
		/// <param name="args">The format args.</param>
		[StringFormatMethod("format")]
		public void Debug(string format, object owner, params object[] args)
		{
			foreach (var provider in loggingProviders)
			{
				provider.Log(LogLevel.Debug, format, owner, args);
			}
		}

		/// <summary>
		///     Logs an error message.
		/// </summary>
		/// <param name="format">The format.</param>
		/// <param name="owner">The owner.</param>
		/// <param name="args">The format args.</param>
		[StringFormatMethod("format")]
		public void Error(string format, object owner, params object[] args)
		{
			foreach (var provider in loggingProviders)
			{
				provider.Log(LogLevel.Error, format, owner, args);
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
		/// <param name="format">The format.</param>
		/// <param name="owner">The owner.</param>
		/// <param name="args">The format args.</param>
		[StringFormatMethod("format")]
		public void Fatal(string format, object owner, params object[] args)
		{
			foreach (var provider in loggingProviders)
			{
				provider.Log(LogLevel.Fatal, format, owner, args);
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
		/// <param name="format">The format.</param>
		/// <param name="owner">The owner.</param>
		/// <param name="args">The format args.</param>
		[StringFormatMethod("format")]
		public void Info(string format, object owner, params object[] args)
		{
			foreach (var provider in loggingProviders)
			{
				provider.Log(LogLevel.Info, format, owner, args);
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
		/// <param name="format">The format.</param>
		/// <param name="owner">The owner.</param>
		/// <param name="args">The format args.</param>
		[StringFormatMethod("format")]
		public void Log(LogLevel level, string format, object owner, params object[] args)
		{
			foreach (var provider in loggingProviders)
			{
				provider.Log(level, format, owner, args);
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
		/// <param name="format">The format.</param>
		/// <param name="owner">The owner.</param>
		/// <param name="args">The format args.</param>
		[StringFormatMethod("format")]
		public void Verbose(string format, object owner, params object[] args)
		{
			foreach (var provider in loggingProviders)
			{
				provider.Log(LogLevel.Verbose, format, owner, args);
			}
		}

		/// <summary>
		///     Logs a message as a warning.
		/// </summary>
		/// <param name="format">The format.</param>
		/// <param name="owner">The owner.</param>
		/// <param name="args">The format args.</param>
		[StringFormatMethod("format")]
		public void Warn(string format, object owner, params object[] args)
		{
			foreach (var provider in loggingProviders)
			{
				provider.Log(LogLevel.Warn, format, owner, args);
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