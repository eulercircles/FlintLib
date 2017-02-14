using System;

using FlintLib.Console;

namespace FlintLib.Tests
{
	class Program
	{
		static void Main(string[] args)
		{
			//var consoleTester = new ConsoleTester();
			//var loggerTester = new LoggerTester();

			//loggerTester.TestTextFileLogger();

			var phi = Core.Math.Phi;
			System.Console.WriteLine($"Phi: {phi.ToString("F32")}");

			Legacy.Pause();
		}
	}
}
