using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using FlintLib.Scheduling;

namespace FlintLib.Tests.Scheduling
{
	[TestClass]
	public class Time_Tester
	{
		[TestMethod]
		public void TestLessThanOperator()
		{
			var testTime = new Time(12, 0, 0);

			var time1 = new Time(11, 0, 0);
			var time2 = new Time(13, 0, 0);
			var time3 = new Time(12, 1, 0);
			var time4 = new Time(11, 59, 0);
			var time5 = new Time(12, 0, 1);

			Assert.IsTrue(time1 < testTime);
			Assert.IsTrue(testTime < time2);
			Assert.IsTrue(testTime < time3);
			Assert.IsTrue(time4 < testTime);
			Assert.IsTrue(testTime < time5);
		}

		[TestMethod]
		public void TestGreaterThanOperator()
		{
			var testTime = new Time(12, 0, 0);

			var time1 = new Time(11, 0, 0);
			var time2 = new Time(13, 0, 0);
			var time3 = new Time(12, 1, 0);
			var time4 = new Time(11, 59, 0);
			var time5 = new Time(12, 0, 1);

			Assert.IsTrue(testTime > time1);
			Assert.IsTrue(time2 > testTime);
			Assert.IsTrue(time3 > testTime);
			Assert.IsTrue(testTime > time4);
			Assert.IsTrue(time5 > testTime);
		}

		[TestMethod]
		public void TestLessThanEqualToOperator()
		{

		}

		[TestMethod]
		public void TestGreaterThanEqualToOperator()
		{

		}

		[TestMethod]
		public void TestEqualsOperator()
		{
			var testTime = new Time(12, 0, 0);
			var time1 = new Time(11, 59, 0);
			var time2 = new Time(12, 1, 0);
			var time3 = new Time(12, 0, 0);

			Assert.IsFalse(testTime == time1);
			Assert.IsFalse(time1 == testTime);

			Assert.IsFalse(testTime == time2);
			Assert.IsFalse(time2 == testTime);

			Assert.IsTrue(testTime == time3);
			Assert.IsTrue(time3 == testTime);
		}

		[TestMethod]
		public void TestNotEqualsOperator()
		{
			var testTime = new Time(12, 0, 0);
			var time1 = new Time(11, 59, 12);
			var time2 = new Time(12, 0, 33);
			var time3 = new Time(12, 0, 0);

			Assert.IsTrue(testTime != time1);
			Assert.IsTrue(time1 != testTime);

			Assert.IsTrue(testTime != time2);
			Assert.IsTrue(time2 != testTime);

			Assert.IsFalse(testTime != time3);
			Assert.IsFalse(time3 != testTime);
		}

		[TestMethod]
		public void TestAddHours()
		{
			var time = new Time(14, 0, 0);

			var time1 = time.AddHours(3);
			var time2 = time.AddHours(24);
			var time3 = time.AddHours(27);
			var time4 = time.AddHours(-3);
			var time5 = time.AddHours(-24);
			var time6 = time.AddHours(-27);

			var newTime1 = time.AddHours(3245);
			var newTime2 = time.AddHours(-6254);
		}

		[TestMethod]
		public void TestAddMinutes()
		{
			var time = new Time(14, 0, 0);

			var time1 = time.AddMinutes(389823765);
		}

		[TestMethod]
		public void TestAddSeconds()
		{

		}
	}
}
