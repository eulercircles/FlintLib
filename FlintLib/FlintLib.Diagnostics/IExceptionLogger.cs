using System;

namespace FlintLib.Diagnostics
{
	public interface IExceptionLogger
	{
		void LogException(Exception exception);
		void LogException(string prefaceInfo, Exception exception);
	}
}
