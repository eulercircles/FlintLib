using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace FLibXamarin.Common
{
	public static class NumericExtensions
	{
		public static int? ToInt(this string value) => (int.TryParse(value, out int parsedValue)) ? (int?)parsedValue : null;
		public static decimal? ToDecimal(this string value) => (decimal.TryParse(value, NumberStyles.Any, CultureInfo.CurrentCulture, out decimal parsedValue)) ? (decimal?)parsedValue : null;
		public static string ToCurrencyString(this decimal value) => value.ToString("C", CultureInfo.CurrentCulture);
		public static bool IsNegative(this double value) => value < 0;
		public static bool IsInRange(this int value, int lowerValue, int upperValue) => (value >= lowerValue && value <= upperValue);
		public static bool IsInRange(this float value, float lowerValue, float upperValue) => (value >= lowerValue && value <= upperValue);
		public static bool IsGreaterThanZero(this string value) => double.TryParse(value, out double numericalValue) ? (numericalValue > 0) : false;
		public static bool IsIntegerValue(this string value) => (double.TryParse(value, out double parsedValue)) ? (parsedValue - Math.Truncate(parsedValue) == 0) : false;
		public static bool IsNumericValue(this string value) => double.TryParse(value, out _);
	}

	public static class StringExtensions
	{
		public static bool IsEmpty(this string value) => string.IsNullOrEmpty(value);
		public static bool IsWhiteSpace(this string value) => string.IsNullOrWhiteSpace(value);
		public static string NormalizeSpacing(this string value) => Regex.Replace(value, @"\s+", " ");
		public static string GetLeadingNumerical(this string input) => new string(input.TakeWhile(c => char.IsNumber(c) || char.IsPunctuation(c)).ToArray());
	}
}
