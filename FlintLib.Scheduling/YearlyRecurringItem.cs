using System;

namespace FlintLib.Scheduling
{
	public abstract class YearlyRecurringItem : RecurringItem
	{
		internal YearlyRecurringItem(Date startDate, CorrectionMethods saturdayCorrection, CorrectionMethods sundayCorrection, CorrectionMethods holidayCorrection) : base(startDate, saturdayCorrection, sundayCorrection, holidayCorrection)
		{
		}

		internal override Date Next()
		{
			_lastOccurrence = _lastOccurrence.AddYears(1);
			return GetCorrection();
		}
	}
}
