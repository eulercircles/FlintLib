using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlintLib.Common.Tests
{
	[TestClass]
	public class Extensions_Tester
	{
		[TestMethod]
		public void TestToIntWithKnownGoods()
		{
			string val1 = "35";
			string val2 = "49.8";
			string val3 = "Hubbub";

			var result1 = val1.ToInt();
			var result2 = val2.ToInt();
			var result3 = val3.ToInt();

			Assert.IsTrue(result1 is int && result1 == 35);
			Assert.IsNull(result2);
			Assert.IsNull(result3);
		}

		[TestMethod]
		public void TestToDecimalWithKnownGoods()
		{
			string val1 = "35";
			string val2 = "49.8";
			string val3 = "Hubbub";

			var result1 = val1.ToDecimal();
			var result2 = val2.ToDecimal();
			var result3 = val3.ToDecimal();

			Assert.IsTrue(result1.HasValue && result1 == 35m);
			Assert.IsTrue(result2.HasValue && result2 == 49.8m);
			Assert.IsNull(result3);
		}

		[TestMethod]
		public void TestGenericIsInRange()
		{
			byte lowerBound = 5;
			byte upperBound = 62;

			byte value1 = 32;
			byte value2 = 5;
			byte value3 = 4;
			byte value4 = 62;
			byte value5 = 63;

			Assert.IsTrue(value1.IsInRange(lowerBound, upperBound));
			Assert.IsTrue(value2.IsInRange(lowerBound, upperBound));
			Assert.IsFalse(value3.IsInRange(lowerBound, upperBound));
			Assert.IsTrue(value4.IsInRange(lowerBound, upperBound));
			Assert.IsFalse(value5.IsInRange(lowerBound, upperBound));
		}
	}
}
