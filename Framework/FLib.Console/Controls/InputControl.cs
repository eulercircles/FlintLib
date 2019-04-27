using System;

namespace FlintLib.Console.Controls
{
    public abstract class InputControl : IConsoleControl
    {
        protected MessageControl _header;
        protected MessageControl _instructions;
        protected MessageControl _feedback;

        protected InputValidator _inputValidator;

        public InputControl(InputValidator inputValidator)
        {
            _inputValidator = inputValidator;
        }

        public void Show()
        {
            Show(null);
        }

        protected abstract void Show(string invalidInput);

        protected bool ValidateInput(object value)
        {
            return _inputValidator.Invoke(value);
        }
    }
}
