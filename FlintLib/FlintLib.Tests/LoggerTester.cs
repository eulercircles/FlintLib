using System;
using System.IO;

using FlintLib.Diagnostics;

namespace FlintLib.Tests
{
	class LoggerTester
	{

		public void TestTextFileLogger()
		{
			var today = DateTime.Today;
			var folderName = $"{today.Year}-{today.Month.ToString("D2")} {today.ToString("MMMM")}";

			var logDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Logs", folderName);

			var logger = LoggerFactory.CreateTextFileLogger(logDirectory);

			logger.WriteEntry("First Entry.");

			try
			{
				ThrowException();
			}
			catch (Exception ex)
			{
				logger.WriteEntry(ex);
			}
		}

		private void ThrowException()
		{
			throw new NotImplementedException("This exception was thrown intentionally.");
		}
	}
}
