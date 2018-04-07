using System;
using System.Diagnostics;

namespace FlintLib.Intelligence
{
	public class NeuralNetwork
	{
		private readonly IInputNode[] _inputLayer;
		private readonly IOuputNode[] _outputLayer;

		public IInputNode[] Inputs => _inputLayer;

		public NeuralNetwork(IActivationStrategy activationStrategy, params int[] layerNeuronCounts)
		{
			// Check inputs.

			var random = new Random((int)DateTime.Now.Ticks);

			IOuputNode[] previousLayer = null;
			for (int i = 0; i < layerNeuronCounts.Length; i++)
			{
				if (layerNeuronCounts[i] <= 0) { throw new ArgumentException($"Index {i}'s value is zero. All layers must contain at least one neuron.", nameof(layerNeuronCounts)); }

				var newLayer = new Neuron[layerNeuronCounts[i]];

				if (i == 0)
				{
					_inputLayer = new IONode[layerNeuronCounts[i]];

					for (int n = 0; n < newLayer.Length; n++)
					{
						var inputNode = new IONode();
						_inputLayer[n] = inputNode;
						newLayer[n] = new Neuron(inputNode, activationStrategy);
						newLayer[n].RandomizeWeights(random);
					}
				}
				else
				{
					for (int n = 0; n < newLayer.Length; n++)
					{
						newLayer[n] = new Neuron(previousLayer, activationStrategy);
						newLayer[n].RandomizeWeights(random);
					}
				}
				
				previousLayer = newLayer;
			}

			_outputLayer = previousLayer;
		}

		public float[] Evaluate()
		{
			float[] results = new float[_outputLayer.Length];
			for (int i = 0; i < _outputLayer.Length; i++)
			{
				results[i] = _outputLayer[i].Output();
			}
			return results;
		}
	}
}
