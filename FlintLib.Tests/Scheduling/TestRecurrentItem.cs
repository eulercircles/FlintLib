
using FlintLib.Scheduling;

namespace FlintLib.Tests.Scheduling
{
	internal class TestRecurrentItem : MonthlyRecurringItem
	{
		internal string Description { get; }

		internal TestRecurrentItem(string description, MonthlyStyles monthlyStyle, Date startDate, CorrectionMethods saturdayCorrection, CorrectionMethods sundayCorrection, CorrectionMethods holidayCorrection) : base(monthlyStyle, startDate, saturdayCorrection, sundayCorrection, holidayCorrection)
		{
			Description = description;
		}
	}
}
