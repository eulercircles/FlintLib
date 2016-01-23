using System;
using System.IO;

using FlintLib.Utilities;

namespace FlintLib.Diagnostics
{
	internal class ExceptionLogger : IExceptionLogger
	{
		private const string _defaultExtension = "log";

		private readonly string _logFileDirectory;
		private readonly string _prepend;
		private readonly string _append;
		private readonly string _extension = _defaultExtension;

		internal ExceptionLogger(string logFileDirectory)
		{
			_logFileDirectory = logFileDirectory.Validate().NormalizeSpacing().Trim();

			if (!Directory.Exists(logFileDirectory))
			{ Directory.CreateDirectory(logFileDirectory); }
		}

		internal ExceptionLogger(string logFileDirectory, string prepend, string append, string extension)
		{
			_extension = extension;
		}

		public void LogException(Exception exception)
		{
			LogException(null, exception);
		}

		public void LogException(string prefaceInfo, Exception exception)
		{
			if (exception != null)
			{
				using (var streamWriter = _getStreamWriter())
				{
					if (prefaceInfo != null)
					{ streamWriter.WriteLine(prefaceInfo.Trim().Validate()); }
					streamWriter.WriteLine(exception.ToString());
				}
			}
			else { /* Do nothing. */ }
		}

		private StreamWriter _getStreamWriter()
		{
			var fullPath = Path.Combine(_logFileDirectory, _generateFileName());
			return new StreamWriter(fullPath);
		}

		private string _generateFileName()
		{
			return string.Format("{0}-{1}-{2}-{3}", _prepend, DateTime.Now.ToString("yyyyMMdd-HH"), _append, _extension);
		}
	}
}
