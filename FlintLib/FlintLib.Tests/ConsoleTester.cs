using System;

using FlintLib.Console;
using FlintLib.Console.Controls;

namespace FlintLib.Tests
{
	class ConsoleTester
	{

		public void TestConsoleControls()
		{
			var controlSystem = DeclareSystem();
			controlSystem.Run();
		}

		private IConsoleControl DeclareSystem()
		{
			// Submenu 1
			var subMenu1 = new InputKeyControl("Sub-Menu 1", "More options:")
			{
				DisplayText = "Sub-Menu 1"
			};

			subMenu1.InsertKeyBinding(ConsoleKey.D1, new Operation()
			{
				MessageType = MessageTypes.Default,
				DisplayText = "First Option",
				Text = "You selected the first option."
			});
			subMenu1.InsertKeyBinding(ConsoleKey.D2, new Operation()
			{
				MessageType = MessageTypes.Default,
				DisplayText = "Second Option",
				Text = "You selected the second option."
			});
			subMenu1.InsertKeyBinding(ConsoleKey.D3, new Operation()
			{
				MessageType = MessageTypes.Default,
				DisplayText = "Third Option",
				Text = "You selected the third option."
			});

			var mainMenu = new InputKeyControl("MAIN MENU", "Please select from the following options:");
			mainMenu.InsertKeyBinding(ConsoleKey.D1, subMenu1);

			return mainMenu;
		}
	}
}
