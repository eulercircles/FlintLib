using System;
using System.Numerics;

namespace FlintLib.Mathematics
{
	public static class Functions
	{
		public static double Clamp1(double value)
		{
			if (value < -1) return -1;
			else if (value > 1) return 1;
			else return value;
		}

		public static float ClampF(float min, float max, float x)
		{
			if (x < min) { return min; }
			else if (x > max) { return max; }
			else { return x; }
		}

		public static byte Clamp(int i)
		{
			if (i < 0) return 0;
			if (i > 255) return 255;
			return (byte)i;
		}

		public static double DegreeClamp(double angle)
		{
			if (angle < 0) return (360.0 + angle);
			if (angle >= 360.0) return (angle - 360.0);
			return angle;
		}

		public static int PercentClamp(int i)
		{
			if (i < 0) { return 0; }
			if (i > 100) { return 100; }
			return i;
		}

		public static float SigmoidF(float x, float c)
		{
			if (!(c > 0.0f)) { throw new ArgumentOutOfRangeException(); }

			var denominator = (1 + Math.Pow(Math.E, -x / c));

			var result = 0.0f;
			if (denominator > 0) { result = (float)(1 / denominator); }

			return result;
		}

		public static double SigmoidD(double x, double c)
		{
			if (!(c > 0.0d)) { throw new ArgumentOutOfRangeException(); }

			var denominator = (1 + Math.Pow(Math.E, -x / c));

			var result = 0.0d;
			if (denominator > 0) { result = (1 / denominator); }

			return result;
		}

		public static float HyperbolicTangentF(float x)
		{
			var denominator = (Math.Pow(Math.E, x) + Math.Pow(Math.E, -x));
			var numerator = (Math.Pow(Math.E, x) - Math.Pow(Math.E, -x));
			var result = (numerator / denominator);
			return (float)result;
		}

		public static double HyperbolicTangentD(double x)
		{
			var denominator = (Math.Pow(Math.E, x) + Math.Pow(Math.E, -x));
			var numerator = (Math.Pow(Math.E, x) - Math.Pow(Math.E, -x));
			var result = (numerator / denominator);
			return result;
		}

		public static double RadiansToDegrees(double radians)
		{
			return (radians * (180 / Math.PI));
		}

		public static double DegreesToRadians(double degrees)
		{
			return (degrees * (Math.PI / 180));
		}

		public static double RadianAngle(Vector2 vectorA, Vector2 vectorB)
		{
			var dot = Vector2.Dot(vectorA, vectorB);
			var length = vectorA.Length() * vectorB.Length();
			var result = Math.Acos(dot / length);
			return result;
		}

		public static double DegreeAngle(Vector2 vectorA, Vector2 vectorB)
		{
			var result = RadiansToDegrees(RadianAngle(vectorA, vectorB));
			return result;
		}

		public static double RadianAngle(Vector3 vectorA, Vector3 vectorB)
		{
			var dot = Vector3.Dot(vectorA, vectorB);
			var length = vectorA.Length() * vectorB.Length();
			var result = Math.Acos(dot / length);
			return result;
		}

		public static double DegreeAngle(Vector3 vectorA, Vector3 vectorB)
		{
			var result = RadiansToDegrees(RadianAngle(vectorA, vectorB));
			return result;
		}

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
