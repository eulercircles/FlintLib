﻿using System;
using System.Windows;
using System.Windows.Data;
using System.Globalization;

namespace FlintLib.MVVM.Converters
{
	public class BoolNotConverter : IValueConverter
	{

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (bool)value ? false : true;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return !(bool)value;
		}
	}
}
