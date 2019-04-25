﻿using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace FLib.MVVM.Converters
{
	public sealed class VisibilityValueConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			if (!(bool)value) { return Visibility.Visible.ToString(); }
			else { return Visibility.Collapsed.ToString(); }
		}

		// No need to implement converting back on a one-way binding 
		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException();
		}
	}
}
