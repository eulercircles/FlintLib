#region Using Statements
using System;
using System.Linq;
using System.Reflection;
using System.ComponentModel;
using System.Collections.Generic;
#endregion // Using Statements

namespace FLib.Common
{
	/// <summary>
	/// 
	/// </summary>
	public static class EnumUtilities
	{
		/// <summary>
		/// Reads all the members of an enumeration and returns a dictionary whose keys are either the value of the description attribute for that member or the string equivalent of the member name,
		/// and whose values are the enum values that correspond to those descriptions or names. Useful for converting enums to an appropriate format for using in selection lists.
		/// </summary>
		/// <remarks>Based on blog by Brandon Truong - http://brandontruong.blogspot.com/2010/04/use-enum-as-itemssource.html</remarks>
		public static Dictionary<string, T> GetEnumDescriptions<T>()
		{
			var fields = typeof(T).GetFields().Where(info => info.FieldType.Equals(typeof(T)));
			var enumsAndDescriptions = from field in fields
				select new KeyValuePair<string, T>(GetEnumDescription(field), (T)Enum.Parse(typeof(T), field.Name, false));
			
			var results = new Dictionary<string, T>();
			foreach (KeyValuePair<string, T> pair in enumsAndDescriptions) results.Add(pair.Key, pair.Value);

			return results;
		}

		/// <remarks>Based on blog by Brandon Truong - http://brandontruong.blogspot.com/2010/04/use-enum-as-itemssource.html</remarks>
		private static string GetEnumDescription(FieldInfo field)
		{
			DescriptionAttribute[] attributes =
				(DescriptionAttribute[])field.GetCustomAttributes(
					typeof(DescriptionAttribute), false);
			if (attributes.Length > 0) { return attributes[0].Description; }
			else { return field.Name; }
		}
	}
}
