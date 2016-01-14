using System;

namespace FlintLib.Diagnostics
{
	public interface ILogger
	{
		void LogException(Exception exception);
	}
}
