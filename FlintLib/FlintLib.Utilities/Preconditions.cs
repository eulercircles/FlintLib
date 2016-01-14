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

		/// <summary>
		/// Checks if a string is null, empty, or white space.
		/// </summary>
		/// <param name="item">The string to validate.</param>
		/// <returns>The checked string.</returns>
		public static string Validate(this string item)
		{
			if (item == null)
			{
				throw new ArgumentNullException();
			}
			else if (string.IsNullOrEmpty(item))
			{
				// Since null has already been checked and handled, we only have to worry about it being empty.
				throw new ArgumentException("This string is empty.");
			}
			else if (string.IsNullOrWhiteSpace(item))
			{
				// Since null has already been checked and handled, we only have to worry about it being white space.
				throw new ArgumentException("This string is white space");
			}
			else { return item; }
		}
	}
}
