using System;
using System.Globalization;
using System.Windows.Data;

namespace FlintLib.MVVM.Converters
{
	/// <summary>
	/// 
	/// </summary>
	public class DecimalToMoneyStringConverter : IValueConverter
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
			return string.Format("{0:C}", (decimal)value);
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
			return decimal.Parse((string)value,
				NumberStyles.AllowCurrencySymbol
				| NumberStyles.AllowDecimalPoint
				| NumberStyles.Number);
		}
	}
}
