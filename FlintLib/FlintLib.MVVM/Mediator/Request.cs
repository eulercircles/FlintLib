using System;

namespace FlintLib.MVVM.Mediator
{
	public abstract class Request
	{
		public string SenderType { get; protected set; }

		public Request(object sender)
		{
			this.SenderType = sender.GetType().ToString();
		}
	}
}
