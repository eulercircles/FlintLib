using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using static FLib.MVVM.Properties.PublicResources;

namespace FLib.MVVM.Converters
{
	/// <summary>
	/// Converts the bound object to a Visibility value based on whether the object is null.  Returns Visible if the object
	/// is null, Collapsed otherwise.
	/// </summary>
	public class NullToVisibleConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			return (value == null) ? Visibility.Visible : Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new InvalidOperationException(ConverterCannotConvertBack); 
		}
	}
}
