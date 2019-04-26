using System;

namespace FLib.Intelligence.ActivationStrategies
{
	public class ReLUStrategy : IActivationStrategy
	{
		public float Calculate(float value) => Math.Max(0.0f, value);
	}
}
