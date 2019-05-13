using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using FLib.Intelligence;
using FLib.Intelligence.ActivationStrategies;

namespace FLib.Tests.Intelligence
{
	[TestClass]
	public class NeuralNetwork_Tester
	{
		[TestMethod]
		public void TestCreate()
		{
			var inputLayerCount = 3;
			var hiddenLayer1Count = 4;
			var hiddenLayer2Count = 4;
			var outputLayerCount = 3;

			var brain = new NeuralNetwork(new SigmoidStrategy(1), inputLayerCount, hiddenLayer1Count, hiddenLayer2Count, outputLayerCount);

			var inputs = new float[inputLayerCount];
			var random = new Random((int)DateTime.Now.Ticks);

			for (int i = 0; i < inputLayerCount; i++)
			{
				brain.Inputs[i].Input((float)random.NextDouble());
			}
			
			var outputs = brain.Evaluate();
		}
	}
}
