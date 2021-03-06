﻿using System;
using System.Globalization;

using FlintLib.MVVM.Resources;
using Xamarin.Forms;

namespace FlintLib.MVVM.Converters
{
	public class FloatToPercentStringConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
			{
				return ErrorStrings.CannotConvertStringPlaceholder;
			}
			else
			{
				if (value is float)
				{
					return ((float)value).ToString("P0", CultureInfo.CurrentCulture);
				}
				else if (value is float?)
				{
					return ((float?)value).HasValue ? ((float?)value).Value.ToString("P0", CultureInfo.CurrentCulture) : ErrorStrings.CannotConvertStringPlaceholder;
				}
				else { throw new InvalidOperationException(string.Format(ErrorStrings.ParameterIsNotAValidType, $"{typeof(float)} or {typeof(float?)}", value.GetType())); }
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new InvalidOperationException(ErrorStrings.ConverterCannotConvertBack);
		}
	}
}
