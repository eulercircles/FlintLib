using System;
using System.Globalization;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Xamarin.Forms;

using FLibXamarin.MVVM.Converters;

namespace FLibXamarin.Tests
{
	[TestClass]
	public class DecimalToColorConverter_Tester
	{
		private readonly decimal _lowerThreshold = 0.00m;
		private readonly decimal _upperThreshold = 100.00m;

		private readonly Color _belowThresholdColor = Color.Red;
		private readonly Color _betweenThresholdColor = Color.Yellow;
		private readonly Color _aboveThresholdColor = Color.Green;

		[TestMethod]
		public void TestConvertPositive()
		{
			var _converter = new DecimalToColorConverter()
			{
				LowerThreshold = _lowerThreshold,
				UpperThreshold = _upperThreshold,
				BelowThresholdColor = _belowThresholdColor,
				BetweenThresholdColor = _betweenThresholdColor,
				AboveThresholdColor = _aboveThresholdColor
			};

			Assert.IsTrue((Color)_converter.Convert(decimal.MinValue, typeof(Color), null, CultureInfo.CurrentCulture) == _belowThresholdColor);
			Assert.IsTrue((Color)_converter.Convert((_lowerThreshold - 0.01m), typeof(Color), null, CultureInfo.CurrentCulture) == _belowThresholdColor);
			Assert.IsTrue((Color)_converter.Convert((_lowerThreshold), typeof(Color), null, CultureInfo.CurrentCulture) == _belowThresholdColor);
			Assert.IsTrue((Color)_converter.Convert((_lowerThreshold + 0.01m), typeof(Color), null, CultureInfo.CurrentCulture) == _betweenThresholdColor);
			Assert.IsTrue((Color)_converter.Convert((_upperThreshold - 0.01m), typeof(Color), null, CultureInfo.CurrentCulture) == _betweenThresholdColor);
			Assert.IsTrue((Color)_converter.Convert((_upperThreshold), typeof(Color), null, CultureInfo.CurrentCulture) == _aboveThresholdColor);
			Assert.IsTrue((Color)_converter.Convert((_upperThreshold + 0.01m), typeof(Color), null, CultureInfo.CurrentCulture) == _aboveThresholdColor);
			Assert.IsTrue((Color)_converter.Convert(decimal.MaxValue, typeof(Color), null, CultureInfo.CurrentCulture) == _aboveThresholdColor);
		}
	}
}
