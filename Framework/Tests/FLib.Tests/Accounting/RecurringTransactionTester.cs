using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using FLib.Accounting;
using FLib.Scheduling;

namespace FLib.Tests.Accounting
{
	[TestClass]
	public class RecurringTransactionTester
	{
		[TestMethod]
		public void TestMethod1()
		{
			//var sourceAccount = new Account("Employer");
			var targetAccount = new Account("Main Checking", 1200.00m);

			var recurrence = new BiweeklyRecurrenceRule(new Date(2018, Months.August, 3), null, CorrectionMethods.None, CorrectionMethods.None, CorrectionMethods.PreviousWeekDay);
			
			var transaction = new RecurringTransaction("Salary", 550.00m, null, targetAccount, recurrence);
			transaction.CorrectOccurrence(new Date(2018, Months.August, 17), new Date(2018, Months.August, 16), 1000.00m);

			transaction.BringCurrent();
		}
	}
}
