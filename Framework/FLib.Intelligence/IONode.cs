using System;

namespace FLib.Intelligence
{
	internal class IONode : IInputNode, IOuputNode
	{
		private float _value;

		public void Input(float value)
		{
			_value = value;
		}

		public float Output() => _value;
	}
}
