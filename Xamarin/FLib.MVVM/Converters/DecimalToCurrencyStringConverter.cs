using System;
using System.Globalization;

using Xamarin.Forms;

using static FLibXamarin.MVVM.Properties.InternalStrings;

namespace FLibXamarin.MVVM.Converters
{
	public class DecimalToCurrencyStringConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null) { return Placeholder_CannotConvertToString; }
			else
			{
				if (value is decimal)
				{
					return ((decimal)value).ToString("C", culture);
				}
				else if (value is decimal?)
				{
					return ((decimal?)value).HasValue ? ((decimal?)value).Value.ToString("C", culture) : Placeholder_CannotConvertToString;
				}
				else { throw new InvalidOperationException(string.Format(fMessage_ParameterIsNotAValidType, $"{typeof(decimal)} or {typeof(decimal?)}", value.GetType())); }
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null || !(value is string)) { throw new InvalidOperationException(Message_ConverterCannotConvertBack); }
			else
			{
				return decimal.Parse((string)value, NumberStyles.Currency, culture);
			}
		}
	}
}
