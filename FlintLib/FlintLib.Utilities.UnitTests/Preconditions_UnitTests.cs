using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlintLib.Utilities.UnitTests
{
	[TestClass]
	public class Preconditions_UnitTests
	{
		[TestMethod]
		public void TestIsIntegerWithKnownGoods()
		{
			var valueString1 = "1";
			var valueString2 = "5";
			var valueString3 = "-99";
			var valueString4 = "0";
			var valueString5 = "92805637";

			Assert.IsTrue(valueString1.IsInteger());
			Assert.IsTrue(valueString2.IsInteger());
			Assert.IsTrue(valueString3.IsInteger());
			Assert.IsTrue(valueString4.IsInteger());
			Assert.IsTrue(valueString5.IsInteger());
		}

		[TestMethod]
		public void TestIsIntegerWithKnownBads()
		{
			var valueString1 = "95s";
			var valueString2 = "Test";
			var valueString3 = string.Empty;
			var valueString4 = " ";
			var valueString5 = "43.928";

			Assert.IsFalse(valueString1.IsInteger());
			Assert.IsFalse(valueString2.IsInteger());
			Assert.IsFalse(valueString3.IsInteger());
			Assert.IsFalse(valueString4.IsInteger());
			Assert.IsFalse(valueString5.IsInteger());
		}

		[TestMethod]
		public void TestIsNumericValueWithKnownGoods()
		{
			var valueString1 = "1";
			var valueString2 = "5";
			var valueString3 = "-99";
			var valueString4 = "0";
			var valueString5 = "92805637";

			Assert.IsTrue(valueString1.IsInteger());
			Assert.IsTrue(valueString2.IsInteger());
			Assert.IsTrue(valueString3.IsInteger());
			Assert.IsTrue(valueString4.IsInteger());
			Assert.IsTrue(valueString5.IsInteger());
		}

		[TestMethod]
		public void TestIsNumericValueWithKnownBads()
		{
			var valueString1 = "95s";
			var valueString2 = "Test";
			var valueString3 = string.Empty;
			var valueString4 = " ";
			var valueString5 = "E1vi$ h@s L3ft";

			Assert.IsFalse(valueString1.IsInteger());
			Assert.IsFalse(valueString2.IsInteger());
			Assert.IsFalse(valueString3.IsInteger());
			Assert.IsFalse(valueString4.IsInteger());
			Assert.IsFalse(valueString5.IsInteger());
		}
	}
}
