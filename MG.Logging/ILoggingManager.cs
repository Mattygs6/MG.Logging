namespace MG.Logging
{
	using System;

	/// <summary>
	///     The Logging Manager interface
	/// </summary>
	public interface ILoggingManager
	{
		/// <summary>
		///     Logs an audit message.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="owner">The owner.</param>
		/// <param name="formatParams">The format parameters.</param>
		void Audit(string message, object owner, params object[] formatParams);

		/// <summary>
		///     Logs a debug message.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="owner">The owner.</param>
		/// <param name="formatParams">The format parameters.</param>
		void Debug(string message, object owner, params object[] formatParams);

		/// <summary>
		///     Logs an error message.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="owner">The owner.</param>
		/// <param name="formatParams">The format parameters.</param>
		void Error(string message, object owner, params object[] formatParams);

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
		/// <param name="message">The message.</param>
		/// <param name="owner">The owner.</param>
		/// <param name="formatParams">The format parameters.</param>
		void Fatal(string message, object owner, params object[] formatParams);

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
		/// <param name="message">The message.</param>
		/// <param name="owner">The owner.</param>
		/// <param name="formatParams">The format parameters.</param>
		void Info(string message, object owner, params object[] formatParams);

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
		/// <param name="message">The message.</param>
		/// <param name="owner">The owner.</param>
		/// <param name="formatParams">The format parameters.</param>
		void Log(LogLevel level, string message, object owner, params object[] formatParams);

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
		/// <param name="message">The message.</param>
		/// <param name="owner">The owner.</param>
		/// <param name="formatParams">The format parameters.</param>
		void Verbose(string message, object owner, params object[] formatParams);

		/// <summary>
		///     Logs a message as a warning.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="owner">The owner.</param>
		/// <param name="formatParams">The format parameters.</param>
		void Warn(string message, object owner, params object[] formatParams);

		/// <summary>
		///     Logs an exception as a warning.
		/// </summary>
		/// <param name="exception">The message.</param>
		/// <param name="owner">The owner.</param>
		/// <param name="message">The message.</param>
		void Warn(Exception exception, object owner, string message = null);
	}
}