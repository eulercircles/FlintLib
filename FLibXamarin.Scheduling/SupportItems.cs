using System;
using System.Collections.Generic;
using System.Text;

namespace FLibXamarin.Scheduling
{
	public enum Months
	{
		UNDEFINED = 0,
		January = 1,
		February = 2,
		March = 3,
		April = 4,
		May = 5,
		June = 6,
		July = 7,
		August = 8,
		September = 9,
		October = 10,
		November = 11,
		December = 12
	}

	public enum RecurrencePeriods
	{
		UNDEFINED,
		Yearly,
		Monthly,
		SemiMonthly,
		Biweekly,
		Weekly,
		Daily
	}

	public enum MonthlyStyles
	{
		OnDay,
		FirstDay,
		LastDay
	}

	public enum SemiMonthlyStyles
	{
		UNDEFINED,
		FirstAndFifteenth,
		FifteenthAndLast
	}

	public enum CorrectionMethods
	{
		None,
		PreviousWeekDay,
		FollowingWeekDay
	}

	internal static class Constants
	{
		internal const int MIN_VALUE = 0;
		internal const int MAX_HOURS = 23;
		internal const int MAX_MINUTES = 59;
		internal const int MAX_SECONDS = 59;

		internal const int TOTAL_HOURS = 24;
		internal const int TOTAL_MINUTES = 60;
		internal const int TOTAL_SECONDS = 60;
	}
}
