using System;
using Windows.UI;
using Windows.UI.Xaml.Data;
using static FlintLib.MVVM.Properties.PublicResources;

namespace FlintLib.MVVM.Converters
{
	public class DecimalToColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			if (!(value is decimal)) { throw new ArgumentException(string.Format(ParameterIsNotAValidType, typeof(decimal), value.GetType())); }

			// TODO: Make this more sophisticated so a configured color scheme can be passed to this converter.
			return ((decimal)value) < 0.00m ? Colors.Red : Colors.Black;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}
}
