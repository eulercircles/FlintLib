using System;
using System.Globalization;

using FlintLib.MVVM.Resources;

using Xamarin.Forms;

namespace FlintLib.MVVM.Converters
{
	public class DecimalToColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (!(value is decimal)) { throw new ArgumentException(string.Format(ErrorStrings.ParameterIsNotAValidType, typeof(decimal), value.GetType())); }

			// TODO: Make this more sophisticated so a configured color scheme can be passed to this converter.
			return ((decimal)value) < 0.00m ? Color.Red : Color.Black;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
