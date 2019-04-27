using System;

namespace FlintLib.Common
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
	public class DescriptionAttribute : Attribute
	{
		public string Description { get; }
	}
}