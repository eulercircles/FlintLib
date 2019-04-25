using System;
using System.Globalization;
using System.Windows.Data;

namespace FLib.MVVM.Converters
{
	public class DateTimeToShortDateConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return ((DateTime)value).ToString("d", culture);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return DateTime.Parse((string)value, culture);
		}
	}
}
