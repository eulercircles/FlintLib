using System;

using Xunit;

using FlintLib.Utilities;

namespace FlintLib.Tests.xUnit.Utilities
{
	public class StringUtilities_Tests
	{
		[Fact]
		public void TestDoubleNewLine()
		{
			var doubleNewLine = StringUtilities.DoubleNewLine;
			Assert.True(doubleNewLine == (Environment.NewLine + Environment.NewLine));
		}
	}
}
