using System;
using System.Globalization;
using Windows.UI.Xaml.Data;
using static FlintLib.MVVM.Properties.PublicResources;

namespace FlintLib.MVVM.Converters
{
	public class FloatToPercentStringConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
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
				else { throw new InvalidOperationException(string.Format(ParameterIsNotAValidType, $"{typeof(float)} or {typeof(float?)}", value.GetType())); }
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new InvalidOperationException(ConverterCannotConvertBack);
		}
	}
}
