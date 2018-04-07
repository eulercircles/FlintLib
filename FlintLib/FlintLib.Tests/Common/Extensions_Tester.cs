using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using FlintLib.Common;

namespace FlintLib.Tests.Common
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
		public void TestToCurrencyStringWithKnownGoods()
		{
			throw new NotImplementedException();
		}
	}
}
