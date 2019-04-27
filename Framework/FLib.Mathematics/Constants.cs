using System;

namespace FLib.Mathematics
{
	public static class Constants
	{
		public const double InchToCentimeterMultiplier = 2.54;
		public const double CentimeterToInchMultiplier = 1 / InchToCentimeterMultiplier;

		public const double Pi2 = 2 * Math.PI;
		public static readonly double PHI = ((1 + Math.Sqrt(5)) / 2);
	}
}
