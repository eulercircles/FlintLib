using System;

namespace FlintLib.Console
{
    public interface IConsoleMenu
    {
        void AddCommand(ConsoleKey keyMapping, IConsoleCommand command);

        void Display(string invalidInput = null);
    }
}
