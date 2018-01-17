using FlintLib.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FlintLib.Geometrics
{
	public static class Extensions
	{
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
			double numericalValue;
			if (double.TryParse(stringValue, out numericalValue))
			{
				if (numericalValue > 0)
				{ return true; }
				else { return false; }
			}
			else { return false; }
		}

		public static CustomaryUnits? GetCustomaryUnit(this string designator)
		{
			var units = EnumUtilities.GetEnumDescriptions<CustomaryUnits>();
			var key = units.Keys.ToList().FirstOrDefault(k => k.Contains(designator));

			if (key != null) { return units[key]; }
			else { return null; }
		}

		public static MetricUnits? GetMetricUnit(this string designator)
		{
			var units = EnumUtilities.GetEnumDescriptions<MetricUnits>();

			string key = null;
			foreach (var k in units.Keys.ToList())
			{
				foreach (var s in k.Split(',').ToList())
				{
					if (s == designator)
					{
						key = k;
						break;
					}
				}

				if (!string.IsNullOrWhiteSpace(key)) { break; }
			}

			if (key != null) { return units[key]; }
			else { return null; }
		}

		public static string GetUnitAbbreviation(this CustomaryUnits customaryUnit)
		{
			throw new NotImplementedException();
		}

		public static string GetUnitAbbreviation(this MetricUnits metricUnit)
		{
			throw new NotImplementedException();
		}

		public static string GetSingularUnitName(this CustomaryUnits customaryUnit)
		{
			throw new NotImplementedException();
		}

		public static string GetSingularUnitName(this MetricUnits metricUnit)
		{
			throw new NotImplementedException();
		}

		public static string GetPluralUnitName(this CustomaryUnits customaryUnit)
		{
			throw new NotImplementedException();
		}

		public static string GetPluralUnitName(this MetricUnits metricUnit)
		{
			throw new NotImplementedException();
		}
	}
}
