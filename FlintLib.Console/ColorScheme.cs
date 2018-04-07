using System;

namespace FlintLib.Console
{
    public static class ColorScheme
    {
        public static ConsoleColor DefaultForeground { get; set; } = ConsoleColor.White;

        public static ConsoleColor DefaultBackground { get; set; } = ConsoleColor.Black;

        public static ConsoleColor SuccessForeground { get; set; } = ConsoleColor.Green;

        public static ConsoleColor SuccessBackground { get; set; } = ConsoleColor.Black;

        public static ConsoleColor ErrorForeground { get; set; } = ConsoleColor.Red;

        public static ConsoleColor ErrorBackground { get; set; } = ConsoleColor.Black;

        public static ConsoleColor WarningForeground { get; set; } = ConsoleColor.Yellow;

        public static ConsoleColor WarningBackground { get; set; } = ConsoleColor.Black;

        public static ConsoleColor SpecialForeground { get; set; } = ConsoleColor.Cyan;

        public static ConsoleColor SpecialBackground { get; set; } = ConsoleColor.Black;

        public static ConsoleColor DisabledForeground { get; set; } = ConsoleColor.Gray;

        public static ConsoleColor DisabledBackground { get; set; } = ConsoleColor.Black;
    }
}
