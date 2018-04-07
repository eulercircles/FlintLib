using System;

namespace FlintLib.Diagnostics
{
	/// <summary>
	/// 
	/// </summary>
	public interface IExceptionLogger
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="exception"></param>
		void LogException(Exception exception);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="prefaceInfo"></param>
		/// <param name="exception"></param>
		void LogException(string prefaceInfo, Exception exception);
	}
}
