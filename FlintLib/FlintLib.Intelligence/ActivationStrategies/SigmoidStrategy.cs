using System;

using FlintLib.Mathematics;

namespace FlintLib.Intelligence.ActivationStrategies
{
	public class SigmoidStrategy : IActivationStrategy
	{
		private readonly float _c;

		public SigmoidStrategy(float c) => _c = c;

		public float Calculate(float value) => Mathematics.Functions.SigmoidF(value, _c);
	}
}
