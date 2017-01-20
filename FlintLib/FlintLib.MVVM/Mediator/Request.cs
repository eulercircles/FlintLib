using System;

namespace FlintLib.MVVM.Mediator
{
	/// <summary>
	/// 
	/// </summary>
	public abstract class Request
	{
		/// <summary>
		/// 
		/// </summary>
		public string SenderType { get; private set; }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		public Request(object sender)
		{
			SenderType = sender.GetType().ToString();
		}
	}
}
