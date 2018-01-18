using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using FlintLib.Geometrics;

namespace FlintLib.Tests.Geometrics
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

			ImperialMeasure.TryParse(inputString1, out var parsedValue1);
			ImperialMeasure.TryParse(inputString2, out var parsedValue2);
			ImperialMeasure.TryParse(inputString3, out var parsedValue3);
			ImperialMeasure.TryParse(inputString4, out var parsedValue4);
			ImperialMeasure.TryParse(inputString5, out var parsedValue5);
		}
	}
}
