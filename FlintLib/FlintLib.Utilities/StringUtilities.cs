using System;
using System.Text.RegularExpressions;

using FlintLib.Utilities.Resources;

namespace FlintLib.Utilities
{
	/// <summary>
	/// 
	/// </summary>
	public static class StringUtilities
	{
		/// <summary>
		/// 
		/// </summary>
		public static string DoubleNewLine { get { return (Environment.NewLine + Environment.NewLine); } }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public static bool IsNull(this string item)
		{
			if (item == null) { return true; }
			else { return false; }
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public static bool IsEmpty(this string item)
		{
			if (item == string.Empty) { return true; }
			else { return false; }
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public static bool IsWhiteSpace(this string item)
		{
			if (item != null)
			{
				return string.IsNullOrWhiteSpace(item) ? true : false;
			}
			else { throw new ArgumentException(nameof(item)); }
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
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
