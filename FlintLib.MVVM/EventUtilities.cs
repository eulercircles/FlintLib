using System;
using System.ComponentModel;
using System.Linq;

namespace FlintLib.MVVM
{
	public static class EventUtilities
	{
		public static void Subscribe(PropertyChangedEventHandler source, PropertyChangedEventHandler value)
		{
			if (source == null || !source.GetInvocationList().Contains(value))
			{ source += value; }
		}

		public static void Unsubscribe(PropertyChangedEventHandler source, PropertyChangedEventHandler value)
		{
			if (source != null && source.GetInvocationList().Contains(value))
			{ source -= value; }
		}
	}
}
