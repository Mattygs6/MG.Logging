namespace MG.Logging
{
	using System;

	using JetBrains.Annotations;

	/// <summary>
	///     The Logging Manager interface
	/// </summary>
	public interface ILoggingManager
	{
		/// <summary>
		///     Logs an audit message.
		/// </summary>
		/// <param name="owner">The owner.</param>
		/// <param name="format">The format.</param>
		/// <param name="args">The format parameters.</param>
		[StringFormatMethod("format")]
		void Audit(object owner, string format, params object[] args);

		/// <summary>
		///     Logs a debug message.
		/// </summary>
		/// <param name="owner">The owner.</param>
		/// <param name="format">The format.</param>
		/// <param name="args">The format parameters.</param>
		[StringFormatMethod("format")]
		void Debug(object owner, string format, params object[] args);

		/// <summary>
		///     Logs an error message.
		/// </summary>
		/// <param name="owner">The owner.</param>
		/// <param name="format">The format.</param>
		/// <param name="args">The format parameters.</param>
		[StringFormatMethod("format")]
		void Error(object owner, string format, params object[] args);

		/// <summary>
		///     Logs an exception. (Severity Error)
		/// </summary>
		/// <param name="exception">The exception.</param>
		/// <param name="owner">The owner.</param>
		/// <param name="message">The message.</param>
		void Exception(Exception exception, object owner, string message = null);

		/// <summary>
		///     Logs a fatal message.
		/// </summary>
		/// <param name="owner">The owner.</param>
		/// <param name="format">The format.</param>
		/// <param name="args">The format parameters.</param>
		[StringFormatMethod("format")]
		void Fatal(object owner, string format, params object[] args);

		/// <summary>
		///     Logs a fatal exception.
		/// </summary>
		/// <param name="exception">The exception.</param>
		/// <param name="owner">The owner.</param>
		/// <param name="message">The message.</param>
		void Fatal(Exception exception, object owner, string message = null);

		/// <summary>
		///     Logs an Informational message.
		/// </summary>
		/// <param name="owner">The owner.</param>
		/// <param name="format">The format.</param>
		/// <param name="args">The format parameters.</param>
		[StringFormatMethod("format")]
		void Info(object owner, string format, params object[] args);

		/// <summary>
		///     Determines whether the specified level is enabled for any log provider.
		/// </summary>
		/// <param name="level">The level.</param>
		/// <returns>True if enabled, false otherwise</returns>
		bool IsEnabled(LogLevel level);

		/// <summary>
		///     Logs a message at the specified level.
		/// </summary>
		/// <param name="level">The level.</param>
		/// <param name="owner">The owner.</param>
		/// <param name="format">The format.</param>
		/// <param name="args">The format parameters.</param>
		[StringFormatMethod("format")]
		void Log(LogLevel level, object owner, string format, params object[] args);

		/// <summary>
		///     Logs an exception at the specified level.
		/// </summary>
		/// <param name="level">The level.</param>
		/// <param name="exception">The exception.</param>
		/// <param name="owner">The owner.</param>
		/// <param name="message">The message.</param>
		void LogException(LogLevel level, Exception exception, object owner, string message = null);

		/// <summary>
		///     Logs a verbose message.
		/// </summary>
		/// <param name="owner">The owner.</param>
		/// <param name="format">The format.</param>
		/// <param name="args">The format parameters.</param>
		[StringFormatMethod("format")]
		void Verbose(object owner, string format, params object[] args);

		/// <summary>
		///     Logs a message as a warning.
		/// </summary>
		/// <param name="owner">The owner.</param>
		/// <param name="format">The format.</param>
		/// <param name="args">The format parameters.</param>
		[StringFormatMethod("format")]
		void Warn(object owner, string format, params object[] args);

		/// <summary>
		///     Logs an exception as a warning.
		/// </summary>
		/// <param name="exception">The message.</param>
		/// <param name="owner">The owner.</param>
		/// <param name="message">The message.</param>
		void Warn(Exception exception, object owner, string message = null);
	}
}