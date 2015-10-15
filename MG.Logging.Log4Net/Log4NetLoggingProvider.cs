namespace MG.Logging.Log4Net
{
	using System;
	using System.Collections.Generic;

	using log4net;
	using log4net.Config;
	using log4net.Core;

	/// <summary>
	///     The log4net logging provider
	/// </summary>
	public class Log4NetLoggingProvider : ILoggingProvider
	{
		private readonly ILog nullLogger;

		/// <summary>
		///     Initializes a new instance of the <see cref="Log4NetLoggingProvider" /> class.
		/// </summary>
		public Log4NetLoggingProvider()
		{
			XmlConfigurator.Configure();
			nullLogger = LogManager.GetLogger("[Null]");
		}

		#region ILoggingProvider Members

		/// <summary>
		///     Determines whether the specified level is enabled for this logging provider.
		/// </summary>
		/// <param name="level">The level.</param>
		/// <returns>
		///     True if enabled, false otherwise
		/// </returns>
		public bool IsEnabled(LogLevel level)
		{
			switch (level)
			{
				case LogLevel.Info:
				case LogLevel.Audit:
					return nullLogger.IsInfoEnabled;
				case LogLevel.Debug:
					return nullLogger.IsDebugEnabled;
				case LogLevel.Error:
					return nullLogger.IsErrorEnabled;
				case LogLevel.Verbose:
					return nullLogger.Logger.IsEnabledFor(Level.Verbose);
				case LogLevel.Warn:
					return nullLogger.IsWarnEnabled;
				case LogLevel.Fatal:
					return nullLogger.IsFatalEnabled;
				case LogLevel.All:
					return nullLogger.Logger.IsEnabledFor(Level.All);
				default:
					return true;
			}
		}

		/// <summary>
		///     Logs a message at the specified level.
		/// </summary>
		/// <param name="level">The level.</param>
		/// <param name="format">The format.</param>
		/// <param name="owner">The owner.</param>
		/// <param name="args">The format args.</param>
		public void Log(LogLevel level, string format, object owner, params object[] args)
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
		public void LogException(LogLevel level, Exception exception, object owner, string message = null)
		{
			Log(level, message ?? exception.Message, owner, exception);
		}

		#endregion

		/// <summary>
		///     Gets the logger.
		/// </summary>
		/// <param name="owner">The owner.</param>
		/// <returns></returns>
		public virtual ILog GetLogger(object owner)
		{
			if (owner != null)
			{
				var type = owner as Type;
				if (type != null)
				{
					return LogManager.GetLogger(type);
				}

				var name = owner as string;
				if (!string.IsNullOrWhiteSpace(name))
				{
					return LogManager.GetLogger(name);
				}

				return LogManager.GetLogger(owner.GetType());
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
		public void Log(LogLevel level, string format, object owner, Exception exception = null, params object[] args)
		{
			try
			{
				var logger = GetLogger(owner);
				var msg = SafeFormat(format, args);
				switch (level)
				{
					case LogLevel.Info:
						logger.Info(msg);
						break;
					case LogLevel.Debug:
						logger.Debug(msg);
						break;
					case LogLevel.Verbose:
						logger.Logger.Log(null, Level.Verbose, msg, exception);
						break;
					case LogLevel.Audit:
						logger.Info(string.Format("AUDIT: {0}", msg));
						break;
					case LogLevel.Error:
						logger.Error(msg, exception);
						break;
					case LogLevel.Warn:
						logger.Warn(msg, exception);
						break;
					case LogLevel.Fatal:
						logger.Fatal(msg, exception);
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
						format = format.Replace(formatKey, format[i].ToString());
					}
				}
			}

			return format;
		}
	}
}