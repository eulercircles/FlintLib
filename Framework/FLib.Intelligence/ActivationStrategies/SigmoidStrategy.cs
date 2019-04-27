using System;

using FLib.Mathematics;

namespace FLib.Intelligence.ActivationStrategies
{
	public class SigmoidStrategy : IActivationStrategy
	{
		private readonly float _c;

		public SigmoidStrategy(float c) => _c = c;

		public float Calculate(float value) => Functions.SigmoidF(value, _c);
	}
}
