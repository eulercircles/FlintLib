﻿using System;
using System.Globalization;
using System.Windows.Data;

using FlintLib.Common;
using FlintLib.MVVM.Resources;

namespace FlintLib.MVVM.Converters
{
	public class IntToPercentStringConverter : IValueConverter
	{
		private static string _error = "???";

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
			throw new InvalidOperationException(ErrorStrings.ConverterCannotConvertBack);
		}
	}
}
