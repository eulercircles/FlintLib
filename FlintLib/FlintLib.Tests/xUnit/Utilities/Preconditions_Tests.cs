using System;

using Xunit;

using FlintLib.Utilities;

namespace FlintLib.Tests.xUnit.Utilities
{
	public class Preconditions_Tests
	{
		[Fact]
		public void TestIsIntegerWithKnownGoods()
		{
			var valueString1 = "1";
			var valueString2 = "5";
			var valueString3 = "-99";
			var valueString4 = "0";
			var valueString5 = "92805637";

			Assert.True(valueString1.IsInteger());
			Assert.True(valueString2.IsInteger());
			Assert.True(valueString3.IsInteger());
			Assert.True(valueString4.IsInteger());
			Assert.True(valueString5.IsInteger());
		}

		[Fact]
		public void TestIsIntegerWithKnownBads()
		{
			var valueString1 = "95s";
			var valueString2 = "Test";
			var valueString3 = string.Empty;
			var valueString4 = " ";
			var valueString5 = "43.928";

			Assert.False(valueString1.IsInteger());
			Assert.False(valueString2.IsInteger());
			Assert.False(valueString3.IsInteger());
			Assert.False(valueString4.IsInteger());
			Assert.False(valueString5.IsInteger());
		}

		[Fact]
		public void TestIsNumericValueWithKnownGoods()
		{
			var valueString1 = "1";
			var valueString2 = "5";
			var valueString3 = "-99";
			var valueString4 = "0";
			var valueString5 = "92805637";

			Assert.True(valueString1.IsInteger());
			Assert.True(valueString2.IsInteger());
			Assert.True(valueString3.IsInteger());
			Assert.True(valueString4.IsInteger());
			Assert.True(valueString5.IsInteger());
		}

		[Fact]
		public void TestIsNumericValueWithKnownBads()
		{
			var valueString1 = "95s";
			var valueString2 = "Test";
			var valueString3 = string.Empty;
			var valueString4 = " ";
			var valueString5 = "E1vi$ h@s L3ft";

			Assert.False(valueString1.IsInteger());
			Assert.False(valueString2.IsInteger());
			Assert.False(valueString3.IsInteger());
			Assert.False(valueString4.IsInteger());
			Assert.False(valueString5.IsInteger());
		}
	}
}
