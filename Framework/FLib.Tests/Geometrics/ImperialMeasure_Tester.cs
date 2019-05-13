using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using FLib.Geometrics;

namespace FLib.Tests.Geometrics
{
	[TestClass]
	public class ImperialMeasure_Tester
	{
		[TestMethod]
		public void TestParseImperialMeasure()
		{
			var inputString1 = "3/8in";
			var inputString2 = "3.14in";
			var inputString3 = "4.5yd";
			var inputString4 = "9 5/16inches";
			var inputString5 = "6\"";

			CustomaryLength.TryParse(inputString1, out var parsedValue1);
			CustomaryLength.TryParse(inputString2, out var parsedValue2);
			CustomaryLength.TryParse(inputString3, out var parsedValue3);
			CustomaryLength.TryParse(inputString4, out var parsedValue4);
			CustomaryLength.TryParse(inputString5, out var parsedValue5);
		}
	}
}
