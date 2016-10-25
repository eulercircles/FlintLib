using System;
using System.Linq;
using System.Collections.Generic;

namespace FlintLib.Console
{
    public abstract class ConsoleMenu : IConsoleMenu
    {
        protected IConsoleMenuContext _context;
        protected IConsoleMenu _parentMenu;
        protected string _menuTitle;
        protected string _instructions;

        protected Dictionary<ConsoleKey, IConsoleCommand> _commands;

        public ConsoleMenu(IConsoleMenuContext context, ConsoleMenu parentMenu, string instructions, string menuTitle = null)
        {
            if (context == null) { throw new ArgumentNullException(nameof(context)); }
            _context = context;
            _parentMenu = parentMenu;
            _menuTitle = menuTitle;
            _instructions = instructions;
        }

        public void AddCommand(ConsoleKey keyMapping, IConsoleCommand command)
        {
            if (command == null) { throw new ArgumentNullException(nameof(command)); }

            if (_commands == null) { _commands = new Dictionary<ConsoleKey, IConsoleCommand>(); }

            if (!_commands.ContainsKey(keyMapping))
            {
                _commands.Add(keyMapping, command);
            }
            else { throw new ArgumentOutOfRangeException(nameof(keyMapping), "Key is already mapped to another command."); }
        }

        public void Display(string invalidInput = null)
        {
            System.Console.Clear();

            if (!string.IsNullOrWhiteSpace(invalidInput))
            {
                System.Console.WriteLine($"\"{invalidInput}\" is an invalid selection.\r\n\r\n");
            }

            System.Console.WriteLine(_menuTitle.ToUpper());
            System.Console.WriteLine(_instructions);
            
            _commands.ToList().ForEach(kvp => {
                System.Console.WriteLine(kvp.Value.OptionDisplayText);
            });

            var consoleKey = System.Console.ReadKey().Key;

            if (_commands.ContainsKey(consoleKey))
            {
                _commands[consoleKey].Execute(null);
            }
            else { Display(consoleKey.ToString()); }
        }
    }
}
