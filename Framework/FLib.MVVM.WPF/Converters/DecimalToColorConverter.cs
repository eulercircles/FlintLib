﻿using System;
using System.Globalization;
using System.Windows.Data;

using static FLib.MVVM.Properties.PublicResources;
using System.Windows.Media;

namespace FLib.MVVM.Converters
{
	public class DecimalToColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (!(value is decimal)) { throw new ArgumentException(string.Format(ParameterIsNotAValidType, typeof(decimal), value.GetType())); }

			// TODO: Make this more sophisticated so a configured color scheme can be passed to this converter.
			return ((decimal)value) < 0.00m ? Colors.Red : Colors.Black;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}