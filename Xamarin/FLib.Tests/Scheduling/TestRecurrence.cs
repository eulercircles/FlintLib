using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using FLibXamarin.Scheduling;

namespace FLibXamarin.Tests.Scheduling
{
	[TestClass]
	public class TestRecurrence
	{
		[TestMethod]
		public void TestMethod1()
		{
			var code = "B06N2019042620190524NNB";

			var recurrence = RecurrenceRule.Decode(code);

			var encoded = recurrence.Encode();

			Assert.AreEqual(code, encoded);
		}
	}
}
