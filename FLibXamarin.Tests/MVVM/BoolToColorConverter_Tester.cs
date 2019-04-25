using System;
using System.Globalization;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Xamarin.Forms;

using FLibXamarin.MVVM.Converters;

namespace FLibXamarin.Tests.MVVM
{
	[TestClass]
	public class BoolToColorConverter_Tester
	{
		private readonly BoolToColorConverter _converter = new BoolToColorConverter() { TrueColor = Color.Green, FalseColor = Color.Red };

		[TestMethod]
		public void TestConvertPositive()
		{
			Assert.IsTrue((Color)_converter.Convert(true, typeof(Color), null, CultureInfo.CurrentCulture) == Color.Green);
			Assert.IsTrue((Color)_converter.Convert(false, typeof(Color), null, CultureInfo.CurrentCulture) == Color.Red);
		}

		[TestMethod]
		public void TestConvertBackPositive()
		{
			Assert.IsTrue((bool)_converter.ConvertBack(Color.Green, typeof(bool), null, CultureInfo.CurrentCulture));
			Assert.IsFalse((bool)_converter.ConvertBack(Color.Red, typeof(bool), null, CultureInfo.CurrentCulture));
		}
	}
}
