#region Using Statements
using System;
using System.Linq;
using System.Reflection;
using System.ComponentModel;
using System.Collections.Generic;
#endregion // Using Statements

namespace FlintLib.Utilities
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
			var fieldInfos = typeof(T).GetFields().Where(info => info.FieldType.Equals(typeof(T)));

			var enumsAndDescriptions = from field
																 in fieldInfos
																 select new KeyValuePair<string, T>(GetEnumDescription(field), (T)Enum.Parse(typeof(T), field.Name, false));
			
			var result = new Dictionary<string, T>();
			enumsAndDescriptions.ToList().ForEach(p => result.Add(p.Key, p.Value));

			return result;
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
