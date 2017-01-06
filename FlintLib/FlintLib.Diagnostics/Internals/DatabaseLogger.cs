using System;

namespace FlintLib.Diagnostics.Internals
{
	internal class DatabaseLogger : ILogger
	{
		internal DatabaseLogger(string connectionString)
		{

		}

		public void WriteEntry(Exception exception)
		{
			throw new NotImplementedException();
		}

		public void WriteEntry(string message)
		{
			throw new NotImplementedException();
		}

		public void WriteEntry(string message, Exception exception)
		{
			throw new NotImplementedException();
		}
	}
}
