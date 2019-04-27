using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlintLib.Common.Tests
{
	internal enum MyValues
	{
		A,B,C,D,E,F,G
	}

	[TestClass]
	public class EnumUtilities_Tester
	{
		[TestMethod]
		public void TestLowerBoundIncrementDecrement()
		{
			var next = MyValues.A.Increment();
			Assert.IsTrue(next == MyValues.B);
			var prev = MyValues.A.Decrement();
			Assert.IsTrue(prev == MyValues.G);
		}

		[TestMethod]
		public void TestUpperBoundIncrementDecrement()
		{
			var prev = MyValues.G.Decrement();
			Assert.IsTrue(prev == MyValues.F);
			var next = MyValues.G.Increment();
			Assert.IsTrue(next == MyValues.A);
		}
	}
}
