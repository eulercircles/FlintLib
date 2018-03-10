using System;
using System.Text.RegularExpressions;

using FlintLib.Common.Resources;

namespace FlintLib.Common
{
	public static class StringUtilities
	{
		public static string NewLines(ushort count)
		{
			var result = string.Empty;
			for (int i = 0; i < count; i++) { result += Environment.NewLine; }
			return result;
		}
	}
}
