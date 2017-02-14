using System;

namespace FlintLib.Diagnostics
{
	/// <summary>
	/// 
	/// </summary>
	public interface ILogger
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="message"></param>
		void WriteEntry(string message);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="message"></param>
		/// <param name="exception"></param>
		void WriteEntry(Exception exception, string message = "");
	}
}
