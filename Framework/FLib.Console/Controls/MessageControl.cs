using FLib.Common;
using System;

namespace FLib.Console.Controls
{
	public class MessageControl : IConsoleControl
	{
		public string Text { get; set; }

		public MessageTypes MessageType { get; set; }

		public void Show()
		{
			System.Console.WriteLine(Text);
			System.Console.WriteLine(StringUtilities.NewLines(2));
		}

		public void Show(MessageTypes messageType)
		{
			MessageType = messageType;
			Show();
		}

		public void Show(MessageTypes messageType, string text)
		{
			MessageType = messageType;
			Text = text;
			Show();
		}
	}
}
