using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FLibXamarin.Common
{
	public delegate void SingleSubscriptionEventHandler<T>(object sender, T args) where T : EventArgs;

	public class SingleSubscriptionEvent<T> where T : EventArgs
	{
		private SingleSubscriptionEventHandler<T> _event;
		public event SingleSubscriptionEventHandler<T> Event
		{
			add
			{
				if (_event == null || !_event.GetInvocationList().Contains(value))
				{
					_event += value;
				}
			}
			remove { _event -= value; }
		}

		public SingleSubscriptionEvent(SingleSubscriptionEventHandler<T> eventDelegate)
		{
			_event = eventDelegate;
		}
	}
}
