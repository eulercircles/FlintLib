using System;
using System.Text.RegularExpressions;

namespace FlintLib.Utilities
{
	public static class StringUtilities
	{
		public static string DoubleNewLine { get { return (Environment.NewLine + Environment.NewLine); } }

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

		public static bool IsWhiteSpace(this string item)
		{
			if (item != null)
			{
				return string.IsNullOrWhiteSpace(item) ? true : false;
			}
			else { throw new ArgumentException(nameof(item)); }
		}

		public static string NormalizeSpacing(this string item)
		{
			if (item != null) { return Regex.Replace(item, @"\s+", " "); }
			else { return null; }
		}
	}
}
