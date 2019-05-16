using System;

namespace FLib.Diagnostics
{
	public interface ILogger
	{
		void WriteEntry(LogEntry entry);
	}
}
