using System;
using System.Collections.Generic;
using System.Diagnostics;
using static FlintLib.Scheduling.Properties.InternalResources;

namespace FlintLib.Scheduling
{
	public abstract class Recurrence
	{
		public Date StartingReference { get; }
		public Date? EndDate { get; }

		public CorrectionMethods SaturdayCorrection { get; }
		public CorrectionMethods SundayCorrection { get; }
		public CorrectionMethods HolidayCorrection { get; }

		protected Date _currentNormalOccurrence;

		public Recurrence(Date startDate, Date? endDate, CorrectionMethods saturdayCorrection, CorrectionMethods sundayCorrection, CorrectionMethods holidayCorrection)
		{
			StartingReference = startDate; // This must be set once and be used as the very first valid occurrence that the recurrence was created for.
			EndDate = endDate;
			SaturdayCorrection = saturdayCorrection;
			SundayCorrection = sundayCorrection;
			HolidayCorrection = holidayCorrection;

			_currentNormalOccurrence = StartingReference;
		}

		internal abstract Date Next();

		protected internal Date GetCorrection()
		{
			var result = _currentNormalOccurrence;
			while (RequiresCorrection(result)) { result = ApplyCorrection(result); }
			return result;
		}

		protected internal bool RequiresCorrection(Date date)
		{
			if (date.DayOfWeek == DayOfWeek.Saturday && SaturdayCorrection != CorrectionMethods.None) { return true; }
			if (date.DayOfWeek == DayOfWeek.Sunday && SundayCorrection != CorrectionMethods.None) { return true; }
			if (date.IsHoliday && HolidayCorrection != CorrectionMethods.None) { return true; }

			return false;
		}

		protected internal Date ApplyCorrection(Date date)
		{
			if (date.DayOfWeek == DayOfWeek.Saturday)
			{
				switch (SaturdayCorrection)
				{
					case CorrectionMethods.PreviousWeekDay: return date.AddDays(-1);
					case CorrectionMethods.FollowingWeekDay: return date.AddDays(2);
				}
			}

			if (date.DayOfWeek == DayOfWeek.Sunday)
			{
				switch (SundayCorrection)
				{
					case CorrectionMethods.PreviousWeekDay: return date.AddDays(-2);
					case CorrectionMethods.FollowingWeekDay: return date.AddDays(1);
				}
			}

			if (date.IsHoliday)
			{
				switch (HolidayCorrection)
				{
					case CorrectionMethods.PreviousWeekDay: return date.AddDays(-1);
					case CorrectionMethods.FollowingWeekDay: return date.AddDays(1);
				}
			}

			return date;
		}

		public IReadOnlyList<Date> GetOccurrencesBetween(Date lower, Date upper)
		{
			Debug.Assert(upper >= lower);

			if (lower < StartingReference) { lower = StartingReference; }

			var results = new List<Date>();
			var current = _currentNormalOccurrence = StartingReference;
			while (current <= upper)
			{
				if (current >= lower) { results.Add(current); }
				current = Next();
			}

			return results;
		}
	}

	public class YearlyRecurrence : Recurrence
	{
		public YearlyRecurrence(Date startDate, Date? endDate, CorrectionMethods saturdayCorrection, CorrectionMethods sundayCorrection, CorrectionMethods holidayCorrection) : base(startDate, endDate, saturdayCorrection, sundayCorrection, holidayCorrection)
		{
		}

		internal override Date Next()
		{
			_currentNormalOccurrence = _currentNormalOccurrence.AddYears(1);
			return GetCorrection();
		}
	}

	public class MonthlyRecurrence : Recurrence
	{
		public MonthlyStyles MonthlyStyle { get; }

		public MonthlyRecurrence(MonthlyStyles monthlyStyle, Date startDate, Date? endDate, CorrectionMethods saturdayCorrection, CorrectionMethods sundayCorrection, CorrectionMethods holidayCorrection) : base(startDate, endDate, saturdayCorrection, sundayCorrection, holidayCorrection)
		{
			if (monthlyStyle == MonthlyStyles.FirstDay && startDate.Day != 1)
			{

			}
			else if (monthlyStyle == MonthlyStyles.LastDay && (startDate.Day != startDate.EndOfMonth.Day))
			{

			}

			MonthlyStyle = monthlyStyle;
		}

		internal override Date Next()
		{
			switch (MonthlyStyle)
			{
				case MonthlyStyles.FirstDay:
					_currentNormalOccurrence = _currentNormalOccurrence.BeginningOfMonth;
					break;
				case MonthlyStyles.LastDay:
					_currentNormalOccurrence = _currentNormalOccurrence.EndOfMonth;
					break;
			}

			_currentNormalOccurrence = _currentNormalOccurrence.AddMonths(1);
			return GetCorrection();
		}
	}

	public class SemiMonthlyRecurrence : Recurrence
	{
		public SemiMonthlyStyles SemiMonthlyStyle { get; }

		public SemiMonthlyRecurrence(SemiMonthlyStyles semiMonthlyStyle, Date startDate, Date? endDate, CorrectionMethods saturdayCorrection, CorrectionMethods sundayCorrection, CorrectionMethods holidayCorrection)
			: base(startDate, endDate, saturdayCorrection, sundayCorrection, holidayCorrection)
		{
			if (semiMonthlyStyle == SemiMonthlyStyles.UNDEFINED)
			{
				throw new ArgumentNullException(nameof(semiMonthlyStyle), Message_SemiMonthlyStyleMustBeSet);
			}
			if (semiMonthlyStyle == SemiMonthlyStyles.FirstAndFifteenth && !(startDate.Day == 1 || startDate.Day == 15))
			{
				throw new Exception(Message_StartDateMustBeFirstOrFifteenth);
			}
			else if (semiMonthlyStyle == SemiMonthlyStyles.FifteenthAndLast && !(startDate.Day == 15 || startDate.Day == startDate.EndOfMonth.Day))
			{
				throw new Exception(Message_StartDateMustBeFifteenthOrLast);
			}

			SemiMonthlyStyle = semiMonthlyStyle;
		}

		internal override Date Next()
		{
			switch (SemiMonthlyStyle)
			{
				case SemiMonthlyStyles.FirstAndFifteenth:
					if (_currentNormalOccurrence.Day == 1) { _currentNormalOccurrence = _currentNormalOccurrence.AddDays(14); }
					else if (_currentNormalOccurrence.Day == 15) { _currentNormalOccurrence = _currentNormalOccurrence.AddMonths(1).BeginningOfMonth; }
					else { throw new Exception(); }
					break;
				case SemiMonthlyStyles.FifteenthAndLast:
					if (_currentNormalOccurrence.Day == 15) { _currentNormalOccurrence = _currentNormalOccurrence.EndOfMonth; }
					else if (_currentNormalOccurrence == _currentNormalOccurrence.EndOfMonth)
					{
						var nextMonth = _currentNormalOccurrence.AddMonths(1);
						_currentNormalOccurrence = new Date(nextMonth.Year, nextMonth.Month, 15);
					}
					else { throw new Exception(); }
					break;
			}

			return GetCorrection();
		}
	}

	public class BiweeklyRecurrence : Recurrence
	{
		public BiweeklyRecurrence(Date startDate, Date? endDate, CorrectionMethods saturdayCorrection, CorrectionMethods sundayCorrection, CorrectionMethods holidayCorrection) : base(startDate, endDate, saturdayCorrection, sundayCorrection, holidayCorrection)
		{
			if (saturdayCorrection != CorrectionMethods.None && startDate.DayOfWeek == DayOfWeek.Saturday)
			{ throw new Exception(Message_StartDateCannotBeSaturday); }

			if (sundayCorrection != CorrectionMethods.None && startDate.DayOfWeek == DayOfWeek.Sunday)
			{ throw new Exception(Message_StartDateCannotBeSunday); }
		}

		internal override Date Next()
		{
			_currentNormalOccurrence = _currentNormalOccurrence.AddDays(14);
			return GetCorrection();
		}
	}

	public class WeeklyRecurrence : Recurrence
	{
		public WeeklyRecurrence(Date startDate, Date? endDate, CorrectionMethods saturdayCorrection, CorrectionMethods sundayCorrection, CorrectionMethods holidayCorrection) : base(startDate, endDate, saturdayCorrection, sundayCorrection, holidayCorrection)
		{
			if (saturdayCorrection != CorrectionMethods.None && startDate.DayOfWeek == DayOfWeek.Saturday)
			{ throw new Exception(Message_StartDateCannotBeSaturday); }

			if (sundayCorrection != CorrectionMethods.None && startDate.DayOfWeek == DayOfWeek.Sunday)
			{ throw new Exception(Message_StartDateCannotBeSunday); }
		}

		internal override Date Next()
		{
			_currentNormalOccurrence = _currentNormalOccurrence.AddDays(7);
			return GetCorrection();
		}
	}
}
