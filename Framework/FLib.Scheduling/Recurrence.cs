using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace FLib.Scheduling
{
	public abstract class RecurrenceRule
	{
		private enum RecurrencePeriods
		{
			Weekly,
			BiWeekly,
			SemiMonthly,
			Monthly,
			Yearly
		}

		public Date StartDate { get; }
		public Date? EndDate { get; set; } = null;

		public CorrectionMethods SaturdayCorrection { get; private set; } = CorrectionMethods.None;
		public CorrectionMethods SundayCorrection { get; private set; } = CorrectionMethods.None;
		public CorrectionMethods HolidayCorrection { get; private set; } = CorrectionMethods.None;

		protected Date _currentNormalOccurrence;

		public RecurrenceRule(Date startDate, Date? endDate)
		{
			StartDate = startDate; // This must be set once and be used as the very first valid occurrence that the recurrence was created for.
			EndDate = endDate;

			_currentNormalOccurrence = StartDate;
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
					case CorrectionMethods.Before: return date.AddDays(-1);
					case CorrectionMethods.After: return date.AddDays(2);
				}
			}

			if (date.DayOfWeek == DayOfWeek.Sunday)
			{
				switch (SundayCorrection)
				{
					case CorrectionMethods.Before: return date.AddDays(-2);
					case CorrectionMethods.After: return date.AddDays(1);
				}
			}

			if (date.IsHoliday)
			{
				switch (HolidayCorrection)
				{
					case CorrectionMethods.Before: return date.AddDays(-1);
					case CorrectionMethods.After: return date.AddDays(1);
				}
			}

			return date;
		}

		public IReadOnlyList<Date> GetOccurrencesBetween(Date lower, Date upper)
		{
			Debug.Assert(upper >= lower);

			if (lower < StartDate) { lower = StartDate; }

			var results = new List<Date>();
			var current = _currentNormalOccurrence = StartDate;
			while (current <= upper)
			{
				if (current >= lower) { results.Add(current); }
				current = Next();
			}

			return results;
		}

		public override string ToString() => Encode();

		#region Rule Coding
		public static RecurrenceRule Decode(string code)
		{
			if (code.Length != 23) { throw new ArgumentException($"'{code}' is not a valid code."); }

			var period = GetPeriod(code.Substring(0, 1).First());

			var startDate = GetDate(code.Substring(4, 8));
			var endDate = GetDate(code.Substring(12, 8));

			var smstyle = GetSemiMonthlyStyle(code.Substring(3, 1).First());

			var saturday = GetCorrectionMethod(code.Substring(20, 1).First());
			var sunday = GetCorrectionMethod(code.Substring(21, 1).First());
			var holiday = GetCorrectionMethod(code.Substring(22, 1).First());

			RecurrenceRule result = null;
			switch (period)
			{
				case RecurrencePeriods.Weekly:
					saturday = CorrectionMethods.None;
					sunday = CorrectionMethods.None;
					result = new WeeklyRecurrenceRule(startDate.Value, endDate);
					break;
				case RecurrencePeriods.BiWeekly:
					saturday = CorrectionMethods.None;
					sunday = CorrectionMethods.None;
					result = new BiweeklyRecurrenceRule(startDate.Value, endDate);
					break;
				case RecurrencePeriods.SemiMonthly:
					result = new SemiMonthlyRecurrenceRule(smstyle, startDate.Value, endDate);
					break;
				case RecurrencePeriods.Monthly:
					result = new MonthlyRecurrenceRule(startDate.Value, endDate);
					break;
				case RecurrencePeriods.Yearly:
					result = new YearlyRecurrenceRule(startDate.Value, endDate);
					break;
			}

			result.SaturdayCorrection = saturday;
			result.SundayCorrection = sunday;
			result.HolidayCorrection = holiday;

			return result;
		}

		private static RecurrencePeriods GetPeriod(char code)
		{
			switch (code)
			{
				case 'W': return RecurrencePeriods.Weekly;
				case 'B': return RecurrencePeriods.BiWeekly;
				case 'S': return RecurrencePeriods.SemiMonthly;
				case 'M': return RecurrencePeriods.Monthly;
				case 'Y': return RecurrencePeriods.Yearly;
				default: throw new Exception($"'{code}' does not designate a valid period code. Use 'W', 'B', 'S', 'M', or 'Y'.");
			}
		}

		private static Date? GetDate(string dateCode)
		{
			try
			{
				var corrected = dateCode.Insert(4, "-").Insert(7, "-");
				return Date.ParseExact(corrected);
			}
			catch (Exception) { return null; }
		}

		private static CorrectionMethods GetCorrectionMethod(char code)
		{
			switch (code)
			{
				case 'N': return CorrectionMethods.None;
				case 'B': return CorrectionMethods.Before;
				case 'A': return CorrectionMethods.After;
				default: throw new Exception($"'{code}' does not designate a valid correction method code. Use 'N', 'B', or 'A'.");
			}
		}

		private static SemiMonthlyStyles GetSemiMonthlyStyle(char code)
		{
			switch (code)
			{
				case 'N': return SemiMonthlyStyles.UNDEFINED;
				case 'F': return SemiMonthlyStyles.FirstAndFifteenth;
				case 'L': return SemiMonthlyStyles.FifteenthAndLast;
				default: throw new Exception($"'{code}' does not designate a valid Semi-Monthly style code. Use 'N', 'F', or 'L'.");
			}
		}

		public abstract string Encode();
		#endregion Rule Coding
	}

	#region Concrete Rules
	internal class WeeklyRecurrenceRule : RecurrenceRule
	{
		public WeeklyRecurrenceRule(Date startDate, Date? endDate = null) : base(startDate, endDate)
		{
		}

		internal override Date Next()
		{
			_currentNormalOccurrence = _currentNormalOccurrence.AddDays(7);
			return GetCorrection();
		}

		public override string Encode() => $"Weekly";
	}

	internal class BiweeklyRecurrenceRule : RecurrenceRule
	{
		public BiweeklyRecurrenceRule(Date startDate, Date? endDate = null) : base(startDate, endDate)
		{
		}

		public override string Encode()
		{
			var periodCode = "B";
			var dayCode = (((int)StartDate.DayOfWeek) + 1).ToString().PadLeft(2, '0');
			var smstyleCode = "N";
			var startCode = StartDate.ToString().Replace("-", string.Empty);
			var endCode = EndDate.HasValue ? EndDate.ToString().Replace("-", string.Empty) : "00000000";
			var satCode = SaturdayCorrection.ToLetterCode();
			var sunCode = SundayCorrection.ToLetterCode();
			var holCode = HolidayCorrection.ToLetterCode();

			return $"{periodCode}{dayCode}{smstyleCode}{startCode}{endCode}{satCode}{sunCode}{holCode}";
		}

		internal override Date Next()
		{
			_currentNormalOccurrence = _currentNormalOccurrence.AddDays(14);
			return GetCorrection();
		}
	}

	internal class SemiMonthlyRecurrenceRule : RecurrenceRule
	{
		public SemiMonthlyStyles SemiMonthlyStyle { get; }

		public SemiMonthlyRecurrenceRule(SemiMonthlyStyles style, Date startDate, Date? endDate = null) : base(startDate, endDate)
		{
			if (style == SemiMonthlyStyles.UNDEFINED)
			{
				throw new ArgumentNullException(nameof(style), Messages.SemiMonthlyStyleMustBeSet);
			}
			if (style == SemiMonthlyStyles.FirstAndFifteenth && !(startDate.Day == 1 || startDate.Day == 15))
			{
				throw new Exception(Messages.StartDateMustBeFirstOrFifteenth);
			}
			else if (style == SemiMonthlyStyles.FifteenthAndLast && !(startDate.Day == 15 || startDate.Day == startDate.EndOfMonth.Day))
			{
				throw new Exception(Messages.StartDateMustBeFifteenthOrLast);
			}

			SemiMonthlyStyle = style;
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

		public override string Encode() => $"Semi-monthly";
	}

	internal class MonthlyRecurrenceRule : RecurrenceRule
	{
		public MonthlyStyles MonthlyStyle { get; }

		public MonthlyRecurrenceRule(Date startDate, Date? endDate = null) : base(startDate, endDate)
		{
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

		public override string Encode() => $"Monthly";
	}

	internal class YearlyRecurrenceRule : RecurrenceRule
	{
		public YearlyRecurrenceRule(Date startDate, Date? endDate) : base(startDate, endDate) { }

		public override string Encode() => $"Yearly";

		internal override Date Next()
		{
			_currentNormalOccurrence = _currentNormalOccurrence.AddYears(1);
			return GetCorrection();
		}
	}
	#endregion Concrete Rules
}
