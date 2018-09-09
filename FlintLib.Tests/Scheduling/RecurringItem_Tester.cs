using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using FlintLib.Scheduling;

namespace FlintLib.Tests.Scheduling
{
	[TestClass]
	public class RecurringItem_Tester
	{
		[TestMethod]
		public void TestYearlyRecurrence()
		{
			var startDate = new Date(2018, Months.September, 24);
			var correction = CorrectionMethods.PreviousWeekDay;
			
			var recurrentItem = new YearlyRecurrenceRule(startDate, null, correction, correction, correction);

			var occurrences = recurrentItem.GetOccurrencesBetween(startDate, new Date(2035, Months.December, 31));
			var count = occurrences.Count;
		}

		[TestMethod]
		public void TestMonthlyRecurrence()
		{
			var startDate = new Date(2018, Months.September, 24);
			var correction = CorrectionMethods.FollowingWeekDay;
			
			var recurrentItem = new MonthlyRecurrenceRule(MonthlyStyles.OnDay, startDate, null, correction, correction, correction);

			var occurrences = recurrentItem.GetOccurrencesBetween(startDate, new Date(2035, Months.December, 31));
			var count = occurrences.Count;
		}

		[TestMethod]
		public void TestSemiMonthlyRecurrence()
		{
			var startDate = new Date(2018, Months.September, 15);
			var correction = CorrectionMethods.FollowingWeekDay;

			var recurrentItem = new SemiMonthlyRecurrenceRule(SemiMonthlyStyles.FifteenthAndLast, startDate, null, correction, correction, correction);

			var occurrences = recurrentItem.GetOccurrencesBetween(startDate, new Date(2035, Months.December, 31));
			var count = occurrences.Count;
		}

		[TestMethod]
		public void TestBiweeklyRecurrence()
		{
			var startDate = new Date(2018, Months.September, 14);
			var correction = CorrectionMethods.PreviousWeekDay;

			var recurrentItem = new BiweeklyRecurrenceRule(startDate, null, correction, correction, correction);

			var occurrences = recurrentItem.GetOccurrencesBetween(startDate, new Date(2035, Months.December, 31));
			var count = occurrences.Count;
		}

		[TestMethod]
		public void TestWeeklyRecurrence()
		{
			var startDate = new Date(2018, Months.September, 14);
			var correction = CorrectionMethods.PreviousWeekDay;

			var recurrentItem = new WeeklyRecurrenceRule(startDate, null, correction, correction, correction);

			var occurrences = recurrentItem.GetOccurrencesBetween(startDate, new Date(2035, Months.December, 31));
			var count = occurrences.Count;
		}
	}
}
