using System;

namespace FlintLib.Diagnostics
{
	/// <summary>
	/// 
	/// </summary>
	public static class LoggerFactory
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="logFilePath"></param>
		/// <returns></returns>
		public static IExceptionLogger CreateExceptionLogger(string logFilePath) => new ExceptionLogger(logFilePath);
	}
}
