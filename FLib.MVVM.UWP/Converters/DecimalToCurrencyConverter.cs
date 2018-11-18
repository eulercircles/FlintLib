using System;
using System.Globalization;

using Windows.UI.Xaml.Data;

using static FlintLib.MVVM.Properties.PublicResources;

namespace FlintLib.MVVM.Converters
{
	public class DecimalToCurrencyConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			if (value == null)
			{
				return CannotConvertStringPlaceholder;
			}
			else
			{
				if (value is decimal)
				{
					return ((decimal)value).ToString("C", CultureInfo.CurrentCulture);
				}
				else if (value is decimal?)
				{
					return ((decimal?)value).HasValue ? ((decimal?)value).Value.ToString("C", CultureInfo.CurrentCulture) : CannotConvertStringPlaceholder;
				}
				else { throw new InvalidOperationException(string.Format(ParameterIsNotAValidType, $"{typeof(decimal)} or {typeof(decimal?)}", value.GetType())); }
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			if (value == null || !(value is string)) { throw new InvalidOperationException(ConverterCannotConvertBack); }
			else
			{
				return decimal.Parse((string)value, NumberStyles.Currency);
			}
		}
	}
}
