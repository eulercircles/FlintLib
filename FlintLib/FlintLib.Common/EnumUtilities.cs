#region Using Statements
using System;
using System.Linq;
using System.Reflection;
using System.ComponentModel;
using System.Collections.Generic;
#endregion // Using Statements

namespace FlintLib.Common
{
	/// <summary>
	/// 
	/// </summary>
	public static class EnumUtilities
	{
		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
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

		/// <summary>
		/// 
		/// </summary>
		/// <param name="field"></param>
		/// <returns></returns>
		// Based on blog by Brandon Truong - http://brandontruong.blogspot.com/2010/04/use-enum-as-itemssource.html
		public static string GetEnumDescription(FieldInfo field)
		{
			DescriptionAttribute[] attributes =
				(DescriptionAttribute[])field.GetCustomAttributes(
					typeof(DescriptionAttribute), false);

			if (attributes.Length > 0) { return attributes[0].Description; }
			else { return field.Name; }
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string Description(this Enum value)
		{
			FieldInfo field = value.GetType().GetField(value.ToString());
			DescriptionAttribute attribute
				= Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute))
				as DescriptionAttribute;
			return attribute == null ? value.ToString() : attribute.Description;
		}
	}
}
