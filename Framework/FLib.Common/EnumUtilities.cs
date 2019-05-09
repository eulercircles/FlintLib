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
		/// <remarks>Based on blog by Brandon Truong - http://brandontruong.blogspot.com/2010/04/use-enum-as-itemssource.html</remarks>
		public static Dictionary<string, T> GetEnumDescriptions<T>()
		{
			var fields = typeof(T).GetFields().Where(info => info.FieldType.Equals(typeof(T)));
			IEnumerable<KeyValuePair<string, T>> enumsAndDescriptions = from field in fields
				select new KeyValuePair<string, T>(GetEnumDescription(field), (T)Enum.Parse(typeof(T), field.Name, false));
			
			Dictionary<string, T> dictionary = new Dictionary<string, T>();
			foreach (KeyValuePair<string, T> pair in enumsAndDescriptions) dictionary.Add(pair.Key, pair.Value);

			return dictionary;
		}

		/// <remarks>Based on blog by Brandon Truong - http://brandontruong.blogspot.com/2010/04/use-enum-as-itemssource.html</remarks>
		public static string GetEnumDescription(FieldInfo field)
		{
			DescriptionAttribute[] attributes =
				(DescriptionAttribute[])field.GetCustomAttributes(
					typeof(DescriptionAttribute), false);
			if (attributes.Length > 0) { return attributes[0].Description; }
			else { return field.Name; }
		}

		public static string Description(this Enum value)
		{
			FieldInfo field = value.GetType().GetField(value.ToString());
			return !(Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute) ? value.ToString() : attribute.Description;
		}

		public static T Increment<T>(this T value) where T : Enum
		{
			var fields = typeof(T).GetFields().Where(info => info.FieldType.Equals(typeof(T))).ToList();
			var field = fields.Where(f => f.Name == value.ToString()).FirstOrDefault();
			var index = fields.IndexOf(field);
			index = (index != fields.Count - 1) ? (index + 1) : 0;
			return (T)Enum.Parse(typeof(T), fields[index].Name, false);
		}

		public static T Decrement<T>(this T value) where T : Enum
		{
			var fields = typeof(T).GetFields().Where(info => info.FieldType.Equals(typeof(T))).ToList();
			var field = fields.Where(f => f.Name == value.ToString()).FirstOrDefault();
			var index = fields.IndexOf(field);
			index = (index != 0) ? (index - 1) : (fields.Count - 1);
			return (T)Enum.Parse(typeof(T), fields[index].Name, false);
		}
	}
}
