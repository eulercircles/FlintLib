using System;

namespace FLib.Diagnostics
{
	public static class LoggerFactory
	{
		public static IExceptionLogger CreateExceptionLogger(string logFilePath) => new ExceptionLogger(logFilePath);
	}
}
