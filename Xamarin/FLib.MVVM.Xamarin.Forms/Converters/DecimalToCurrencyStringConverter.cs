using System;
using System.Globalization;

using Xamarin.Forms;

using static FLib.Common.Messages;
using static FLib.MVVM.Messages;

namespace FLib.MVVM.Xamarin.Forms.Converters
{
	public class DecimalToCurrencyStringConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null) { return CannotConvertStringPlaceholder; }
			else
			{
				if (value is decimal)
				{
					return ((decimal)value).ToString("C", culture);
				}
				else if (value is decimal?)
				{
					return ((decimal?)value).HasValue ? ((decimal?)value).Value.ToString("C", culture) : CannotConvertStringPlaceholder;
				}
				else { throw new InvalidOperationException(string.Format(fMessage_ParameterIsNotAValidType, $"{typeof(decimal)} or {typeof(decimal?)}", value.GetType())); }
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null || !(value is string)) { throw new InvalidOperationException(ConverterCannotConvertBack); }
			else
			{
				return decimal.Parse((string)value, NumberStyles.Currency, culture);
			}
		}
	}
}
