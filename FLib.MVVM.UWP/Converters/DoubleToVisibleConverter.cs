using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using static FlintLib.MVVM.Properties.PublicResources;

namespace FlintLib.MVVM.Converters
{
	/// <summary>
	/// Converts a bound integer value to a Visibility - Visible if the bound value is greater than or equal to zero, 
	/// Collapsed otherwise
	/// </summary>
	public class DoubleToVisibleConverter : IValueConverter
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="value"></param>
		/// <param name="targetType"></param>
		/// <param name="parameter"></param>
		/// <param name="culture"></param>
		/// <returns></returns>
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			return ((value != null) && (double)value > 0) ? Visibility.Visible : Visibility.Collapsed;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="value"></param>
		/// <param name="targetType"></param>
		/// <param name="parameter"></param>
		/// <param name="culture"></param>
		/// <returns></returns>
		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new InvalidOperationException(ConverterCannotConvertBack);
		}
	}
}
