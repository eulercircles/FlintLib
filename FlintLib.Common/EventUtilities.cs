using System;
using System.Linq;

namespace FlintLib.Common
{
	public static class EventUtilities
	{
		public static void Subscribe(EventHandler source, EventHandler value)
		{
			if (source == null || !source.GetInvocationList().Contains(value))
			{ source += value; }
		}

		public static void Unsubscribe(EventHandler source, EventHandler value)
		{
			if (source != null && source.GetInvocationList().Contains(value))
			{ source -= value; }
		}

		public static void Subscribe<T>(EventHandler<T> source, EventHandler<T> value) where T : EventArgs
		{
			if (source == null || !source.GetInvocationList().Contains(value))
			{ source += value; }
		}

		public static void Unsubscribe<T>(EventHandler<T> source, EventHandler<T> value) where T : EventArgs
		{
			if (source != null && source.GetInvocationList().Contains(value))
			{ source -= value; }
		}
	}
}
