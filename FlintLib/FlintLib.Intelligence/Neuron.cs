using System;

namespace FlintLib.Intelligence
{
	internal class Neuron : IOuputNode
	{
		private readonly IActivationStrategy _activationStrategy;
		private readonly IOuputNode[] _previousLayer;
		private readonly float[] _weights;

		internal Neuron(IONode inputNode, IActivationStrategy activationStrategy)
		{
			_activationStrategy = activationStrategy;
			_previousLayer = new IOuputNode[] { inputNode };

			// Not sure if the input needs a weight or not.
			_weights = new float[1];
			_weights[0] = 1;
		}

		internal Neuron(IOuputNode[] previousLayerNeurons, IActivationStrategy activationStrategy)
		{
			_activationStrategy = activationStrategy ?? throw new ArgumentNullException(nameof(activationStrategy));

			_previousLayer = previousLayerNeurons;

			_weights = new float[previousLayerNeurons.Length];
		}

		internal void RandomizeWeights(Random random = null, int min = -1, int max = 1)
		{
			if (random == null) { random = new Random((int)DateTime.Now.Ticks); }
			for (int i = 0; i < _weights.Length; i++)
			{
				_weights[i] = random.Next(min, max);
			}
		}

		public float Output()
		{
			var sum = 0.0f;
			for (int i = 0; i < _previousLayer.Length; i++)
			{
				sum += (_previousLayer[i].Output() * _weights[i]);
			}
			var result = _activationStrategy.Calculate(sum);
			return result;
		}
	}
}
