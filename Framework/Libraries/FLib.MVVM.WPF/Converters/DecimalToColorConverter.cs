using System;
using System.Globalization;
using System.Windows.Data;

using System.Windows.Media;

using static FLib.Common.Messages;

namespace FLib.MVVM.Converters
{
	public class DecimalToColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (!(value is decimal)) { throw new ArgumentException(string.Format(fParameterIsNotAValidType, typeof(decimal), value.GetType())); }

			// TODO: Make this more sophisticated so a configured color scheme can be passed to this converter.
			return ((decimal)value) < 0.00m ? Colors.Red : Colors.Black;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
