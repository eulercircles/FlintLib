using System;
using System.Windows;
using System.Windows.Data;
using System.Globalization;

using static FLib.MVVM.Messages;

namespace FLib.MVVM.Converters
{
	/// <summary>
	/// Converts the bound object to a Visibility value based on whether the object is null.  Returns Visible if the object
	/// is not null, Collapsed otherwise.
	/// </summary>
	public class NotNullToVisibleConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return (value != null) ? Visibility.Visible : Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new InvalidOperationException(ConverterCannotConvertBack); 
		}
	}
}
