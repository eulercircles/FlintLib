using System;
using System.Collections.Generic;

namespace FlintLib.Console.Controls
{
	public class InputKeyControl : InputControl
	{
		protected Dictionary<ConsoleKey, IConsoleControl> _items;
		protected KeyInputValidator _inputValidator;

		public InputKeyControl(string header, string instructions)
		{
			this._header = new Operation()
			{
				MessageType = MessageTypes.Default,
				Text = header
			};

			this._instructions = new Operation()
			{
				MessageType = MessageTypes.Default,
				Text = instructions
			};

			this._feedback = new Operation()
			{
				MessageType = MessageTypes.Default,
				Text = ""
			};
			
			this._inputValidator = ValidateInputKey;
			this._items = new Dictionary<ConsoleKey, IConsoleControl>();
			this._items[ConsoleKey.X] = null;
		}

		protected virtual bool ValidateInputKey(ConsoleKey inputKey)
		{
			return _items.ContainsKey(inputKey);
		}

		public virtual ConsoleKey GetInput()
		{
			return System.Console.ReadKey().Key;
		}

		public virtual void InsertKeyBinding(ConsoleKey key, IConsoleControl control)
		{
			if (!_items.ContainsKey(key))
			{
				_items[key] = control;
			}
			else { throw new Exception("Item already exists."); }
		}

		protected override void Run(string invalidInput = null)
		{
			System.Console.Clear();

			if (!string.IsNullOrWhiteSpace(invalidInput))
			{
				_feedback.Show(MessageTypes.Error, invalidInput);
			}

			_header.Run();
			_instructions.Run();
			
			foreach (var item in _items)
			{
				System.Console.WriteLine($"{item.Key}: {item.Value.DisplayText}");
			}

			var inputKey = GetInput();

			if (inputKey == ConsoleKey.X)
			{
				return;
			}

			if (ValidateInputKey(inputKey))
			{
				var control = _items[inputKey];
				control.Run();
				Run(null);
			}
			else
			{
				Run($"{inputKey} is an invalid selection.");
			}
		}
	}
}
