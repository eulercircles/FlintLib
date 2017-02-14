using System;

namespace FlintLib.Console.Controls
{
	public class Operation : IConsoleControl
	{
		public string Text { get; set; }

		public string DisplayText { get; set; }

		private MessageTypes _messageType;
		public MessageTypes MessageType
		{
			get { return _messageType; }
			set
			{
				_messageType = value;
			}
		}

		public void Run()
		{
			System.Console.WriteLine(Text);
			System.Console.WriteLine(Environment.NewLine);
		}

		public void Show(MessageTypes messageType)
		{
			switch (messageType)
			{
				case MessageTypes.Error:
					System.Console.ForegroundColor = ColorScheme.ErrorForeground;
					break;
				case MessageTypes.Special:
					System.Console.ForegroundColor = ColorScheme.SpecialForeground;
					break;
				case MessageTypes.Success:
					System.Console.ForegroundColor = ColorScheme.SuccessForeground;
					break;
				case MessageTypes.Warning:
					System.Console.ForegroundColor = ColorScheme.WarningForeground;
					break;
				default:
					System.Console.ForegroundColor = ColorScheme.DefaultForeground;
					break;
			}

			Run();

			System.Console.ForegroundColor = ColorScheme.DefaultForeground;
		}

		public void Show(MessageTypes messageType, string text)
		{
			Text = text;
			Show(messageType);
		}
	}
}
