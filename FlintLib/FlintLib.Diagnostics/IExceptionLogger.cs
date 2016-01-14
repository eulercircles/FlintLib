using System;

namespace FlintLib.Diagnostics
{
	public interface IExceptionLogger
	{
		void LogException(Exception exception);
	}
}
