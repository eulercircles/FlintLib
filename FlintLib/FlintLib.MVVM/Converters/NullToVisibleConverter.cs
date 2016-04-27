using System;
using System.Windows;
using System.Windows.Data;
using System.Globalization;

using FlintLib.MVVM.Resources;

namespace FlintLib.MVVM.Converters
{
	/// <summary>
	/// Converts the bound object to a Visibility value based on whether the object is null.  Returns Visible if the object
	/// is null, Collapsed otherwise.
	/// </summary>
	public class NullToVisibleConverter : IValueConverter
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
			return (value == null) ? Visibility.Visible : Visibility.Collapsed;
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
