using System;
using System.Windows.Data;
using System.Globalization;

using static FLib.Common.Messages;
using static FLib.MVVM.Messages;

namespace FLib.MVVM.Converters
{
	public class FloatToPercentStringConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
			{
				return CannotConvertStringPlaceholder;
			}
			else
			{
				if (value is float)
				{
					return ((float)value).ToString("P0", CultureInfo.CurrentCulture);
				}
				else if (value is float?)
				{
					return ((float?)value).HasValue ? ((float?)value).Value.ToString("P0", CultureInfo.CurrentCulture) : CannotConvertStringPlaceholder;
				}
				else { throw new InvalidOperationException(string.Format(fParameterIsNotAValidType, $"{typeof(float)} or {typeof(float?)}", value.GetType())); }
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new InvalidOperationException(ConverterCannotConvertBack);
		}
	}
}
