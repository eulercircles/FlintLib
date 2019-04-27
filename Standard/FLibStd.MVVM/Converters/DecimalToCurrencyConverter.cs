using System;
using System.Globalization;

using FlintLib.MVVM.Resources;
using Xamarin.Forms;

namespace FlintLib.MVVM.Converters
{
	public class DecimalToCurrencyConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
			{
				return ErrorStrings.CannotConvertStringPlaceholder;
			}
			else
			{
				if (value is decimal)
				{
					return ((decimal)value).ToString("C", culture);
				}
				else if (value is decimal?)
				{
					return ((decimal?)value).HasValue ? ((decimal?)value).Value.ToString("C", culture) : ErrorStrings.CannotConvertStringPlaceholder;
				}
				else { throw new InvalidOperationException(string.Format(ErrorStrings.ParameterIsNotAValidType, $"{typeof(decimal)} or {typeof(decimal?)}", value.GetType())); }
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null || !(value is string)) { throw new InvalidOperationException(ErrorStrings.ConverterCannotConvertBack); }
			else
			{
				return decimal.Parse((string)value, NumberStyles.Currency);
			}
		}
	}
}
