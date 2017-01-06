using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlintLib.Utilities.UnitTests
{
	[TestClass]
	public class StringUtilities_UnitTests
	{
		[TestMethod]
		public void TestDoubleNewLine()
		{
			var doubleNewLine = Utilities.StringUtilities.DoubleNewLine;
			Assert.IsTrue(doubleNewLine == (Environment.NewLine + Environment.NewLine));
		}
	}
}
