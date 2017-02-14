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
		/// <param name="initialDirectory">The base directory where log files will be created.</param>
		/// <param name="prepend">Custom text to prepend to the log file name.</param>
		/// <param name="append">Custom text to append to the log file name.</param>
		/// <param name="extension">The file extension of the log file.</param>
		/// <param name="getSubDirectory">
		/// A delegate that implements user-defined logic to create a subdirectory of the initial directory. 
		/// Use this to programmatically keep log files organized in folders.
		/// </param>
		/// <param name="getFileName">
		/// A delegate that implements user-defined logic to create a name for the log file.
		/// </param>
		/// <returns>
		/// An object that writes entries to a log file in plain text format.
		/// </returns>
		public static ILogger CreateTextFileLogger(string initialDirectory, string prepend = "", string append = "",
			string extension = ".log", Func<string> getSubDirectory = null, Func<string> getFileName = null)
			=> new TextFileLogger(initialDirectory, prepend, append, extension, getSubDirectory, getFileName);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="connectionString"></param>
		/// <returns></returns>
		public static ILogger CreateDatabaseLogger(string connectionString) => new DatabaseLogger(connectionString);
	}
}
