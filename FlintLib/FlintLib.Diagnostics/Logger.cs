using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlintLib.Diagnostics
{
	internal class Logger : ILogger
	{
		private string _logFilePath;

		internal Logger(string logFilePath)
		{
			if (!Directory.Exists(logFilePath))
			{ Directory.CreateDirectory(logFilePath); }

			_logFilePath = logFilePath;
		}

		public void LogException(Exception exception)
		{

		}
	}
}
