using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FLibXamarin.Scheduling
{
	public static class Extensions
	{
		public static string ToLetterCode(this CorrectionMethods method)
		{
			string result;
			switch (method)
			{
				case CorrectionMethods.After: result = "A"; break;
				case CorrectionMethods.Before: result = "B"; break;
				case CorrectionMethods.None: result = "N"; break;
				default: result = "N"; break;
			}
			return result;
		}
	}

	public static class DateTimeExtensions
	{
		public static Date BeginningOfWeek(this Date value)
		{
			while (value.DayOfWeek != DayOfWeek.Sunday)
			{
				value = value.AddDays(-1);
			}
			return value;
		}

		public static Date EndOfWeek(this Date value)
		{
			while (value.DayOfWeek != DayOfWeek.Saturday)
			{
				value = value.AddDays(1);
			}
			return value;
		}

		public static Date BeginningOfMonth(this Date value)
		{
			return new Date(value.Year, value.Month, 1);
		}

		public static Date EndOfMonth(this Date value)
		{
			return new Date(value.Year, value.Month, DateTime.DaysInMonth(value.Year, (int)value.Month));
		}

		public static bool IsHoliday(this Date value)
		{
			return
					value.IsNewYearsDay()
			 || value.IsNewYearsEve()
			 || value.IsThanksgivingDay()
			 || value.IsDayAfterThanksgiving()
			 || value.IsChristmasEve()
			 || value.IsChristmasDay()
			 || value.IsFourthOfJuly()
			 || value.IsLaborDay()
			 || value.IsMemorialDay();
		}

		public static bool IsNewYearsDay(this Date value) => (value.Month == Months.January && value.Day == 1);

		public static bool IsNewYearsEve(this Date value) => (value.Month == Months.December && value.Day == 31);

		public static bool IsChristmasEve(this Date value) => (value.Month == Months.December && value.Day == 25);

		public static bool IsChristmasDay(this Date value) => (value.Month == Months.December && value.Day == 25);

		public static bool IsFourthOfJuly(this Date value) => (value.Month == Months.July && value.Day == 4);

		public static bool IsLaborDay(this Date value)
		{
			// First Monday in September
			Date laborDay = new Date(value.Year, Months.September, 1);
			DayOfWeek dayOfWeek = laborDay.DayOfWeek;
			while (dayOfWeek != DayOfWeek.Monday)
			{
				laborDay = laborDay.AddDays(1);
				dayOfWeek = laborDay.DayOfWeek;
			}
			return value.DayOfYear == laborDay.DayOfYear;
		}

		public static bool IsMemorialDay(this Date value)
		{
			//Last Monday in May
			var memorialDay = new Date(value.Year, Months.May, 31);
			DayOfWeek dayOfWeek = memorialDay.DayOfWeek;
			while (dayOfWeek != DayOfWeek.Monday)
			{
				memorialDay = memorialDay.AddDays(-1);
				dayOfWeek = memorialDay.DayOfWeek;
			}
			return value.DayOfYear == memorialDay.DayOfYear;
		}

		public static bool IsThanksgivingDay(this Date value)
		{
			//4th Thursday in November
			var thanksgiving = (from day in Enumerable.Range(1, 30)
													where new Date(value.Year, Months.November, day).DayOfWeek == DayOfWeek.Thursday
													select day).ElementAt(3);
			Date thanksgivingDay = new Date(value.Year, Months.November, thanksgiving);
			return value.DayOfYear == thanksgivingDay.DayOfYear;
		}

		public static bool IsDayAfterThanksgiving(this Date value)
		{
			var thanksgiving = (from day in Enumerable.Range(1, 30)
													where new Date(value.Year, Months.November, day).DayOfWeek == DayOfWeek.Thursday
													select day).ElementAt(3);
			Date thanksgivingDay = new Date(value.Year, Months.November, thanksgiving + 1);
			return value.DayOfYear == thanksgivingDay.DayOfYear;
		}
	}
}
