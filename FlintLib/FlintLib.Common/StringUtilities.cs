using System;
using System.Text.RegularExpressions;

using FlintLib.Common.Resources;

namespace FlintLib.Common
{
	public static class StringUtilities
	{
		public static string NewLines(int count)
		{
			if (count < 1) { throw new ArgumentOutOfRangeException("Must be greater than zero.", nameof(count)); }

			var result = string.Empty;
			for (int i = 0; i < count; i++)
			{ result += Environment.NewLine; }
			return result;
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
				return string.IsNullOrWhiteSpace(item);
			}
			else { throw new ArgumentException(nameof(item)); }
		}

		public static string NormalizeSpacing(this string item)
		{
			if (item != null) { return Regex.Replace(item, @"\s+", " "); }
			else { return null; }
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
				throw new ArgumentException(ErrorStrings.StringIsEmpty);
			}
			else if (string.IsNullOrWhiteSpace(item))
			{
				// Since null has already been checked and handled, we only have to worry about it being white space.
				throw new ArgumentException(ErrorStrings.StringIsWhiteSpace);
			}
			else { return item; }
		}
	}
}
