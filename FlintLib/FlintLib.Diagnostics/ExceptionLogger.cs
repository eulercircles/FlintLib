using System;
using System.IO;

using FlintLib.Utilities;

namespace FlintLib.Diagnostics
{
	internal class ExceptionLogger : IExceptionLogger
	{
		private string _logFilePath;

		internal ExceptionLogger(string logFilePath)
		{
			_logFilePath = logFilePath.Validate().NormalizeSpacing();

			if (!Directory.Exists(logFilePath))
			{ Directory.CreateDirectory(logFilePath); }
		}

		public void LogException(Exception exception)
		{
			if (exception != null)
			{

			}
			else { /* Do nothing. */ }
		}
	}
}
