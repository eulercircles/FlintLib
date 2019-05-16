using System;

using static FLib.Common.Formats;

namespace FLib.Scheduling
{
	internal static class Extensions
	{
		internal static string ToKeyFormat(this DateTime value) => value.ToString(DateTime_YearFirst);

		public static string ToLetterCode(this CorrectionMethods method)
		{
			string result;
			switch (method)
			{
				case CorrectionMethods.After: result = "A"; break;
				case CorrectionMethods.Before: result = "B"; break;
				case CorrectionMethods.None: result = "N"; break;
				default: result = "N"; break;
			}
			return result;
		}
	}
}
