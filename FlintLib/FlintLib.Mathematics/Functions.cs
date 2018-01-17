using System;
using System.Numerics;

namespace FlintLib.Mathematics
{
	public static class Functions
	{
		public const double InchToCentimeterMultiplier = 2.54;
		public const double CentimeterToInchMultiplier = 1 / InchToCentimeterMultiplier;

		public static float ClampF(float min, float max, float x)
		{
			if (x < min) { return min; }
			else if (x > max) { return max; }
			else { return x; }
		}

		public static float SigmoidF(float x, float c)
		{
			if (!(c > 0.0f)) { throw new ArgumentOutOfRangeException(); }

			var denominator = (1 + System.Math.Pow(System.Math.E, -x / c));

			var result = 0.0f;
			if (denominator > 0) { result = (float)(1 / denominator); }

			return result;
		}

		public static double SigmoidD(double x, double c)
		{
			if (!(c > 0.0d)) { throw new ArgumentOutOfRangeException(); }

			var denominator = (1 + System.Math.Pow(System.Math.E, -x / c));

			var result = 0.0d;
			if (denominator > 0) { result = (1 / denominator); }

			return result;
		}

		public static float HyperbolicTangentF(float x)
		{
			var denominator = (System.Math.Pow(System.Math.E, x) + System.Math.Pow(System.Math.E, -x));
			var numerator = (System.Math.Pow(System.Math.E, x) - System.Math.Pow(System.Math.E, -x));
			var result = (numerator / denominator);
			return (float)result;
		}

		public static double HyperbolicTangentD(double x)
		{
			var denominator = (System.Math.Pow(System.Math.E, x) + System.Math.Pow(System.Math.E, -x));
			var numerator = (System.Math.Pow(System.Math.E, x) - System.Math.Pow(System.Math.E, -x));
			var result = (numerator / denominator);
			return result;
		}

		public static double Length(double x, double y, double z)
		{
			return System.Math.Sqrt((x * x) + (y * y) + (z * z));
		}

		public static double RadiansToDegrees(double radians)
		{
			return (radians * (180 / System.Math.PI));
		}

		public static double DegreesToRadians(double degrees)
		{
			return (degrees * (System.Math.PI / 180));
		}

		public static double Angle(Vector2 vectorA, Vector2 vectorB)
		{
			return (Vector2.Dot(vectorA, vectorB) / (vectorA.Length() * vectorB.Length()));
		}

		public static double Angle(Vector3 vectorA, Vector3 vectorB)
		{
			return (Vector3.Dot(vectorA, vectorB) / (vectorA.Length() * vectorB.Length()));
		}
		
		public static readonly double PHI = ((1 + System.Math.Sqrt(5)) / 2);

		public static ushort GCD(ushort a, ushort b)
		{
			while (b > 0)
			{
				ushort remainder = (ushort)(a % b);
				a = b;
				b = remainder;
			}
			return a;
		}

		public static uint GCD(uint a, uint b)
		{
			while (b > 0)
			{
				uint remainder = a % b;
				a = b;
				b = remainder;
			}
			return a;
		}
	}
}
