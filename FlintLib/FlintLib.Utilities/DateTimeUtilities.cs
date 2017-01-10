using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlintLib.Utilities
{
	public static class DateTimeUtilities
	{
		public static DateTime GetSundayOfWeek(this DateTime referenceDate)
		{
			return GetDayOfWeek(referenceDate, DayOfWeek.Sunday);
		}

		public static DateTime GetMondayOfWeek(this DateTime referenceDate)
		{
			return GetDayOfWeek(referenceDate, DayOfWeek.Monday);
		}

		private static DateTime GetDayOfWeek(DateTime referenceDate, DayOfWeek dayOfWeek)
		{
			var result = new DateTime(referenceDate.Year, referenceDate.Month, referenceDate.Day);
			while (result.DayOfWeek != dayOfWeek)
			{
				result = result.AddDays(-1);
			}
			return result;
		}
	}
}
