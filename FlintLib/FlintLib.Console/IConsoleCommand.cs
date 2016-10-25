using System;
using System.Windows.Input;

namespace FlintLib.Console
{
    public interface IConsoleCommand : ICommand
    {
        string OptionDisplayText { get; }
    }
}
