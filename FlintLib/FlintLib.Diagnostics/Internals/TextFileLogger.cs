using System;
using System.IO;
using System.Diagnostics;

using FlintLib.Utilities;

namespace FlintLib.Diagnostics.Internals
{
	internal class TextFileLogger : ILogger
	{
		private const string _defaultExtension = ".log";

		private string CurrentTime { get { return DateTime.Now.ToShortTimeString(); } }

		private readonly string _logDirectory;
		private readonly string _prependedText;
		private readonly string _appendedText;
		private readonly string _extension;

		private Func<string> _getSubDirectory;
		private Func<string> _getFileName;

		internal TextFileLogger(string initialDirectory, string prepend = "", string append = "", 
			string extension = _defaultExtension, Func<string> getSubDirectory = null, Func<string> getFileName = null)
		{
			if (string.IsNullOrWhiteSpace(initialDirectory))
			{ throw new ArgumentOutOfRangeException("The initial directory is not valid."); }

			_logDirectory = initialDirectory;
			_prependedText = prepend;
			_appendedText = append;

			if (!string.IsNullOrWhiteSpace(extension))
			{
				_extension = extension;
			}
			else
			{
				if (!extension.StartsWith(".")) { extension = extension.Insert(0, "."); }
				_extension = extension;
			}

			_getSubDirectory = getSubDirectory;
			_getFileName = getFileName;

			if (!Directory.Exists(initialDirectory))
			{
				Directory.CreateDirectory(initialDirectory);
			}
		}

		#region ILogger Implementation
		public void WriteEntry(string message)
		{
			Debug.Assert(!string.IsNullOrWhiteSpace(message));

			if (!string.IsNullOrWhiteSpace(message))
			{
				using (var streamWriter = GetStreamWriter())
				{
					streamWriter.WriteLine($"== {CurrentTime} ==============================");
					streamWriter.WriteLine("[MESSAGE]");
					streamWriter.WriteLine(message);
					streamWriter.WriteLine();
				}
			}
		}

		public void WriteEntry(Exception exception, string message = "")
		{
			Debug.Assert(exception != null);

			if (exception != null)
			{
				using (var streamWriter = GetStreamWriter())
				{
					streamWriter.WriteLine($"== {CurrentTime} ==============================");
					
					if (!string.IsNullOrWhiteSpace(message))
					{
						streamWriter.WriteLine("[MESSAGE]");
						streamWriter.WriteLine(message);
					}

					streamWriter.WriteLine("[EXCEPTION]");
					streamWriter.WriteLine(exception.ToString());
					streamWriter.WriteLine();
				}
			}
			else { /* Do nothing. */ }
		}
		#endregion ILogger Implementation

		#region Private Methods
		private StreamWriter GetStreamWriter()
		{
			var fullPath = Path.Combine(_logDirectory, GetCorrectFileName());

			return File.AppendText(fullPath);
		}

		private string GetCorrectFileName()
		{
			if (_getFileName != null)
			{
				return _getFileName();
			}
			else
			{
				string prepend = string.Empty;
				if (!string.IsNullOrEmpty(_prependedText))
				{ prepend = $"{_prependedText}-"; }

				string append = string.Empty;
				if (!string.IsNullOrEmpty(_appendedText))
				{ append = $"-{_appendedText}"; }

				return $"{prepend}{DateTime.Now.ToString("yyyyMMdd-HH")}{append}{_extension}";
			}
		}
		#endregion Private Methods
	}
}
