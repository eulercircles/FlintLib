using System;
using System.Globalization;
using System.Windows.Data;

using FLib.Common;
using static FLib.MVVM.Messages;

namespace FLib.MVVM.Converters
{
	public class IntToPercentStringConverter : IValueConverter
	{
		private static readonly string _error = "???";

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value != null && value is int)
			{
				var percent = (int)value;

				return percent.IsInRange(0, 100) ? $"{percent}%" : _error;
			}
			else { return _error; }
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new InvalidOperationException(ConverterCannotConvertBack);
		}
	}
}
