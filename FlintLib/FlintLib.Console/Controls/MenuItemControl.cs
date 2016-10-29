using System;
using System.Collections.Generic;

using FlintLib.Commands;

namespace FlintLib.Console.Controls
{
    public abstract class MenuItemControl : IConsoleControl
    {
        protected FlintLib.Commands.ICommand _command;

        public string HeaderText { get; set; }

        public void Show()
        {
            throw new NotImplementedException();
        }
    }
}
