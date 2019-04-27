using System;

namespace FLibXamarin.Scheduling
{
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

	internal static class Messages
	{
		internal const string DateMustBeTodayOrLater = "The date must be today or later.";
		internal const string SemiMonthlyStyleMustBeSet = "The semi-monthly style must be set when the semi-monthly period is chosen for a recurring transaction.";
		internal const string StartDateCannotBeSaturday = "If a correction method is chosen for Saturdays, the recurring transaction cannot begin on a Saturday.";
		internal const string StartDateCannotBeSunday = "If a correction method is chosen for Sundays, the recurring transaction cannot begin on a Sunday.";
		internal const string StartDateMustBeFifteenthOrLast = "The day of the starting date must be the 15th or the last day of the month when selecting the semi-monthly period and the semi-monthly style of 'Fifteenth and Last'.";
		internal const string StartDateMustBeFirstOrFifteenth = "The day of the starting date must be the 1st or 15th of the month when selecting the semi-monthly period and the semi-monthly style of 'First and Fifteenth'.";
	}
}
