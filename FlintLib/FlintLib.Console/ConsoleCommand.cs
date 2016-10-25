using System;
using System.Windows.Input;

namespace FlintLib.Console
{
    public abstract class ConsoleCommand : IConsoleCommand
    {
        public string OptionDisplayText { get; }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter = null)
        {
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        public virtual void Execute(object parameter = null)
        {
            System.Console.Clear();
            if (parameter is string && !string.IsNullOrWhiteSpace(parameter as string))
            {
                string invalidInput = (parameter as string);
                System.Console.WriteLine($"\"{invalidInput}\" is invalid.");
            }
        }
    }
}
