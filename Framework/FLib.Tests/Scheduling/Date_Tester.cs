using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using FLib.Scheduling;

namespace FLib.Tests.Scheduling
{
	[TestClass]
	public class Date_Tester
	{
		private readonly Date _dateA = new Date(2018, Months.September, 1);
		private readonly Date _dateB = new Date(2016, Months.February, 20);
		private readonly Date _dateC = new Date(2018, Months.September, 3);
		private readonly Date _dateD = new Date(2018, Months.October, 21);

		[TestMethod]
		public void TestLessThanOperator()
		{
			Assert.IsFalse(_dateA < _dateB);
			Assert.IsTrue(_dateB < _dateA);
			Assert.IsTrue(_dateA < _dateC);
			Assert.IsTrue(_dateA < _dateD);
		}

		[TestMethod]
		public void TestGreaterThanOperator()
		{
			Assert.IsTrue(_dateA > _dateB);
		}
	}
}
