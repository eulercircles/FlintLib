using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using FlintLib.Accounting;
using FlintLib.Scheduling;

namespace FlintLib.Tests.Accounting
{
	[TestClass]
	public class RecurringTransactionTester
	{
		[TestMethod]
		public void TestMethod1()
		{
			var sourceAccount = new ExternalAccount("Employer");
			var targetAccount = new InternalAccount("Main Checking", 1200.00m);

			var recurrence = new BiweeklyRecurrence(new Date(2018, Months.August, 3), null, CorrectionMethods.None, CorrectionMethods.None, CorrectionMethods.PreviousWeekDay);
			
			var transaction = new RecurringTransaction("Salary", 550.00m, sourceAccount, targetAccount, recurrence);
			transaction.CorrectOccurrence(new Date(2018, Months.August, 17), new Date(2018, Months.August, 16), 1000.00m);

			transaction.BringCurrent();
		}
	}
}
