#region Using Statements
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
#endregion // Using Statements

namespace FlintLib.Utilities
{
	public static class EnumUtilities
	{
		// Based on blog by Brandon Truong - http://brandontruong.blogspot.com/2010/04/use-enum-as-itemssource.html
		public static Dictionary<string, T> GetEnumDescriptions<T>()
		{
			var x = typeof(T).GetFields().Where(info => info.FieldType.Equals(typeof(T)));
			IEnumerable<KeyValuePair<string, T>> enumsAndDescriptions = from field in x
				select new KeyValuePair<string, T>(GetEnumDescription(field), (T)Enum.Parse(typeof(T), field.Name, false));
			
			Dictionary<string, T> dictionary = new Dictionary<string, T>();
			foreach (KeyValuePair<string, T> pair in enumsAndDescriptions) dictionary.Add(pair.Key, pair.Value);

			return dictionary;
		}

		// Based on blog by Brandon Truong - http://brandontruong.blogspot.com/2010/04/use-enum-as-itemssource.html
		public static string GetEnumDescription(FieldInfo field)
		{
			System.ComponentModel.DescriptionAttribute[] attributes =
				(System.ComponentModel.DescriptionAttribute[])field.GetCustomAttributes(
					typeof(System.ComponentModel.DescriptionAttribute), false);
			if (attributes.Length > 0) { return attributes[0].Description; }
			else { return field.Name; }
		}

		public static string GetEnumDescription(this Enum value)
		{
			FieldInfo field = value.GetType().GetField(value.ToString());
			DescriptionAttribute attribute
				= Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute))
				as DescriptionAttribute;
			return attribute == null ? value.ToString() : attribute.Description;
		}
	}
}
