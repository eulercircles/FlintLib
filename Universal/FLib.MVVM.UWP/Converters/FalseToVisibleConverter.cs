using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace FLib.MVVM.Converters
{
	/// <summary>
	/// Converts a bound boolean value to an equivalent Visiblity value:
	/// Visible if the boolean is false, collapsed if true.
	/// </summary>
	public class FalseToVisibleConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			return (bool)value ? Visibility.Collapsed : Visibility.Visible;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			Visibility visibility = (Visibility)value;
			return (visibility == Visibility.Collapsed);
		}
	}
}
