using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace FlintLib.Common
{
	public static class Extensions
	{
		public static int? ToInt(this string value)
		{
			int parsedValue;
			if (int.TryParse(value, out parsedValue)) { return parsedValue; }
			else { return null; }
		}

		public static decimal? ToDecimal(this string value)
		{
			decimal parsedValue;
			if (decimal.TryParse(value, NumberStyles.Any, CultureInfo.CurrentCulture, out parsedValue)) { return parsedValue; }
			else { return null; }
		}

		public static string ToCurrencyString(this decimal value)
		{
			return value.ToString("C", CultureInfo.CurrentCulture);
		}

		public static bool IsNegative(this double value)
		{
			return value < 0;
		}

		public static bool IsInRange(this int value, int lowerValue, int upperValue)
		{
			return (value >= lowerValue && value <= upperValue);
		}

		public static bool IsInRange(this float value, float lowerValue, float upperValue)
		{
			return (value >= lowerValue && value <= upperValue);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="count"></param>
		/// <returns></returns>
		public static string TrailingLetters(this string input, int count)
		{
			List<char> chars = new List<char>();
			for (int i = input.Length - 1; i > input.Length - count - 1; i--)
			{
				if (char.IsLetter(input[i]))
				{
					chars.Insert(0, input[i]);
				}
			}
			return new string(chars.ToArray());
		}

		public static string CleanWhitespace(this string input)
		{
			return Regex.Replace(input, @"\s+", " ");
		}

		public static string GetLeadingNumerical(this string input)
		{
			return new string(input.TakeWhile(c => char.IsNumber(c) || char.IsPunctuation(c)).ToArray());
		}

		public static bool IsGreaterThanZero(this string stringValue)
		{
			if (double.TryParse(stringValue, out double numericalValue))
			{
				if (numericalValue > 0)
				{ return true; }
				else { return false; }
			}
			else { return false; }
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="valueString"></param>
		/// <returns></returns>
		public static bool IsIntegerValue(this string valueString)
		{
			double parsedValue;
			if (double.TryParse(valueString, out parsedValue))
			{
				if (parsedValue - Math.Truncate(parsedValue) == 0)
				{
					return true;
				}
				else { return false; }
			}
			else { return false; }
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="valueString"></param>
		/// <returns></returns>
		public static bool IsNumericValue(this string valueString)
		{
			double parsedValue;
			return double.TryParse(valueString, out parsedValue);
		}
	}
}
