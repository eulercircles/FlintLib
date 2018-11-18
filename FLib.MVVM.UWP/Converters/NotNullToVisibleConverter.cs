using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using static FlintLib.MVVM.Properties.PublicResources;

namespace FlintLib.MVVM.Converters
{
	/// <summary>
	/// Converts the bound object to a Visibility value based on whether the object is null.  Returns Visible if the object
	/// is not null, Collapsed otherwise.
	/// </summary>
	public class NotNullToVisibleConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			return (value != null) ? Visibility.Visible : Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new InvalidOperationException(ConverterCannotConvertBack); 
		}
	}
}
