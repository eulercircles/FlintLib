using System;

namespace FlintLib.Utilities
{
	/// <summary>
	/// 
	/// </summary>
	public static class Preconditions
	{
		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="item"></param>
		/// <returns></returns>
		public static T CheckNotNull<T>(T item) where T : class
		{
			if (item != null) { return item; }
			else { throw new ArgumentNullException(); }
		}
	}
}
