using System;

namespace FlintLib.Diagnostics.Internals
{
	internal class DatabaseLogger : ILogger
	{
		internal DatabaseLogger(string connectionString)
		{

		}

		public void WriteEntry(string message)
		{
			throw new NotImplementedException();
		}

		public void WriteEntry(Exception exception, string message = "")
		{
			throw new NotImplementedException();
		}
	}
}
