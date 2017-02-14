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
			return item == null;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public static bool IsEmpty(this string item)
		{
			return item == string.Empty;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public static bool IsWhiteSpace(this string item)
		{
			return item == null ? false : string.IsNullOrWhiteSpace(item);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public static string NormalizeSpacing(this string item)
		{
			return item == null ? null : Regex.Replace(item, @"\s+", " ");
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
