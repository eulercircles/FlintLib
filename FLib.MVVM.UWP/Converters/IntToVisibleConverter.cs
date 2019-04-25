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
	public class IntToVisibleConverter : IValueConverter 
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{ 
			return (int)value > 0 ? Visibility.Visible : Visibility.Collapsed; 
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language) 
		{
			throw new InvalidOperationException(ConverterCannotConvertBack); 
		}
	}
}
