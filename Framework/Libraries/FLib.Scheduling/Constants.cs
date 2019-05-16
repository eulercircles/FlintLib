using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLib.Scheduling
{
	public static class Messages
	{
		public const string DateMustBeTodayOrLater = "The date must be today or later.";
		public const string SemiMonthlyStyleMustBeSet = "The semi-monthly style must be set when the semi-monthly period is chosen for a recurring transaction.";
		public const string StartDateCannotBeSaturday = "If a correction method is chosen for Saturdays, the recurring transaction cannot begin on a Saturday.";
		public const string StartDateCannotBeSunday = "If a correction method is chosen for Sundays, the recurring transaction cannot begin on a Sunday.";
		public const string StartDateMustBeFifteenthOrLast = "The day of the starting date must be the 15th or the last day of the month when selecting the semi-monthly period and the semi-monthly style of 'Fifteenth and Last'.";
		public const string StartDateMustBeFirstOrFifteenth = "The day of the starting date must be the 1st or 15th of the month when selecting the semi-monthly period and the semi-monthly style of 'First and Fifteenth'.";
	}
}
