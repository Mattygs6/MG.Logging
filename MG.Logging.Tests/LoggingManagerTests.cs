namespace MG.Logging.Tests
{
	using System;

	using Moq;

	using NUnit.Framework;

	[TestFixture]
	public class LoggingManagerTests
	{
		[Test]
		public void Debug_Calls_ILoggingProvider_Level_Debug()
		{
			var loggingProviderMock1 = new Mock<ILoggingProvider>();
			var loggingProviderMock2 = new Mock<ILoggingProvider>();
			var loggingManager = new LoggingManager(new[] { loggingProviderMock1.Object, loggingProviderMock2.Object });

			loggingManager.Debug(this, "message");

			loggingProviderMock1.Verify(x => x.Log(LogLevel.Debug, this, "message"), Times.Exactly(1));
			loggingProviderMock2.Verify(x => x.Log(LogLevel.Debug, this, "message"), Times.Exactly(1));
		}


		[Test]
		public void Error_ApplicationException_Calls_ILoggingProvider_LogException_Level_Error()
		{
			var loggingProviderMock1 = new Mock<ILoggingProvider>();
			var loggingProviderMock2 = new Mock<ILoggingProvider>();
			var loggingManager = new LoggingManager(new[] { loggingProviderMock1.Object, loggingProviderMock2.Object });

			var ex = new ApplicationException("error");

			loggingManager.Exception(ex, this, "message");

			loggingProviderMock1.Verify(x => x.LogException(LogLevel.Error, ex, this, "message"), Times.Exactly(1));
			loggingProviderMock2.Verify(x => x.LogException(LogLevel.Error, ex, this, "message"), Times.Exactly(1));
		}

		[Test]
		public void Error_Calls_ILoggingProvider_Level_Error()
		{
			var loggingProviderMock1 = new Mock<ILoggingProvider>();
			var loggingProviderMock2 = new Mock<ILoggingProvider>();
			var loggingManager = new LoggingManager(new[] { loggingProviderMock1.Object, loggingProviderMock2.Object });

			loggingManager.Error(this, "message");

			loggingProviderMock1.Verify(x => x.Log(LogLevel.Error, this, "message"), Times.Exactly(1));
			loggingProviderMock2.Verify(x => x.Log(LogLevel.Error, this, "message"), Times.Exactly(1));
		}

		[Test]
		public void Info_Calls_ILoggingProvider_Level_Info()
		{
			var loggingProviderMock1 = new Mock<ILoggingProvider>();
			var loggingProviderMock2 = new Mock<ILoggingProvider>();
			var loggingManager = new LoggingManager(new[] { loggingProviderMock1.Object, loggingProviderMock2.Object });

			loggingManager.Info(this, "message");

			loggingProviderMock1.Verify(x => x.Log(LogLevel.Info, this, "message"), Times.Exactly(1));
			loggingProviderMock2.Verify(x => x.Log(LogLevel.Info, this, "message"), Times.Exactly(1));
		}

		[Test]
		public void Log_FourLoggingProviders_Calls_ILoggingProvider_Log()
		{
			var loggingProviderMock0 = new Mock<ILoggingProvider>();
			var loggingProviderMock1 = new Mock<ILoggingProvider>();
			var loggingProviderMock2 = new Mock<ILoggingProvider>();
			var loggingProviderMock3 = new Mock<ILoggingProvider>();


			var loggingManager = new LoggingManager(new[]
			{
				loggingProviderMock0.Object,
				loggingProviderMock1.Object,
				loggingProviderMock2.Object,
				loggingProviderMock3.Object
			});

			loggingManager.Log(LogLevel.Info, this, "1: {0}, 2: {1}, 3: {2}", 1, 2, 3);

			loggingProviderMock0.Verify(x => x.Log(LogLevel.Info, this, "1: {0}, 2: {1}, 3: {2}", 1, 2, 3), Times.Exactly(1));
			loggingProviderMock1.Verify(x => x.Log(LogLevel.Info, this, "1: {0}, 2: {1}, 3: {2}", 1, 2, 3), Times.Exactly(1));
			loggingProviderMock2.Verify(x => x.Log(LogLevel.Info, this, "1: {0}, 2: {1}, 3: {2}", 1, 2, 3), Times.Exactly(1));
			loggingProviderMock3.Verify(x => x.Log(LogLevel.Info, this, "1: {0}, 2: {1}, 3: {2}", 1, 2, 3), Times.Exactly(1));
		}

		[Test]
		public void Log_Message_Calls_ILoggingProvider_Log()
		{
			var loggingProviderMock1 = new Mock<ILoggingProvider>();
			var loggingProviderMock2 = new Mock<ILoggingProvider>();
			var loggingManager = new LoggingManager(new[] { loggingProviderMock1.Object, loggingProviderMock2.Object });


			loggingManager.Log(LogLevel.Info, this, "1: {0}, 2: {1}, 3: {2}", 1, 2, 3);

			loggingProviderMock1.Verify(x => x.Log(LogLevel.Info, this, "1: {0}, 2: {1}, 3: {2}", 1, 2, 3), Times.Exactly(1));
			loggingProviderMock2.Verify(x => x.Log(LogLevel.Info, this, "1: {0}, 2: {1}, 3: {2}", 1, 2, 3), Times.Exactly(1));
		}

		[Test]
		public void LogException_Calls_ILoggingProvider_LogException()
		{
			var loggingProviderMock1 = new Mock<ILoggingProvider>();
			var loggingProviderMock2 = new Mock<ILoggingProvider>();
			var loggingManager = new LoggingManager(new[] { loggingProviderMock1.Object, loggingProviderMock2.Object });

			var ex = new ApplicationException("info");

			loggingManager.LogException(LogLevel.Info, ex, this);

			loggingProviderMock1.Verify(x => x.LogException(LogLevel.Info, ex, this, null), Times.Exactly(1));
			loggingProviderMock2.Verify(x => x.LogException(LogLevel.Info, ex, this, null), Times.Exactly(1));
		}

		[Test]
		public void LogException_Message_Calls_ILoggingProvider_LogException()
		{
			var loggingProviderMock1 = new Mock<ILoggingProvider>();
			var loggingProviderMock2 = new Mock<ILoggingProvider>();
			var loggingManager = new LoggingManager(new[] { loggingProviderMock1.Object, loggingProviderMock2.Object });

			var ex = new ApplicationException("info");

			loggingManager.LogException(LogLevel.Info, ex, this, "message");

			loggingProviderMock1.Verify(x => x.LogException(LogLevel.Info, ex, this, "message"), Times.Exactly(1));
			loggingProviderMock2.Verify(x => x.LogException(LogLevel.Info, ex, this, "message"), Times.Exactly(1));
		}


		[Test]
		public void Warn_ApplicationException_Calls_ILoggingProvider_LogException_Level_Warn()
		{
			var loggingProviderMock1 = new Mock<ILoggingProvider>();
			var loggingProviderMock2 = new Mock<ILoggingProvider>();
			var loggingManager = new LoggingManager(new[] { loggingProviderMock1.Object, loggingProviderMock2.Object });

			var ex = new ApplicationException("warn");

			loggingManager.Warn(ex, this, "message");

			loggingProviderMock1.Verify(x => x.LogException(LogLevel.Warn, ex, this, "message"), Times.Exactly(1));
			loggingProviderMock2.Verify(x => x.LogException(LogLevel.Warn, ex, this, "message"), Times.Exactly(1));
		}


		[Test]
		public void Warn_Calls_ILoggingProvider_Level_Warn()
		{
			var loggingProviderMock1 = new Mock<ILoggingProvider>();
			var loggingProviderMock2 = new Mock<ILoggingProvider>();
			var loggingManager = new LoggingManager(new[] { loggingProviderMock1.Object, loggingProviderMock2.Object });

			loggingManager.Warn(this, "message");

			loggingProviderMock1.Verify(x => x.Log(LogLevel.Warn, this, "message"), Times.Exactly(1));
			loggingProviderMock2.Verify(x => x.Log(LogLevel.Warn, this, "message"), Times.Exactly(1));
		}
	}
}