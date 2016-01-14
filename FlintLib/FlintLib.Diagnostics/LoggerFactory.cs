using System;

namespace FlintLib.Diagnostics
{
	public class LoggerFactory
	{
		public ILogger CreateLogger(string logFilePath) { return new Logger(logFilePath); }
	}
}
