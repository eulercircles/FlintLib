using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FLib.Common.Tests
{
	internal enum TestValues
	{
		A,B,C,D,E,F,G
	}

	[TestClass]
	public class EnumUtilities_Tester
	{
		[TestMethod]
		public void TestIncrement()
		{
			Assert.IsTrue(TestValues.A.Increment() == TestValues.B);
		}

		[TestMethod]
		public void TestDecrement()
		{
			Assert.IsTrue(TestValues.G.Decrement() == TestValues.F);
		}

		[TestMethod]
		public void TestLowerBoundDecrement()
		{
			Assert.IsTrue(TestValues.A.Decrement() == TestValues.G);
		}

		[TestMethod]
		public void TestUpperBoundIncrement()
		{
			Assert.IsTrue(TestValues.G.Increment() == TestValues.A);
		}
	}
}
