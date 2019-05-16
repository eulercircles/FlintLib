using System;
using System.Linq;
using System.Diagnostics;

namespace FLib.Common
{
	public class SafeEvent<T> where T : EventArgs
	{
		private EventHandler<T> _event;
		
		/// <summary>
		/// Subscribes the handler method to the event. If the handler method is already subscribed, it will *not* be subscribed again.
		/// </summary>
		/// <param name="handler"></param>
		public void Subscribe(EventHandler<T> handler)
		{
			Debug.Assert(handler != null);
			if (_event == null || !_event.GetInvocationList().Contains(handler)) { _event += handler; }
		}

		/// <summary>
		/// Unsubscribes the handler method from the event.
		/// </summary>
		/// <param name="handler"></param>
		/// <
		public void Unsubscribe(EventHandler<T> handler)
		{
			Debug.Assert(handler != null);
			if (_event != null && _event.GetInvocationList().Contains(handler)) { _event -= handler; }
		}

		/// <summary>
		/// Invokes the event.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		public void Invoke(object sender, T args) => _event?.Invoke(sender, args);
	}

	public class Event<T> where T : EventArgs
	{
		private readonly SafeEvent<T> _innerEvent;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="innerEvent"></param>
		/// <exception cref="ArgumentNullException">If the innerEvent is null.</exception>
		public Event(SafeEvent<T> innerEvent)
		{
			_innerEvent = innerEvent ?? throw new ArgumentNullException(nameof(innerEvent));
		}

		/// <summary>
		/// Subscribes the handler method to the event. If the handler method is already subscribed, it will *not* be subscribed again.
		/// </summary>
		/// <param name="handler"></param>
		public void Subscribe(EventHandler<T> handler) => _innerEvent.Subscribe(handler);

		/// <summary>
		/// Unsubscribes the handler method from the event.
		/// </summary>
		/// <param name="handler"></param>
		public void Unsubscribe(EventHandler<T> handler) => _innerEvent.Unsubscribe(handler);
	}
}
