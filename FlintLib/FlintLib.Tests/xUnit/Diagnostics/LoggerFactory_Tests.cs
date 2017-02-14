using System;
using System.IO;

using Xunit;

using FlintLib.Diagnostics;

namespace FlintLib.Tests.xUnit.Diagnostics
{
	public class LoggerFactory_Tests
	{
		[Fact]
		public void TestCreateTextFileLogger()
		{
			var textFileLogger = LoggerFactory.CreateTextFileLogger(Directory.GetCurrentDirectory());

			Assert.NotNull(textFileLogger);
			Assert.True(textFileLogger is ILogger);
		}
	}
}
