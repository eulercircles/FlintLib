using System;

namespace FlintLib.MVVM
{
	public abstract class MediatorArgs
	{
		public string SenderType { get; protected set; }

		public MediatorArgs(object sender)
		{
			SenderType = sender.GetType().ToString();
		}
	}
}
