using System;

namespace FlintLib.Synthesis
{
	internal static class Functions
	{
		public const double Pi2 = 2 * Math.PI;

		public static double Clamp1(double value)
		{
			if (value < -1) return -1;
			else if (value > 1) return 1;
			else return value;
		}
	}
}
