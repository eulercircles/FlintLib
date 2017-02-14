using System;

namespace FlintLib.Console.Controls
{
	public interface IConsoleControl
	{
		// Descriptive text of this control that will be displayed as a menu item.
		string DisplayText { get; set; }

		void Run();
	}
}
