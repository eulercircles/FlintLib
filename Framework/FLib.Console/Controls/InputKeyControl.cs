using System;

namespace FLib.Console.Controls
{
	public abstract class InputKeyControl : InputControl
	{
		protected ConsoleKey _keyMapping;

		public InputKeyControl(ConsoleKey keyMapping) : base(ValidateInputKey)
		{

		}

		protected bool ValidateInputKey(object value)
		{
			if (value is ConsoleKey)
			{
				var key = (ConsoleKey)value;

				return true;
			}
			else
			{
				throw new ArgumentException();
			}
		}

		public virtual ConsoleKey GetInput()
		{
			return System.Console.ReadKey().Key;
		}

		protected override void Show(string invalidInput)
		{
			throw new NotImplementedException();
		}
	}
}
