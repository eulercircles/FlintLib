using System;
using System.Text.RegularExpressions;

namespace FlintLib.Utilities
{
	public static class StringUtilities
	{
		public static string DoubleCarriageReturn { get { return (Environment.NewLine + Environment.NewLine); } }

		public static bool IsNull(this string item)
		{
			if (item == null) { return true; }
			else { return false; }
		}

		public static bool IsEmpty(this string item)
		{
			if (item == string.Empty) { return true; }
			else { return false; }
		}

		public static bool IsWhitespace(this string item)
		{
			if (string.IsNullOrWhiteSpace(item))
			{
				if (item == null) { return false; }
				else { return true; }
			}
			else { return false; }
		}

		public static string NormalizeSpacing(this string item)
		{
			if (item != null) { return Regex.Replace(item, @"\s+", " "); }
			else { return null; }
		}

		/// <summary>
		/// Checks if a string is null, empty, or white space.
		/// </summary>
		/// <param name="item"></param>
		/// <returns>Null if string is not null, not empty, and not white space and an Exception if otherwise.</returns>
		public static Exception CheckString(string item)
		{
			Exception result = null;

			if (string.IsNullOrEmpty(item))
			{
				if (item == null) { result = new Exception("String is null."); }
				else { result = new Exception("String is empty."); }
			}
			else if (string.IsNullOrWhiteSpace(item))
			{
				result = new Exception("String is white space.");
			}
			else { }

			return result;
		}
	}
}
