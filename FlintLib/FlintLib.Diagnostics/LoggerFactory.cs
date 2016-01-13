using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlintLib.Diagnostics
{
	public class LoggerFactory
	{
		public ILogger CreateLogger(string logFilePath) { return new Logger(logFilePath); }
	}
}
