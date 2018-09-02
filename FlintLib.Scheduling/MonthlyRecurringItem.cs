using System;

namespace FlintLib.Scheduling
{
	public abstract class MonthlyRecurringItem : RecurringItem
	{
		private readonly MonthlyStyles _monthlyStyle;

		internal MonthlyRecurringItem(MonthlyStyles monthlyStyle, Date startDate, CorrectionMethods saturdayCorrection, CorrectionMethods sundayCorrection, CorrectionMethods holidayCorrection) : base(startDate, saturdayCorrection, sundayCorrection, holidayCorrection)
		{
			_monthlyStyle = monthlyStyle;

			if (monthlyStyle == MonthlyStyles.FirstDay && startDate.Day != 1)
			{

			}
			else if (monthlyStyle == MonthlyStyles.LastDay && (startDate.Day != startDate.EndOfMonth.Day))
			{

			}
		}

		internal override Date Next()
		{
			switch (_monthlyStyle)
			{
				case MonthlyStyles.FirstDay:
					_lastOccurrence = _lastOccurrence.BeginningOfMonth;
					break;
				case MonthlyStyles.LastDay:
					_lastOccurrence = _lastOccurrence.EndOfMonth;
					break;
			}

			_lastOccurrence = _lastOccurrence.AddMonths(1);
			return GetCorrection();
		}
	}
}
