using System;
using System.Collections.Generic;

using FLib.Commands;

namespace FLib.Console.Controls
{
	public abstract class MenuItemControl : IConsoleControl
	{
		public string HeaderText { get; set; }

		public void Show()
		{
			throw new NotImplementedException();
		}
	}
}
