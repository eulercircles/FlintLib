using System;

using FlintLib.Console;
using FlintLib.Console.Controls;

namespace FlintLib.Console.Testbed
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputKeyControl = new InputKeyControl(ValidateMyInputKey);
        }

        private static bool ValidateMyInputKey(object value)
        {
            
        }
    }
}
