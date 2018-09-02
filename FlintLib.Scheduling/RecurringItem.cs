using System;
using System.Collections.Generic;

using static FlintLib.Scheduling.Properties.InternalResources;

namespace FlintLib.Scheduling
{
	public abstract class RecurringItem
	{
		protected Date _startingReference;
		protected Date? _endDate;

		protected Date _lastOccurrence;

		protected readonly CorrectionMethods _saturdayCorrection;
		protected readonly CorrectionMethods _sundayCorrection;
		protected readonly CorrectionMethods _holidayCorrection;

		internal RecurringItem(Date startDate, CorrectionMethods saturdayCorrection, CorrectionMethods sundayCorrection, CorrectionMethods holidayCorrection)
		{
			if (saturdayCorrection != CorrectionMethods.None && startDate.DayOfWeek == DayOfWeek.Saturday)
			{ throw new Exception(Message_StartDateCannotBeSaturday); }

			if (sundayCorrection != CorrectionMethods.None && startDate.DayOfWeek == DayOfWeek.Sunday)
			{ throw new Exception(Message_StartDateCannotBeSunday); }
			
			_startingReference = startDate;
			_lastOccurrence = _startingReference;
			_saturdayCorrection = saturdayCorrection;
			_sundayCorrection = sundayCorrection;
			_holidayCorrection = holidayCorrection;
		}

		internal abstract Date Next();

		protected Date GetCorrection()
		{
			Date result = _lastOccurrence;
			while (RequiresCorrection(result)) { result = ApplyCorrection(result); }
			return result;
		}

		private bool RequiresCorrection(Date date)
		{
			if (_startingReference.DayOfWeek == DayOfWeek.Saturday && _saturdayCorrection != CorrectionMethods.None) { return true; }
			if (_startingReference.DayOfWeek == DayOfWeek.Sunday && _sundayCorrection != CorrectionMethods.None) { return true; }
			if (_startingReference.IsHoliday && _holidayCorrection != CorrectionMethods.None) { return true; }

			return false;
		}

		private Date ApplyCorrection(Date date)
		{
			if (date.DayOfWeek == DayOfWeek.Saturday)
			{
				switch (_saturdayCorrection)
				{
					case CorrectionMethods.PreviousWeekDay: return date.AddDays(-1);
					case CorrectionMethods.FollowingWeekDay: return date.AddDays(2);
				}
			}

			if (date.DayOfWeek == DayOfWeek.Sunday)
			{
				switch (_sundayCorrection)
				{
					case CorrectionMethods.PreviousWeekDay: return date.AddDays(-2);
					case CorrectionMethods.FollowingWeekDay: return date.AddDays(1);
				}
			}

			if (date.IsHoliday)
			{
				switch (_holidayCorrection)
				{
					case CorrectionMethods.PreviousWeekDay: return date.AddDays(-1);
					case CorrectionMethods.FollowingWeekDay: return date.AddDays(1);
				}
			}

			return date;
		}

		public IReadOnlyList<Date> GetOccurrencesBetween(Date lower, Date upper)
		{
			throw new NotImplementedException();
		}
	}
}
