using System;
using System.Globalization;

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
			return string.Format("{0:C}", value);
		}

		public static bool IsInRange(this int value, int lowerValue, int upperValue)
		{
			return (value >= lowerValue && value <= upperValue);
		}

		public static bool IsInRange(this float value, float lowerValue, float upperValue)
		{
			return (value >= lowerValue && value <= upperValue);
		}
	}
}
