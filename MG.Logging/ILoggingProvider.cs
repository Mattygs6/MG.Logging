namespace MG.Logging
{
	using System;

	public interface ILoggingProvider
	{
		/// <summary>
		///     Determines whether the specified level is enabled for this logging provider.
		/// </summary>
		/// <param name="level">The level.</param>
		/// <returns>True if enabled, false otherwise</returns>
		bool IsEnabled(LogLevel level);

		/// <summary>
		///     Logs a message at the specified level.
		/// </summary>
		/// <param name="level">The level.</param>
		/// <param name="format">The format.</param>
		/// <param name="owner">The owner.</param>
		/// <param name="args">The format args.</param>
		void Log(LogLevel level, string format, object owner, params object[] args);

		/// <summary>
		///     Logs the exception at the specified level.
		/// </summary>
		/// <param name="level">The level.</param>
		/// <param name="exception">The exception.</param>
		/// <param name="owner">The owner.</param>
		/// <param name="message">The message.</param>
		void LogException(LogLevel level, Exception exception, object owner, string message = null);
	}
}