namespace MG.Logging.Owin.Logging
{
	using System;
	using System.Diagnostics;

	using global::Owin;

	using Microsoft.Owin.Logging;

	public static class Extensions
	{
		public static void UseLoggingManager(this IAppBuilder appBuilder)
		{
			appBuilder.SetLoggerFactory(new LoggingManagerFactory());
		}

		public static void UseLoggingManager(this IAppBuilder appBuilder, Func<TraceEventType, LogLevel> getLogLevel)
		{
			appBuilder.SetLoggerFactory(new LoggingManagerFactory(getLogLevel));
		}
	}
}