using System;
using System.IO;

using FlintLib.Utilities;

namespace FlintLib.Diagnostics.Internals
{
	internal class FileLogger : ILogger
	{
		private const string _defaultExtension = "log";

		private readonly string _logFileDirectory;
		private readonly string _prependedText;
		private readonly string _appendedText;
		private readonly string _extension = _defaultExtension;

		internal FileLogger(string logFileDirectory)
		{
			_logFileDirectory = logFileDirectory.Validate().NormalizeSpacing().Trim();

			if (!Directory.Exists(logFileDirectory))
			{ Directory.CreateDirectory(logFileDirectory); }
		}

		internal FileLogger(string logFileDirectory, string prepend, string append, string extension)
		{
			_extension = extension;
		}

		#region ILogger Implementation
		public void WriteEntry(string message)
		{
			throw new NotImplementedException();
		}

		public void WriteEntry(Exception exception)
		{
			WriteEntry(null, exception);
		}

		public void WriteEntry(string prefaceInfo, Exception exception)
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
		#endregion ILogger Implementation

		#region Private Methods
		private StreamWriter _getStreamWriter()
		{
			var fullPath = Path.Combine(_logFileDirectory, _generateFileName());
			return new StreamWriter(fullPath);
		}

		private string _generateFileName()
		{
			return string.Format("{0}-{1}-{2}-{3}", _prependedText, DateTime.Now.ToString("yyyyMMdd-HH"), _appendedText, _extension);
		}
		#endregion Private Methods
	}
}
