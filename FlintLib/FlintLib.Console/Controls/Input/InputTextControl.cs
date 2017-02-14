using System;

namespace FlintLib.Console.Controls
{
	public class InputTextControl : InputControl
	{
		public InputTextControl()
		{
		}

		public virtual string GetInput()
		{
			return System.Console.ReadLine();
		}

		protected override void Run(string invalidInput)
		{
			throw new NotImplementedException();
		}
	}
}
