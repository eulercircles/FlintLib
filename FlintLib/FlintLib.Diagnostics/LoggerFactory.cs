using System;

namespace FlintLib.Diagnostics
{
	public class LoggerFactory
	{
		public IExceptionLogger CreateExceptionLogger(string logFilePath) => new ExceptionLogger(logFilePath);
	}
}
