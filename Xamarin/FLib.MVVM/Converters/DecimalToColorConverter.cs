using System;
using System.Diagnostics;
using System.Globalization;

using Xamarin.Forms;

using static FLibXamarin.MVVM.Properties.InternalStrings;

namespace FLibXamarin.MVVM.Converters
{
	public class DecimalToColorConverter : BindableObject, IValueConverter
	{
		#region Bindable Properties
		private static readonly BindableProperty _belowThresholdColorProperty = BindableProperty.Create("BelowThresholdColor", typeof(Color), typeof(DecimalToColorConverter), Color.Transparent);
		private static readonly BindableProperty _betweenThresholdColorProperty = BindableProperty.Create("BetweenThresholdColor", typeof(Color), typeof(DecimalToColorConverter), Color.Transparent);
		private static readonly BindableProperty _aboveThresholdColorProperty = BindableProperty.Create("AboveThresholdColor", typeof(Color), typeof(DecimalToColorConverter), Color.Transparent);

		private static readonly BindableProperty _lowerThresholdProperty = BindableProperty.Create("LowerThreshold", typeof(decimal?), typeof(DecimalToColorConverter), null);
		private static readonly BindableProperty _upperThresholdProperty = BindableProperty.Create("UpperThreshold", typeof(decimal?), typeof(DecimalToColorConverter), null);

		public Color BelowThresholdColor
		{
			get => (Color)GetValue(_belowThresholdColorProperty);
			set => SetValue(_belowThresholdColorProperty, value);
		}

		public Color BetweenThresholdColor
		{
			get => (Color)GetValue(_betweenThresholdColorProperty);
			set => SetValue(_betweenThresholdColorProperty, value);
		}

		public Color AboveThresholdColor
		{
			get => (Color)GetValue(_aboveThresholdColorProperty);
			set => SetValue(_aboveThresholdColorProperty, value);
		}

		public decimal? LowerThreshold
		{
			get => (decimal?)GetValue(_lowerThresholdProperty);
			set => SetValue(_lowerThresholdProperty, value);
		}

		public decimal? UpperThreshold
		{
			get => (decimal?)GetValue(_upperThresholdProperty);
			set => SetValue(_upperThresholdProperty, value);
		}
		#endregion Bindable Properties

		#region IValueConverter Implementation
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			Debug.Assert(value != null && value is decimal);

			if (value == null || !(value is decimal)) { return null; }

			var decimalValue = (decimal)value;

			if (decimalValue <= LowerThreshold) { return BelowThresholdColor; }
			else if (decimalValue > LowerThreshold && decimalValue < UpperThreshold) { return BetweenThresholdColor; }
			else if (decimalValue >= UpperThreshold) { return AboveThresholdColor; }
			else { throw new Exception(); }
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new Exception(Message_ConverterCannotConvertBack);
		}
		#endregion IValueConverter Implementation
	}
}
