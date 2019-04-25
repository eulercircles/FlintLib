using System;

using static FLib.Common.Formats;

namespace FLib.Scheduling
{
	internal static class Extensions
	{
		internal static string ToKeyFormat(this DateTime value) => value.ToString(Format_DateTime_YearFirst);
	}
}
