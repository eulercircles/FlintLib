using System;
using System.Linq;

namespace FLib.Common
{
	public class SafeEvent<T> where T : EventArgs
	{
		private EventHandler<T> _event;

		public void Subscribe(EventHandler<T> handler)
		{
			if (_event == null || !_event.GetInvocationList().Contains(handler)) { _event += handler; }
		}

		public void Unsubscribe(EventHandler<T> handler)
		{
			if (_event != null && _event.GetInvocationList().Contains(handler)) { _event -= handler; }
		}

		public void Invoke(object sender, T args) => _event?.Invoke(sender, args);
	}

	public class Event<T> where T : EventArgs
	{
		private readonly SafeEvent<T> _innerEvent;

		public Event(SafeEvent<T> innerEvent)
		{
			_innerEvent = innerEvent ?? throw new ArgumentNullException(nameof(innerEvent));
		}

		public void Subscribe(EventHandler<T> handler) => _innerEvent.Subscribe(handler);

		public void Unsubscribe(EventHandler<T> handler) => _innerEvent.Unsubscribe(handler);
	}
}
