using System;
using System.IO;

using FlintLib.Utilities;

namespace FlintLib.Diagnostics
{
	internal class ExceptionLogger : IExceptionLogger
	{
		private readonly string _logFileDirectory;
		private readonly string _prependedText;
		private readonly string _appendedText;
		private readonly string _extension;

		internal ExceptionLogger(string logFileDirectory, string prepend = "", string append = "", string extension = "log")
		{
			_logFileDirectory = logFileDirectory.Validate().NormalizeSpacing().Trim();

			if (!Directory.Exists(logFileDirectory))
			{ Directory.CreateDirectory(logFileDirectory); }

			_prependedText = prepend;
			_appendedText = append;
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
			return $"{_prependedText}-{DateTime.Now.ToString("yyyyMMdd-HH")}-{_appendedText}.{_extension}";
		}
	}
}
