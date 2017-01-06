using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Media;

namespace FlintLib.Utilities
{
	/// <summary>
	/// 
	/// </summary>
	public static class MediaUtilities
	{
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static Dictionary<string, SolidColorBrush> GetSolidColorBrushes()
		{
			var colors = typeof(Colors)
				.GetProperties()
				.Where(prop => typeof(Color).IsAssignableFrom(prop.PropertyType))
				.Select(prop => new KeyValuePair<string, Color>(prop.Name, (Color)prop.GetValue(null)));

			var result = new Dictionary<string, SolidColorBrush>();

			colors.ToList().ForEach(c => result.Add(c.Key, new SolidColorBrush(c.Value)));

			return result;
		}
	}
}
