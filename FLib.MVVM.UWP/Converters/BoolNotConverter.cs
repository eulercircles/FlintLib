using System;
using System.Globalization;

using Windows.UI.Xaml.Data;

namespace FlintLib.MVVM.Converters
{
	public class BoolNotConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			return (bool)value ? false : true;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return !(bool)value;
		}
	}
}
