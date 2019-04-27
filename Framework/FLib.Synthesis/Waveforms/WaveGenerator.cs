using System;

using FlintLib.Mathematics;

namespace FlintLib.Synthesis.Waveforms
{
	public static class WaveGenerator
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="phase"></param>
		/// <returns></returns>
		public static double GeneratePureSineSample(double phase) => (Math.Sin(Constants.Pi2 * phase));

		/// <summary>
		/// 
		/// </summary>
		/// <param name="phase"></param>
		/// <returns></returns>
		public static double GeneratePureSawtoothSample(double phase) => (2 * phase - 1);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="phase"></param>
		/// <returns></returns>
		public static double GenerateMinimoogSawtoothSample(double phase) => (-Math.Cos(Constants.Pi2* (phase / 2)));

		/// <summary>
		/// 
		/// </summary>
		/// <param name="phase"></param>
		/// <returns></returns>
		public static double GeneratePureSquareSample(double phase) => ((phase < 0.5) ? 1 : -1);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="phase"></param>
		/// <returns></returns>
		public static double GenerateMinimoogSquareSample(double phase) => ((phase < 0.5) ? (-Math.Sqrt(phase) + 1) : (Math.Sqrt(phase - .5) - 1));

		/// <summary>
		/// 
		/// </summary>
		/// <param name="phase"></param>
		/// <param name="pulseWidth"></param>
		/// <returns></returns>
		public static double GeneratePurePulseSample(double phase, double pulseWidth) => ((phase < (1-pulseWidth)) ? 1 : - 1);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="phase"></param>
		/// <param name="pulseWidth"></param>
		/// <returns></returns>
		public static double GenerateFarfisaPulseSample(double phase, double pulseWidth) => ((phase < (1 - pulseWidth)) ? 1 : Math.Pow((1 / pulseWidth) * (phase - 1), 2) - 1);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="phase"></param>
		/// <returns></returns>
		public static double GeneratePureTrianlgeSample(double phase) => (4 * -Math.Abs(phase - .5) + 1);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="phase"></param>
		/// <returns></returns>
		public static double GenerateMinimoogTriangleSample(double phase) => (0);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="phase"></param>
		/// <returns></returns>
		public static double GenerateMinimoogSharktoothSample(double phase) => (0);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="phase"></param>
		/// <returns></returns>
		public static double GenerateBillabongSample(double phase) => (0);
	}
}
