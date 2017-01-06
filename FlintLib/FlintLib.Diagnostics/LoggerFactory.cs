using System;

namespace FlintLib.Diagnostics
{
	using Internals;

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
		public static ILogger CreateFileLogger(string logFilePath) => new FileLogger(logFilePath);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="connectionString"></param>
		/// <returns></returns>
		public static ILogger CreateDatabaseLogger(string connectionString) => new DatabaseLogger(connectionString);
	}
}
