using System;
using System.Globalization;

using Xamarin.Forms;

namespace FlintLib.MVVM.Converters
{
	public class BoolNotConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (bool)value ? false : true;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return !(bool)value;
		}
	}
}
