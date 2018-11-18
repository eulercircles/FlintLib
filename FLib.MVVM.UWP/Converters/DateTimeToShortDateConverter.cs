using System;
using System.Globalization;

using Windows.UI.Xaml.Data;

namespace FlintLib.MVVM.Converters
{
	public class DateTimeToShortDateConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			return ((DateTime)value).ToString("d", CultureInfo.CurrentCulture);
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return DateTime.Parse((string)value, CultureInfo.CurrentCulture);
		}
	}
}
