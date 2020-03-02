using System;
using System.Windows.Data;
using System.Globalization;

using static FLib.Common.Messages;
using static FLib.MVVM.Messages;

namespace FLib.MVVM.Converters
{
	public class DecimalToStringConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null) { return CannotConvertStringPlaceholder; }

			if (value is decimal) { return ((decimal)value).ToString(culture); }
			else if (value is decimal?) { return ((decimal?)value).HasValue ? ((decimal?)value).Value.ToString(culture) : CannotConvertStringPlaceholder; }
			else { throw new InvalidOperationException(string.Format(fParameterIsNotAValidType, $"{typeof(decimal)} or {typeof(decimal?)}", value.GetType())); }
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null || !(value is string)) { throw new InvalidOperationException(ConverterCannotConvertBack); }

			return decimal.Parse((string)value, NumberStyles.Any, culture);
		}
	}
}
