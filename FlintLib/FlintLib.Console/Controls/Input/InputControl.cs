using System;

namespace FlintLib.Console.Controls
{
	public abstract class InputControl : IConsoleControl
	{
		protected Operation _header;
		protected Operation _instructions;
		protected Operation _feedback;

		public string DisplayText { get; set; }

		public void Run()
		{
			Run(null);
		}

		protected abstract void Run(string invalidInput);
	}
}
