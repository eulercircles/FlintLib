using System;
using System.Windows;
using System.Windows.Data;
using System.Globalization;

using FlintLib.MVVM.Resources;

namespace FlintLib.MVVM.Converters
{
	/// <summary>
	/// Converts a bound integer value to a Visibility - Visible if the bound value is greater than or equal to zero, 
	/// Collapsed otherwise
	/// </summary>
	public class IntToVisibleConverter : IValueConverter 
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="value"></param>
		/// <param name="targetType"></param>
		/// <param name="parameter"></param>
		/// <param name="culture"></param>
		/// <returns></returns>
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{ 
			return (int)value > 0 ? Visibility.Visible : Visibility.Collapsed; 
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="value"></param>
		/// <param name="targetType"></param>
		/// <param name="parameter"></param>
		/// <param name="culture"></param>
		/// <returns></returns>
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) 
		{
			throw new InvalidOperationException(ErrorStrings.ConverterCannotConvertBack); 
		}
	}
}
