using System;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using FlintLib.Scheduling;

namespace FlintLib.Tests.Scheduling
{
	[TestClass]
	public class RecurrentItem_Tester
	{
		[TestMethod]
		public void TestMethod1()
		{
			var description = "Meeting";
			var startDate = new Date(2018, Months.September, 1);
			var correctionMethod = CorrectionMethods.None;
			
			var recurrentItem = new TestRecurrentItem(description, MonthlyStyles.OnDay, startDate, correctionMethod, correctionMethod, correctionMethod);

			for (int i = 0; i < 10000; i++)
			{
				var next = recurrentItem.Next();
				Assert.IsTrue(next > startDate);
				Assert.IsTrue(next.Day == 1);
			}
		}
	}
}
