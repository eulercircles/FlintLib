using System;

namespace FLib.Diagnostics
{
	public interface IExceptionLogger
	{
		void LogException(Exception exception);

		void LogException(string prefaceInfo, Exception exception);
	}
}
