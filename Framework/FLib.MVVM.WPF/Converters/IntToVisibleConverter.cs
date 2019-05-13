using System;
using System.Windows;
using System.Windows.Data;
using System.Globalization;

using static FLib.MVVM.Messages;

namespace FLib.MVVM.Converters
{
	/// <summary>
	/// Converts a bound integer value to a Visibility - Visible if the bound value is greater than or equal to zero, 
	/// Collapsed otherwise
	/// </summary>
	public class IntToVisibleConverter : IValueConverter 
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{ 
			return (int)value > 0 ? Visibility.Visible : Visibility.Collapsed; 
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) 
		{
			throw new InvalidOperationException(ConverterCannotConvertBack); 
		}
	}
}
