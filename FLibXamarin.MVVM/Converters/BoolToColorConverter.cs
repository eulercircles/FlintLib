using System;
using System.Globalization;

using Xamarin.Forms;

namespace FLibXamarin.MVVM.Converters
{
	public class BoolToColorConverter : BindableObject, IValueConverter
	{
		#region Bindable Properties
		private static readonly BindableProperty _trueColorProperty = BindableProperty.Create("TrueColor", typeof(Color), typeof(BoolToColorConverter), Color.Transparent);

		private static readonly BindableProperty _falseColorProperty =
			BindableProperty.Create("FalseColor", typeof(Color), typeof(BoolToColorConverter), Color.Transparent);

		public Color TrueColor
		{
			get => (Color)GetValue(_trueColorProperty);
			set => SetValue(_trueColorProperty, value);
		}

		public Color FalseColor
		{
			get => (Color)GetValue(_falseColorProperty);
			set => SetValue(_falseColorProperty, value);
		}
		#endregion Bindable Properties

		#region IValueConverter Implementation
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null || !(value is bool)) { return null; }
			return (bool)value ? TrueColor : FalseColor;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if ((Color)value == TrueColor) { return true; }
			else if ((Color)value == FalseColor) { return false; }
			else { return null; }
		}
		#endregion IValueConverter Implementation
	}
}
