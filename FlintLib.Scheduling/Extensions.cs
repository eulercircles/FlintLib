using System;

using static FlintLib.Common.Resources.PublicStrings;

namespace FlintLib.Scheduling
{
	internal static class Extensions
	{
		internal static string ToKeyFormat(this DateTime value) => value.ToString(Format_DateTime_YearFirst);
	}
}
