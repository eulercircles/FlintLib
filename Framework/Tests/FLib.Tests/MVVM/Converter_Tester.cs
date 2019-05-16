using System;
using System.Globalization;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using FLib.MVVM.Converters;

namespace FLib.Tests.MVVM
{
	[TestClass]
	public class Converter_Tester
	{
		[TestMethod]
		public void TestBoolNotConverterWithKnownGoods()
		{
			var converter = new BoolNotConverter();

			var result1 = (bool)converter.Convert(true, typeof(bool), null, CultureInfo.CurrentCulture);
			Assert.IsFalse(result1);

			var result2 = (bool)converter.ConvertBack(result1, typeof(bool), null, CultureInfo.CurrentCulture);
			Assert.IsTrue(result2);
		}

		[TestMethod]
		public void TestBoolNotConverterWithKnownBads()
		{
			throw new NotImplementedException();
		}

		[TestMethod]
		public void TestDecimalToCurrencyConverterWithKnownGoods()
		{
			var converter = new DecimalToCurrencyConverter();

			var result1 = converter.Convert(100m, typeof(string), null, CultureInfo.CurrentCulture).ToString();
			Assert.IsTrue(result1 == "$100.00");

			var result2 = (decimal)converter.ConvertBack(result1, typeof(decimal), null, CultureInfo.CurrentCulture);
			Assert.IsTrue(result2 == 100);
		}

		[TestMethod]
		public void TestDecimalToCurrencyConverterWithKnownBads()
		{
			throw new NotImplementedException();
		}
	}
}
