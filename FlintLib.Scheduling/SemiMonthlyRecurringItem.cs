using System;

using static FlintLib.Scheduling.Properties.InternalResources;

namespace FlintLib.Scheduling
{
	public abstract class SemiMonthlyRecurringItem : RecurringItem
	{
		private readonly SemiMonthlyStyles _semiMonthlyStyle;

		internal SemiMonthlyRecurringItem(SemiMonthlyStyles semiMonthlyStyle, Date startDate, CorrectionMethods saturdayCorrection, CorrectionMethods sundayCorrection, CorrectionMethods holidayCorrection) : base(startDate, saturdayCorrection, sundayCorrection, holidayCorrection)
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

			_semiMonthlyStyle = semiMonthlyStyle;
		}

		internal override Date Next()
		{
			throw new NotImplementedException();
		}
	}
}
