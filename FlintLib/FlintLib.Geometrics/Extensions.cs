using System;
using System.Linq;

using FlintLib.Common;

namespace FlintLib.Geometrics
{
	public static class Extensions
	{
		public static ImperialUnits? GetCustomaryUnit(this string designator)
		{
			var units = EnumUtilities.GetEnumDescriptions<ImperialUnits>();
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

		public static string GetUnitAbbreviation(this ImperialUnits imperialUnit)
		{
			throw new NotImplementedException();
		}

		public static string GetUnitAbbreviation(this MetricUnits metricUnit)
		{
			throw new NotImplementedException();
		}

		public static string GetSingularUnitName(this ImperialUnits imperialUnit)
		{
			throw new NotImplementedException();
		}

		public static string GetSingularUnitName(this MetricUnits metricUnit)
		{
			throw new NotImplementedException();
		}

		public static string GetPluralUnitName(this ImperialUnits imperialUnit)
		{
			throw new NotImplementedException();
		}

		public static string GetPluralUnitName(this MetricUnits metricUnit)
		{
			throw new NotImplementedException();
		}
	}
}
