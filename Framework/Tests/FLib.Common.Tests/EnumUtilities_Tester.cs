using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FLib.Common.Tests
{
	internal enum TestValues1
	{
		A,B,C
	}

	internal enum TestValues2
	{
		A = 0,
		B = 1,
		C = 1,
		D = 2
	}

	[TestClass]
	public class EnumUtilities_Tester
	{
		[TestMethod]
		public void TestIncrement_Positive()
		{
			Assert.IsTrue(TestValues1.A.Increment() == TestValues1.B);
			Assert.IsTrue(TestValues1.B.Increment() == TestValues1.C);
			Assert.IsTrue(TestValues1.C.Increment() == TestValues1.A);

			Assert.IsTrue(TestValues2.A.Increment() == TestValues2.B);
			Assert.IsTrue(TestValues2.B.Increment() == TestValues2.D);
			Assert.IsTrue(TestValues2.C.Increment() == TestValues2.D);
			Assert.IsTrue(TestValues2.D.Increment() == TestValues2.A);
		}

		[TestMethod]
		public void TestDecrement_Positive()
		{
			Assert.IsTrue(TestValues1.C.Decrement() == TestValues1.B);
			Assert.IsTrue(TestValues1.B.Decrement() == TestValues1.A);
			Assert.IsTrue(TestValues1.A.Decrement() == TestValues1.C);

			Assert.IsTrue(TestValues2.D.Decrement() == TestValues2.B);
			Assert.IsTrue(TestValues2.C.Decrement() == TestValues2.A);
			Assert.IsTrue(TestValues2.B.Decrement() == TestValues2.A);
			Assert.IsTrue(TestValues2.A.Decrement() == TestValues2.D);
		}

		[TestMethod]
		public void TestIncrement_Negative()
		{
			Assert.IsTrue(TestValues2.A.Increment() == TestValues2.B);
			Assert.IsTrue(TestValues2.B.Increment() == TestValues2.C);
			Assert.IsTrue(TestValues2.C.Increment() == TestValues2.D);
			Assert.IsTrue(TestValues2.D.Increment() == TestValues2.A);
		}

		[TestMethod]
		public void TestDecrement_Negative()
		{
			Assert.IsTrue(TestValues2.D.Decrement() == TestValues2.C);
			Assert.IsTrue(TestValues2.C.Decrement() == TestValues2.B);
			Assert.IsTrue(TestValues2.B.Decrement() == TestValues2.A);
			Assert.IsTrue(TestValues2.A.Decrement() == TestValues2.C);
		}
	}
}
