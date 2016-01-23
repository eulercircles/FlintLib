using System;



namespace FlintLib.Utilities
{
	public static class Preconditions
	{
		public static T CheckNotNull<T>(T item) where T : class
		{
			if (item != null) { return item; }
			else { throw new ArgumentNullException(); }
		}
	}
}
