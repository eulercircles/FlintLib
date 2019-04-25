using System;
using System.Windows;
using System.Windows.Data;
using System.Globalization;

namespace FLib.MVVM.Converters
{
	/// <summary>
	/// Converts a bound boolean value to an equivalent Visiblity value: 
	/// Visible if the boolean is true, collapsed if false.
	/// </summary>
	public class TrueToVisibleConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (bool)value ? Visibility.Visible : Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			Visibility visibility = (Visibility)value;
			return (visibility == Visibility.Visible);
		}
	}
}
