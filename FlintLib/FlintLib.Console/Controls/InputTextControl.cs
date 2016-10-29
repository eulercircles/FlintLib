using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlintLib.Console.Controls
{
    public class InputTextControl : InputControl
    {
        public InputTextControl(InputValidator inputValidator) : base(inputValidator)
        {
        }

        public virtual string GetInput()
        {
            return System.Console.ReadLine();
        }

        protected override void Show(string invalidInput)
        {
            throw new NotImplementedException();
        }
    }
}
