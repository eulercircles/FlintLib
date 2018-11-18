using System;
using Windows.UI.Xaml.Data;

using static FlintLib.MVVM.Properties.PublicResources;

namespace FlintLib.MVVM.Converters
{
	public class IntToPercentStringConverter : IValueConverter
	{
		private static readonly string _error = "???";

		public object Convert(object value, Type targetType, object parameter, string language)
		{
			if (value != null && value is int)
			{
				var percent = (int)value;

				return percent.IsInRange(0, 100) ? $"{percent}%" : _error;
			}
			else { return _error; }
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new InvalidOperationException(ConverterCannotConvertBack);
		}
	}
}
