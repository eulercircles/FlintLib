using System;

namespace FlintLib.Utilities
{
	/// <summary>
	/// 
	/// </summary>
	public static class DateTimeUtilities
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="referenceDate"></param>
		/// <returns></returns>
		public static DateTime GetSundayOfWeek(this DateTime referenceDate)
		{
			return GetDayOfWeek(referenceDate, DayOfWeek.Sunday);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="referenceDate"></param>
		/// <returns></returns>
		public static DateTime GetMondayOfWeek(this DateTime referenceDate)
		{
			return GetDayOfWeek(referenceDate, DayOfWeek.Monday);
		}

		private static DateTime GetDayOfWeek(DateTime referenceDate, DayOfWeek dayOfWeek)
		{
			if (referenceDate.DayOfWeek > dayOfWeek)
			{
				var result = new DateTime(referenceDate.Year, referenceDate.Month, referenceDate.Day);
				while (result.DayOfWeek != dayOfWeek)
				{
					result = result.AddDays(-1);
				}
				return result;
			}
			else if (referenceDate.DayOfWeek < dayOfWeek)
			{
				var result = new DateTime(referenceDate.Year, referenceDate.Month, referenceDate.Day);
				while (result.DayOfWeek != dayOfWeek)
				{
					result = result.AddDays(1);
				}
				return result;
			}
			else { return referenceDate; }
		}
	}
}
