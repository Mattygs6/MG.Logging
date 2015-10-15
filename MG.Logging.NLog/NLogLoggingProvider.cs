namespace MG.Logging.NLog
{
	using System;
	using System.Collections.Generic;

	using global::NLog;

	/// <summary>
	///     The NLog logging provider
	/// </summary>
	public class NLogLoggingProvider : ILoggingProvider
	{
		private readonly ILogger nullLogger;

		/// <summary>
		///     Initializes a new instance of the <see cref="NLogLoggingProvider" /> class.
		/// </summary>
		public NLogLoggingProvider()
		{
			nullLogger = LogManager.CreateNullLogger();
		}

		#region ILoggingProvider Members

		/// <summary>
		///     Determines whether the specified level is enabled for this logging provider.
		/// </summary>
		/// <param name="level">The level.</param>
		/// <returns>
		///     True if enabled, false otherwise
		/// </returns>
		public bool IsEnabled(global::MG.Logging.LogLevel level)
		{
			switch (level)
			{
				case global::MG.Logging.LogLevel.Info:
				case global::MG.Logging.LogLevel.Audit:
					return nullLogger.IsInfoEnabled;
				case global::MG.Logging.LogLevel.Debug:
					return nullLogger.IsDebugEnabled;
				case global::MG.Logging.LogLevel.Error:
					return nullLogger.IsErrorEnabled;
				case global::MG.Logging.LogLevel.Verbose:
					return nullLogger.IsTraceEnabled;
				case global::MG.Logging.LogLevel.Warn:
					return nullLogger.IsWarnEnabled;
				case global::MG.Logging.LogLevel.Fatal:
					return nullLogger.IsFatalEnabled;
				case global::MG.Logging.LogLevel.All:
					return nullLogger.IsFatalEnabled;
				default:
					return true;
			}
		}

		/// <summary>
		///     Logs a message at the specified level.
		/// </summary>
		/// <param name="level">The level.</param>
		/// <param name="owner">The owner.</param>
		/// <param name="format">The format.</param>
		/// <param name="args">The format args.</param>
		public void Log(global::MG.Logging.LogLevel level, object owner, string format, params object[] args)
		{
			Log(level, format, owner, null, args);
		}

		/// <summary>
		///     Logs the exception at the specified level.
		/// </summary>
		/// <param name="level">The level.</param>
		/// <param name="exception">The exception.</param>
		/// <param name="owner">The owner.</param>
		/// <param name="message">The message.</param>
		public void LogException(global::MG.Logging.LogLevel level, Exception exception, object owner, string message = null)
		{
			Log(level, message ?? exception.Message, owner, exception);
		}

		#endregion

		/// <summary>
		///     Gets the logger.
		/// </summary>
		/// <param name="owner">The owner.</param>
		/// <returns></returns>
		public virtual ILogger GetLogger(object owner)
		{
			if (owner != null)
			{
				var name = owner as string;
				if (!string.IsNullOrWhiteSpace(name))
				{
					return LogManager.GetLogger(name);
				}

				var type = owner as Type ?? owner.GetType();

				return LogManager.GetLogger(type.Name);
			}

			return nullLogger;
		}

		/// <summary>
		///     Logs the specified level.
		/// </summary>
		/// <param name="level">The level.</param>
		/// <param name="format">The format.</param>
		/// <param name="owner">The owner.</param>
		/// <param name="exception">The exception.</param>
		/// <param name="args">The arguments.</param>
		public void Log(
			global::MG.Logging.LogLevel level,
			string format,
			object owner,
			Exception exception = null,
			params object[] args)
		{
			try
			{
				var logger = GetLogger(owner);
				var msg = SafeFormat(format, args);
				switch (level)
				{
					case global::MG.Logging.LogLevel.Info:
						logger.Info(msg);
						break;
					case global::MG.Logging.LogLevel.Debug:
						logger.Debug(msg);
						break;
					case global::MG.Logging.LogLevel.Verbose:
						logger.Trace(msg);
						break;
					case global::MG.Logging.LogLevel.Audit:
						logger.Info(string.Format("AUDIT: {0}", msg));
						break;
					case global::MG.Logging.LogLevel.Error:
						logger.Error(exception, msg);
						break;
					case global::MG.Logging.LogLevel.Warn:
						logger.Warn(exception, msg);
						break;
					case global::MG.Logging.LogLevel.Fatal:
						logger.Fatal(exception, msg);
						break;
				}
			}
			catch
			{
				// ignored
			}
		}

		/// <summary>
		///     Safely formats the message
		/// </summary>
		/// <param name="format">The format.</param>
		/// <param name="args">The args.</param>
		/// <returns>The formatted message</returns>
		private static string SafeFormat(string format, IReadOnlyList<object> args)
		{
			if (args != null && args.Count > 0)
			{
				for (var i = 0; i < args.Count; i++)
				{
					var formatKey = string.Format("{{{0}}}", i);

					if (format.Contains(formatKey))
					{
						format = format.Replace(formatKey, args[i].ToString());
					}
				}
			}

			return format;
		}
	}
}